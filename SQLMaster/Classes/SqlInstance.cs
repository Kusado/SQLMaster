using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using Helpers;

namespace SQLMaster {
  [Serializable]
  public class SqlInstance {
    public string ConnectionString { get; set; }
    public NS.Host Host { get; set; }
    public IPStatus ServerStatus { get; set; }
    public string InstanceName { get; set; }
    public string ServiceName { get; set; }
    public int ServerMemoryRunning { get; set; }
    public int ServerMemoryMax { get; set; }
    public int DatabasesSize { get; set; }
    public string Info { get; set; }
    public string Description { get; set; }
    public ServiceControllerStatus ServiceStatus { get; set; }
    public List<Database> Databases { get; set; }

    public SqlInstance() {
    }

    public SqlInstance(string ServerName, string InstanceName = "DEFAULT") {
      this.Databases = new List<Database>();
      this.Host = NS.Host.GetHostEntry(ServerName.Replace(" ", ""));
      this.InstanceName = InstanceName;
      this.ServiceName = this.InstanceName == "DEFAULT" ? "MSSQLSERVER" : "MSSQL$" + this.InstanceName;
    }

    public void GetDatabases(SqlConnection Connection) {
      this.Databases.Clear();
      string query = "select name,create_date,state_desc,recovery_model,database_id,suser_sname( owner_sid )" +
                     " from sys.databases" +
                     " order by name";

      //Connection.Open();
      DataTable dt = Helpers.GetDatatable(query, Connection);
      foreach (DataRow row in dt.Rows) {
        Database db = new Database();
        db.Name = row[0].ToString();
        db.CreateDate = DateTime.Parse(row[1].ToString());
        db.state_desc = row[2].ToString();
        db.RecoveryModel = (RecoveryModel)int.Parse(row[3].ToString());
        db.ID = Int32.Parse(row[4].ToString());
        db.Owner = row[5].ToString();
        this.Databases.Add(db);
      }
    }
    public Database GetBackupInfo(Database db, SqlConnection Connection, out bool backup, out bool log) {
      Database result = new Database();
      backup = log = false;

      //Попробуем достать время последнего бекапа базы
      string queryd = $" select top 1 backup_start_date, backup_finish_date from msdb..backupset" +
                     $" where database_name = '{db.Name}'" +
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
      if (db.RecoveryModel == RecoveryModel.Full) {
        string queryl = $" select top 1 backup_start_date, backup_finish_date from msdb..backupset" +
                        $" where database_name = '{db.Name}'" +
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
  }
}