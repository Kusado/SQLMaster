using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using Helpers;

namespace SQLMaster {
  [Serializable]
  public class SqlInstance {
    public SqlInstance() { }

    public SqlInstance(string ServerName, string InstanceName = "DEFAULT") {
      this.Databases = new List<Database>();
      this.Host = NS.Host.GetHostEntry(ServerName.Replace(" ", ""));
      this.InstanceName = InstanceName;
      this.ServiceName = this.InstanceName == "DEFAULT" ? "MSSQLSERVER" : "MSSQL$" + this.InstanceName;
    }

    public string ConnectionString { get; set; }
    public NS.Host Host { get; set; }
    public string Hostname {
      get { return this.Host.FQDN; }
      set { }
    }
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
    public bool AbleToConnect { get; set; }

    public override string ToString() { return $@"{this.Host}\{this.InstanceName}"; }

    public void GetDatabases(SqlConnection Connection) {
      this.Databases.Clear();
      string query = "select name,create_date,state_desc,recovery_model,database_id,suser_sname( owner_sid )" +
                     " from sys.databases" +
                     " order by name";

      //Connection.Open();
      DataTable dt = Helpers.GetDatatable(query, Connection);
      foreach (DataRow row in dt.Rows) {
        Database db = new Database {
          Name = row[0].ToString(),
          CreateDate = DateTime.Parse(row[1].ToString()),
          state_desc = row[2].ToString(),
          RecoveryModel = (RecoveryModel) int.Parse(row[3].ToString()),
          ID = int.Parse(row[4].ToString()),
          Owner = row[5].ToString()
        };
        this.Databases.Add(db);
      }
    }

    public Process OpenSSMS(string database = "") {
      ProcessStartInfo smss = new ProcessStartInfo();
      smss.FileName = "ssms.exe";
      string args;
      if (this.InstanceName.ToLower() == "default") args = $"-E -S {this.Host} -nosplash";
      else args = $"-E -S {this.Host}\\{this.InstanceName} -nosplash";
      if (!string.IsNullOrEmpty(database)) args += $" -d {database}";
      smss.Arguments = args;
      return Process.Start(smss);
    }
  }
}