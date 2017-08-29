using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Helpers;

namespace SQLMaster {
  public class Database {
    public int ID { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
    public string Files { get { return this.FileNames.ToString(); } }
    public FileList<string> FileNames { get; set; }
    public double Size { get; set; }
    public double SizeFree { get; set; }
    public int SizeFreePercent { get; set; }
    public string LogFiles { get { return this.LogFileNames.ToString(); } }
    public FileList<string> LogFileNames { get; set; }
    public double LogSize { get; set; }
    public double LogSizeFree { get; set; }
    public int LogSizeFreePercent { get; set; }
    public DateTime CreateDate { get; set; }
    public RecoveryModel RecoveryModel { get; set; }
    public string state_desc { get; set; }
    public DateTime LastBackupDate { get; set; }
    public TimeSpan LastBackupSpan { get; set; }
    public DateTime LastBackupLogDate { get; set; }
    public TimeSpan LastBackupLogSpan { get; set; }

    public void GetFilesSize(SqlConnection Connection) {
      this.FileNames = new FileList<string>();
      this.LogFileNames = new FileList<string>();
      this.Size = 0;
      this.LogSize = 0;
      if (this.state_desc.ToLower() == "online") {
        string query = $" select type, size,name from sys.master_files" +
                       $" where database_id = {this.ID}";
        DataTable dt = Helpers.GetDatatable(query, Connection);
        foreach (DataRow row in dt.Rows) {
          FileType type = (FileType)int.Parse(row[0].ToString());
          if (type == FileType.LogFile) {
            this.LogFileNames.Add(row[2].ToString());
            this.LogSize += int.Parse(row[1].ToString()) / 128.0;
          }
          if (type == FileType.DataFile) {
            this.FileNames.Add(row[2].ToString());
            this.Size += int.Parse(row[1].ToString()) / 128.0;
          }
        }

        int SizeUsed = this.FileNames.Sum(fileName => Helpers.ExecuteScalar<int>($"USE [{this.Name}] select FILEPROPERTY('{fileName}', 'SpaceUsed')", Connection));

        int LogUsed = this.LogFileNames.Sum(logFileName => Helpers.ExecuteScalar<int>($"USE [{this.Name}] select FILEPROPERTY('{logFileName}', 'SpaceUsed')", Connection));

        this.SizeFree = (int)(this.Size - SizeUsed / 128.0);
        this.LogSizeFree = (int)(this.LogSize - LogUsed / 128.0);

        this.Size = (int)this.Size;
        this.LogSize = (int)this.LogSize;

        this.SizeFreePercent = (int)(this.SizeFree * 100.0 / this.Size);
        this.LogSizeFreePercent = (int)(this.LogSizeFree * 100.0 / this.LogSize);
        if (this.Size < 0) this.Size = 0;
        if (this.SizeFree < 0) this.SizeFree = 0;
        if (this.SizeFreePercent < 0) this.SizeFreePercent = 0;
        if (this.LogSize < 0) this.LogSize = 0;
        if (this.LogSizeFree < 0) this.LogSizeFree = 0;
        if (this.LogSizeFreePercent < 0) this.LogSizeFreePercent = 0;

      }
    }

    public Database GetBackupInfo(SqlConnection Connection, out bool backup, out bool log) {
      Database result = new Database();
      backup = log = false;

      //Попробуем достать время последнего бекапа базы
      string queryd = $" select top 1 backup_start_date, backup_finish_date from msdb..backupset" +
                      $" where database_name = '{this.Name}'" +
                      $" and type = 'd'" +
                      $" order by backup_finish_date desc";
      DataTable dtd = Helpers.GetDatatable(queryd, Connection);

      if (dtd.Rows.Count == 1 &&
          DateTime.TryParse(dtd.Rows[0][0].ToString(), out DateTime start) &&
          DateTime.TryParse(dtd.Rows[0][1].ToString(), out DateTime finish)) {
        result.LastBackupDate = finish;
        result.LastBackupSpan = finish - start;
        backup = true;
      }

      //Если база в FullMode, то попробуем достать время последнего бекапа логов
      if (this.RecoveryModel == RecoveryModel.Full) {
        string queryl = $" select top 1 backup_start_date, backup_finish_date from msdb..backupset" +
                        $" where database_name = '{this.Name}'" +
                        $" and type = 'l'" +
                        $" order by backup_finish_date desc";
        DataTable dtl = Helpers.GetDatatable(queryl, Connection);

        if (dtl.Rows.Count == 1 &&
            DateTime.TryParse(dtl.Rows[0][0].ToString(), out DateTime logStart) &&
            DateTime.TryParse(dtl.Rows[0][1].ToString(), out DateTime logFinish)) {
          result.LastBackupLogDate = logFinish;
          result.LastBackupLogSpan = logFinish - logStart;
          log = true;
        }
      }
      return result;
    }

    public void ShrinkFiles(SqlConnection Connection, bool db = false, bool log = false) {
      if (db) _shrinkFile(Connection, this.Name, this.FileNames);
      if (log) _shrinkFile(Connection, this.Name, this.LogFileNames);
      Thread.Sleep(500);
      GetFilesSize(Connection);
    }

    private static void _shrinkFile(SqlConnection Connection, string dbName, FileList<string> files, int ShrinkTo = 1) {
      foreach (string fileName in files) {
        string query = $" USE [{dbName}]" +
                       $" DBCC SHRINKFILE (N'{fileName}' , {ShrinkTo})";
        Splash splash = Splash.ShowSplash($"Shrinking {fileName}");
        var shrinkerConnection = new SqlConnection(Connection.ConnectionString);
        shrinkerConnection.Open();
        IAsyncResult shrinker = Helpers.ExecuteNonQuery(query, shrinkerConnection, 0);
        int sid = -1;
        bool repeat = true;
        do {
          Thread.Sleep(100);
          try {
            sid =
              int.Parse(Helpers.ExecuteScalar(
                                              "SELECT session_id from sys.dm_exec_requests WHERE command like '%DbccFilesCompact%'",
                                              Connection));
            repeat = false;
          }
          catch (Exception e) {
            Console.WriteLine(e);
          }
        } while (!shrinker.IsCompleted & repeat);
        while (!shrinker.IsCompleted) {
          Debug.WriteLine(shrinker.ToString());
          splash.Status = "Percent complete: "
                          + Helpers.ExecuteScalar($"SELECT percent_complete from sys.dm_exec_requests WHERE session_id = {sid}", Connection) + $" Session ID = {sid}";
          Thread.Sleep(1000);
        }
        shrinkerConnection.Close();
        splash.CloseSplash();
      }
    }
  }

  public class FileList<T> : List<T> {
    public string Files {
      get {
        return this.ToString();
      }
      set { }
    }

    public override string ToString() {
      string result = "";
      foreach (T t in this) {
        result += t.ToString() + ";";
      }
      return result.TrimEnd(';');
    }
  }

  public enum RecoveryModel {
    Full = 1,
    BulkLogged,
    Simple
  }

  public enum FileType {
    DataFile = 0,
    LogFile = 1
  }
}