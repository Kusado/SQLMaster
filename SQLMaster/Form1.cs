using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Db;
using DevExpress.XtraGrid.Views.Grid;
//using DevExpress.XtraGrid.Views.Grid;
using Helpers;
using Newtonsoft.Json;

namespace SQLMaster {
  public partial class Form1 : Form {
    private List<SqlInstance> SqlServers = new List<SqlInstance>();
    private BindingSource bs = new BindingSource();
    private Splash splash;
    private SqlInstance SelectedInstance;
    public Form1() {
      InitializeComponent();
      this.bs.DataSource = this.SqlServers;

      this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
      this.gridControl1.DataSource = this.SqlServers;
    }


    private void RefreshGrid() {
      this.bs.ResetBindings(false);
      this.gridControl1.DataSource = this.SqlServers;
      this.gridView1.RefreshData();
    }
    private void PopulateGridWithServers() {
      this.Hide();
      this.splash = Splash.ShowSplash();
      this.splash.Status = "Поиск SQL серверов в локальной сети.";
      GetSqlServersFromNetwork(true);
      //this.SqlServers = GetSqlServersFromNetwork(Debugger.IsAttached);
      this.splash.Status = "Уточнение информации об инстансах.";
      GetSqlStatus(this.SqlServers);
      this.splash.Status = "Инициализация формы.";
      RefreshGrid();
      this.splash.CloseSplash();


      this.Show();
      this.Focus();
      this.Activate();
    }

    private void Form1_Load(object sender, EventArgs e) {

    }

    private void GetSqlServersFromNetwork(bool test = false) {
      List<SqlInstance> sqlInstances = this.SqlServers;
      string output;
      using (Process proc = new Process()) {
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.FileName = "sqlcmd.exe";
        proc.StartInfo.Arguments = "-L";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        if (!test) proc.Start();
        output = test ? $"\r\nServers:\r\n FENIX\r\n FENIX\\EGRUL\r\n" : proc.StandardOutput.ReadToEnd();
      }
      string[] serversStrings = output.Replace("Servers:", "").Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
      foreach (string s in serversStrings) {
        string[] server = s.Split(new string[] { "\\" }, StringSplitOptions.None);
        if (server.Length > 1) sqlInstances.Add(new SqlInstance(server[0], server[1]));
        else {
          sqlInstances.Add(new SqlInstance(server[0]));
        }
      }
    }
    private void GetSqlStatus(List<SqlInstance> servers) {
      ServiceController sc;
      foreach (IGrouping<string, SqlInstance> server in servers.GroupBy(x => x.Host.FQDN)) {
        var srv = server.First();
        this.splash.Status = $"Обработка сервера '{srv.Host.FQDN}'";
        if (srv.Host.Domain?.ToLower() == "formulabi.local") {
          if (Helpers.PingHost(srv.Host.FQDN, 500, out IPStatus status)) {
            sc = new ServiceController();
            sc.MachineName = srv.Host.FQDN;

            foreach (SqlInstance service in server) {
              service.ServerStatus = status;
              sc.ServiceName = service.ServiceName;
              try {
                service.ServiceStatus = sc.Status;
                GetinstanceDetails(service);
              }
              catch (Exception e) {
                service.Info = e.Message;
              }
            }
          }
          else {
            foreach (SqlInstance service in server) {
              service.ServerStatus = status;
            }
          }
        }
      }
      this.gridView1.RefreshData();
      this.gridControl1.Refresh();
    }
    private SqlInstance GetinstanceDetails(SqlInstance service) {
      SqlInstance result = service;

      string ConnectionString = (service.InstanceName == "DEFAULT") ? $@"Server={service.Host.FQDN};Trusted_Connection=True;Connection Timeout=2;" : $@"Server={service.Host.FQDN}\{service.InstanceName};Trusted_Connection=True;Connection Timeout=2;";
      service.DatabasesSize = 0;
      if (service.ServiceStatus == ServiceControllerStatus.Running) {
        using (SqlConnection SqlConnection = new SqlConnection(ConnectionString)) {
          try {
            SqlConnection.Open();
            DataTable dtm = GetInstanceMemory(service, SqlConnection); DataTable dtd = GetInstanceDiskUsage(service, SqlConnection);
            service.ServerMemoryMax = int.Parse(dtm.Rows[0].ItemArray[1].ToString());
            service.ServerMemoryRunning = int.Parse(dtm.Rows[0].ItemArray[2].ToString());
            foreach (DataRow row in dtd.Rows) { service.DatabasesSize += int.Parse(row.ItemArray[1].ToString()); }
          }
          //catch (SqlException se) {
          //  //MessageBox.Show(se.Message);
          //  throw;
          //}
          catch (Exception e) {
            service.Info = e.Message;
          }
        }
      }
      else {
        service.ServerMemoryMax = 0;
        service.ServerMemoryRunning = 0;
      }
      return result;
    }
    private static DataTable GetInstanceMemory(SqlInstance service, SqlConnection SqlConnection) {
      string query = @"SELECT name, value, value_in_use, [description] 
                      FROM sys.configurations
                      WHERE name like '%max server memory%'";
      SqlCommand command = new SqlCommand(query, SqlConnection);
      DataTable dt = new DataTable();
      dt.Load(command.ExecuteReader());
      return dt;
    }
    private static DataTable GetInstanceDiskUsage(SqlInstance service, SqlConnection SqlConnection) {
      string query = @"SELECT d.name,
                ROUND(SUM(mf.size) * 8 / 1024, 0) Size_MBs
                FROM sys.master_files mf
                INNER JOIN sys.databases d ON d.database_id = mf.database_id
                WHERE d.database_id > 4 -- Skip system databases
                GROUP BY d.name";
      SqlCommand command = new SqlCommand(query, SqlConnection);
      DataTable dt = new DataTable();
      dt.Load(command.ExecuteReader());
      return dt;
    }
    private void buttonExit_Click(object sender, EventArgs e) {
      Close();
    }
    private void buttonRefresh_Click(object sender, EventArgs e) {
      this.splash = Splash.ShowSplash("Обновляем инфо по серверам");
      GetSqlStatus(this.SqlServers);
      RefreshGrid();
      this.splash.CloseSplash();
    }
    private void Form1_Shown(object sender, EventArgs e) {
      Show();
      Focus();
      BringToFront();
      Activate();
    }

    private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e) {
      if (sender is GridView gv) {
        this.SelectedInstance = (SqlInstance)gv.GetRow(e.RowHandle);
      }
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
      this.SelectedInstance = (SqlInstance)this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
      if (this.SelectedInstance == null) this.contextMenuStrip1.Hide();
      if (this.SelectedInstance?.ServiceStatus == ServiceControllerStatus.Running) {
        this.toolStripMenuItemStart.Enabled = false;
        this.toolStripMenuItemStop.Enabled = true;
      }
      else
      if (this.SelectedInstance?.ServiceStatus == ServiceControllerStatus.Stopped) {
        this.toolStripMenuItemStart.Enabled = true;
        this.toolStripMenuItemStop.Enabled = false;
      }
      else {
        this.toolStripMenuItemStart.Enabled = false;
        this.toolStripMenuItemStop.Enabled = false;
      }
    }

    private void buttonSave_Click(object sender, EventArgs e) {
      try {
        string[] json = JsonConvert.SerializeObject(this.SqlServers).Replace("{", "{" + Environment.NewLine)
          .Replace("}", Environment.NewLine + "}")
          //.Replace(",", "," + Environment.NewLine)
          .Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        System.IO.File.WriteAllLines("Servers.json", json);
      }
      catch (Exception exception) {
        Console.WriteLine(exception);
        throw;
      }
    }
    private void toolStripMenuItemStart_Click(object sender, EventArgs e) {
      StartService(this.SelectedInstance);
    }
    private void StopService(SqlInstance s) {
      if (s.Host.FQDN == null) return;
      var splash = Splash.ShowSplash($"Остановка сервиса {s.ServiceName} на компьютере {s.Host.FQDN}");
      splash.Status = "Подключаемся к компьютеру";
      ServiceController sc = new ServiceController(s.ServiceName, s.Host.FQDN);

      splash.Status = "Посылаем команду на остановку";
      sc.Stop();
      sc.WaitForStatus(ServiceControllerStatus.Stopped);
      s.ServiceStatus = sc.Status;
      splash.CloseSplash();
    }
    private void StartService(SqlInstance s) {
      if (s.Host.FQDN == null) return;
      var splash = Splash.ShowSplash($"Запуск сервиса {s.ServiceName} на компьютере {s.Host.FQDN}");
      splash.Status = "Подключаемся к компьютеру";
      ServiceController sc = new ServiceController(s.ServiceName, s.Host.FQDN);

      splash.Status = "Посылаем команду на запуск";
      sc.Start();
      sc.WaitForStatus(ServiceControllerStatus.Running);
      s.ServiceStatus = sc.Status;
      GetinstanceDetails(s);
      splash.CloseSplash();
    }

    private void toolStripMenuItemStop_Click(object sender, EventArgs e) {
      StopService(this.SelectedInstance);
    }

    private void buttonGetNetwork_Click(object sender, EventArgs e) {
      PopulateGridWithServers();
    }

    private void buttonLoad_Click(object sender, EventArgs e) {
      this.SqlServers = JsonConvert.DeserializeObject<List<SqlInstance>>(File.ReadAllText("Servers.json"));
      RefreshGrid();
    }
  }

  [Serializable]
  public class SqlInstance {
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
    public SqlInstance() { }
    public SqlInstance(string ServerName, string InstanceName = "DEFAULT") {
      this.Host = NS.Host.GetHostEntry(ServerName.Replace(" ", ""));
      this.InstanceName = InstanceName;
      this.ServiceName = this.InstanceName == "DEFAULT" ? "MSSQLSERVER" : "MSSQL$" + this.InstanceName;
    }

  }
}
