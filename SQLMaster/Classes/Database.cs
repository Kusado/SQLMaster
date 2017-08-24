using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMaster {
  public class Database {
    public int ID { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
    public string FileName { get; set; }
    public double Size { get; set; }
    public double SizeFree { get; set; }
    public int SizeFreePercent { get; set; }
    public string LogFileName { get; set; }
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
      this.Size = 0;
      this.LogSize = 0;
      string query = $" select type, size,name from sys.master_files" +
                     $" where database_id = {this.ID}";
      DataTable dt = Helpers.GetDatatable(query, Connection);
      foreach (DataRow row in dt.Rows) {
        int type = int.Parse(row[0].ToString());
        if (type == 1) {
          this.LogFileName = row[2].ToString();
          this.LogSize += int.Parse(row[1].ToString()) /128.0;
        }
        if (type == 0) {
          this.FileName = row[2].ToString();
          this.Size += int.Parse(row[1].ToString()) /128.0;
        }
      }
      int SizeUsed = Helpers.ExecuteScalar<int>($"USE [{this.Name}] select FILEPROPERTY('{this.FileName}', 'SpaceUsed')", Connection);
      int LogUsed = Helpers.ExecuteScalar<int>($"USE [{this.Name}] select FILEPROPERTY('{this.LogFileName}', 'SpaceUsed')", Connection);

      this.SizeFree = this.Size - SizeUsed/128.0;
      this.LogSizeFree = this.LogSize - LogUsed/128.0;

      this.SizeFreePercent = (int)(this.SizeFree * 100.0 / this.Size);
      this.LogSizeFreePercent = (int)(this.LogSizeFree * 100.0 / this.LogSize);

    }

    public void ShrinkFile(SqlConnection Connection,bool db=false,bool log=false) {
      string query;
      if (db) {
        query = $" USE [{this.Name}]" +
                       $" DBCC SHRINKFILE (N'{this.FileName}' , 1)";
        Helpers.ExecuteNonQuery(query, Connection);
      }
      if (log) {
        query = $" USE [{this.Name}]" +
                       $" DBCC SHRINKFILE (N'{this.LogFileName}' , 1)";
        Helpers.ExecuteNonQuery(query, Connection);
      }
    }

  }
  public enum RecoveryModel {
    Full = 1,
    BulkLogged,
    Simple,
  }
}
