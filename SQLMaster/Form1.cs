using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Helpers;
using Newtonsoft.Json;

namespace SQLMaster {
  public partial class Form1 : Form {
    private readonly string SaveFilePath;
    private Splash splash;
    private List<SqlInstance> SqlServers = new List<SqlInstance>();

    public Form1(string SaveFile = "Servers.json") {
      InitializeComponent();
      this.SaveFilePath = SaveFile;

      this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
      this.gridControl1.DataSource = this.SqlServers;
    }

    private SqlInstance SelectedInstance { get; set; }

    private void RefreshGrid() {
      this.gridControl1.DataSource = this.SqlServers;
      this.gridView1.RefreshData();
    }

    private void PopulateGridWithServers() {
      this.Enabled = false;
      this.splash = Splash.ShowSplash();
      this.splash.Status = "Поиск SQL серверов в локальной сети.";
      var tmpList = GetSqlServersFromNetwork();
      this.splash.Status = "Уточнение информации об инстансах.";
      GetSqlStatus(tmpList);

      foreach (SqlInstance srv in tmpList) {
        if (this.SqlServers.Where(x => x.Host.FQDN == srv.Host.FQDN).Any(y => y.ServiceName == srv.ServiceName)) {
          SqlInstance Element =
            this.SqlServers.Where(x => x.Host.FQDN == srv.Host.FQDN).First(y => y.ServiceName == srv.ServiceName);
          string Description = Element.Description;
          this.SqlServers.Remove(Element);
          srv.Description = Description;
          Element.Info = Description;
        }
        this.SqlServers.Add(srv);
      }

      var tmpList1 = LoadFromFile();
      if (tmpList1 != null && tmpList1.Any())
        foreach (SqlInstance instance in this.SqlServers) {
          SqlInstance tmp =
            tmpList.Where(x => x.Host.FQDN == instance.Host.FQDN)
                   .FirstOrDefault(y => y.ServiceName == instance.ServiceName);
          if (tmp != null) instance.Description = tmp.Description;
        }

      this.splash.Status = "Инициализация формы.";
      RefreshGrid();
      this.splash.CloseSplash();
      this.Enabled = true;
      Show();
      Focus();
      Activate();
    }

    private void Form1_Load(object sender, EventArgs e) {
      this.gridView1.ExpandAllGroups();
    }

    private List<SqlInstance> GetSqlServersFromNetwork(bool test = false) {
#if NoSearch
      test = true;
#endif
      var sqlInstances = new List<SqlInstance>();
      string output;
      using (Process proc = new Process()) {
        proc.StartInfo.CreateNoWindow = true;
        proc.StartInfo.FileName = "sqlcmd.exe";
        proc.StartInfo.Arguments = "-L";
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        if (!test) proc.Start();
        output = test ? $"\r\nServers:\r\n FENIX\r\n FENIX\\EGRUL\r\n URAN\\RN\r\n" : proc.StandardOutput.ReadToEnd();
      }
      var serversStrings = output.Replace("Servers:", "")
                                 .Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
      foreach (string s in serversStrings) {
        var server = s.Split(new[] {"\\"}, StringSplitOptions.None);
        SqlInstance temp = server.Length > 1 ? new SqlInstance(server[0], server[1]) : new SqlInstance(server[0]);
        if (temp.Host != null) sqlInstances.Add(temp);
      }

      return sqlInstances;
    }

    private void GetSqlStatus(List<SqlInstance> instances) {
      Parallel.ForEach(instances.GroupBy(x => x.Host.FQDN),
                       server => {
                         SqlInstance srv = server.First();
                         this.splash.Status = $"Обработка сервера '{srv.Host.FQDN}'";
                         //if (srv.Host.Domain?.ToLower() == "formulabi.local") {
                         if (Helpers.PingHost(srv.Host.FQDN, 500, out IPStatus status)) {
                           ServiceController sc = new ServiceController {MachineName = srv.Host.FQDN};

                           foreach (SqlInstance instance in server) {
                             instance.ServerStatus = status;
                             sc.ServiceName = instance.ServiceName;
                             try {
                               instance.ServiceStatus = sc.Status;

                               //GetinstanceDetails(service);
                             }
                             catch (InvalidOperationException invalidOperationException) {
                               instance.AbleToConnect = false;
                               instance.Info = $"Ошибка подключения: {invalidOperationException.Message}";
                               Debug.WriteLine(invalidOperationException.Message);
                               if (invalidOperationException.InnerException != null) {
                                 instance.Info += $": {invalidOperationException.InnerException.Message}";
                                 Debug.WriteLine(invalidOperationException.InnerException.Message);
                               }
                             }
                             catch (Exception e) {
                               instance.AbleToConnect = false;
                               instance.Info = e.Message;
                             }
                           }
                         }
                         else {
                           foreach (SqlInstance instance in server) {
                             instance.AbleToConnect = false;
                             instance.ServerStatus = status;
                           }
                         }
                       });

      this.splash.Status = "Достаём инфу по инстансам";
      Parallel.ForEach(instances, instance => GetinstanceDetails(instance));
    }

    private SqlInstance GetinstanceDetails(SqlInstance instance) {
      SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
        DataSource = instance.InstanceName == "DEFAULT"
                       ? $"{instance.Host.FQDN}"
                       : $"{instance.Host.FQDN}\\{instance.InstanceName}",
        IntegratedSecurity = true,
        ConnectTimeout = 2,
        ConnectRetryCount = 10,
        ConnectRetryInterval = 2,
        MultipleActiveResultSets = true
      };
      instance.ConnectionString = builder.ConnectionString;
      instance.DatabasesSize = 0;
      if (instance.ServiceStatus == ServiceControllerStatus.Running) {
        using (SqlConnection SqlConnection = new SqlConnection(instance.ConnectionString)) {
          try {
            SqlConnection.Open();
            DataTable dtm = GetInstanceMemory(SqlConnection);
            if (GetInstanceDiskUsage(SqlConnection, out DataTable dtd))
              foreach (DataRow row in dtd.Rows) instance.DatabasesSize += int.Parse(row.ItemArray[1].ToString());

            instance.ServerMemoryMax = int.Parse(dtm.Rows[0].ItemArray[1].ToString());
            instance.ServerMemoryRunning = int.Parse(dtm.Rows[0].ItemArray[2].ToString());
            instance.AbleToConnect = true;
          }
          catch (SqlException sqlException) {
            instance.AbleToConnect = false;
            switch (sqlException.Number) {
              case 18456:
                instance.Info = $"Ошибка авторизации: {sqlException.Message}";
                break;
              case -1:
                instance.Info = $"Ошибка подключения: {sqlException.Message}";
                break;
              default:
                Debug.WriteLine(sqlException.Message);
                MessageBox.Show(sqlException.Message);
                break;
            }
          }
          catch (Exception) {
            instance.AbleToConnect = false;
            throw;
          }
        }
      }
      else {
        instance.ServerMemoryMax = 0;
        instance.ServerMemoryRunning = 0;
      }

      return instance;
    }

    private static DataTable GetInstanceMemory(SqlConnection SqlConnection) {
      string query = @"SELECT name, value, value_in_use, [description]
                      FROM sys.configurations
                      WHERE name like '%max server memory%'";
      SqlCommand command = new SqlCommand(query, SqlConnection);
      DataTable dt = new DataTable();
      dt.Load(command.ExecuteReader());
      return dt;
    }

    private bool GetInstanceDiskUsage(SqlConnection SqlConnection, out DataTable dt) {
      string query = @"SELECT d.name,
                ROUND(SUM(mf.size) * 8 / 1024, 0) Size_MBs
                FROM sys.master_files mf
                INNER JOIN sys.databases d ON d.database_id = mf.database_id
                WHERE d.database_id > 4 -- Skip system databases
                GROUP BY d.name";
      SqlCommand command = new SqlCommand(query, SqlConnection);
      dt = new DataTable();
      dt.Load(command.ExecuteReader());
      return dt.Rows.Count > 0;
    }

    private void buttonExit_Click(object sender, EventArgs e) { Close(); }

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

    private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e) {
      if (sender is GridView gv) this.SelectedInstance = (SqlInstance) gv.GetRow(e.RowHandle);
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
      this.SelectedInstance = (SqlInstance) this.gridView1.GetRow(this.gridView1.FocusedRowHandle);
      if (this.SelectedInstance == null) this.contextMenuStrip1.Hide();
      if (this.SelectedInstance?.ServiceStatus == ServiceControllerStatus.Running) {
        this.toolStripMenuItemStart.Enabled = false;
        this.toolStripMenuItemStop.Enabled = true;
      }
      else if (this.SelectedInstance?.ServiceStatus == ServiceControllerStatus.Stopped) {
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
        var json = JsonConvert.SerializeObject(this.SqlServers).Replace("{", "{" + Environment.NewLine)
                              .Replace("}", Environment.NewLine + "}")
                              //.Replace(",", "," + Environment.NewLine)
                              .Split(new[] {Environment.NewLine}, StringSplitOptions.None);
        File.WriteAllLines(this.SaveFilePath, json);
      }
      catch (Exception exception) {
        Console.WriteLine(exception);
        throw;
      }
    }

    private void toolStripMenuItemStart_Click(object sender, EventArgs e) { StartService(this.SelectedInstance); }

    private void StopService(SqlInstance s) {
      if (s.Host.FQDN == null) return;

      Splash splash = Splash.ShowSplash($"Остановка сервиса {s.ServiceName} на компьютере {s.Host.FQDN}");
      splash.Status = "Подключаемся к компьютеру";
      ServiceController sc = new ServiceController(s.ServiceName, s.Host.FQDN);

      splash.Status = "Посылаем команду на остановку";
      sc.Stop();
      sc.WaitForStatus(ServiceControllerStatus.Stopped);
      s.ServiceStatus = sc.Status;
      splash.CloseSplash();
      RefreshGrid();
    }

    private void StartService(SqlInstance s) {
      if (s.Host.FQDN == null) return;

      Splash splash = Splash.ShowSplash($"Запуск сервиса {s.ServiceName} на компьютере {s.Host.FQDN}");
      splash.Status = "Подключаемся к компьютеру";
      ServiceController sc = new ServiceController(s.ServiceName, s.Host.FQDN);

      splash.Status = "Посылаем команду на запуск";
      sc.Start();
      sc.WaitForStatus(ServiceControllerStatus.Running);
      s.ServiceStatus = sc.Status;
      GetinstanceDetails(s);
      RefreshGrid();
      splash.CloseSplash();
    }

    private void toolStripMenuItemStop_Click(object sender, EventArgs e) { StopService(this.SelectedInstance); }

    private void buttonGetNetwork_Click(object sender, EventArgs e) { PopulateGridWithServers(); }

    private void buttonLoad_Click(object sender, EventArgs e) {
      this.SqlServers = LoadFromFile();
      RefreshGrid();
    }

    private List<SqlInstance> LoadFromFile() {
      if (!File.Exists(this.SaveFilePath)) return null;

      var result = new List<SqlInstance>();
      try {
        result = JsonConvert.DeserializeObject<List<SqlInstance>>(File.ReadAllText(this.SaveFilePath));
      }
      catch (Exception e) {
        Console.WriteLine(e);
        throw;
      }

      return result;
    }

    private void connectSMSSToolStripMenuItem_Click(object sender, EventArgs e) { this.SelectedInstance.OpenSSMS(); }

    private void gridView1_DoubleClick(object sender, EventArgs e) {
      if (this.SelectedInstance == null
          || this.SelectedInstance.ServerStatus != IPStatus.Success
          || this.SelectedInstance.ServiceStatus != ServiceControllerStatus.Running
      ) return;

      Hide();
      Splash s = Splash.ShowSplash("Достаём инфу по базам инстанса.");
      InstanceDetail instanceDetail = new InstanceDetail(this.SelectedInstance, s);
      instanceDetail.ShowDialog();
      Show();
    }
  }
}