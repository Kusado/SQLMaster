using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using Helpers;

namespace SQLMaster {
  public partial class InstanceDetail : Form {
    private Database _selectedDatabase;
    private readonly SqlConnection Connection;
    private readonly SqlInstance Instance;
    private readonly Splash splash;

    public InstanceDetail(SqlInstance Instance, Splash splash) {
      this.splash = splash;
      InitializeComponent();

      this.Instance = Instance;
      this.Instance.Databases = new List<Database>();
      this.gridControlDatabase.DataSource = this.Instance.Databases;
      this.Instance = Instance;


      this.Connection = new SqlConnection(this.Instance.ConnectionString);

      this.splash.Status = "Открываем подключение.";
      this.Connection.Open();
    }

    private void InstanceDetail_Load(object sender, EventArgs e) {
      this.Text = this.Instance.ToString();
      this.Instance.GetDatabases(this.Connection);
      foreach (Database database in this.Instance.Databases) {
        //Заполним размеры файлов
        this.splash.Status = $"Считаем файлы базы {database.Name}";
        database.GetFilesSize(this.Connection);
        //Заполним даты последних бекапов
        this.splash.Status = $"Ищем бекапы базы {database.Name}";
        GetBackupInfo(database);
      }
    }

    private void GetBackupInfo(Database database) {
      Database tmp = database.GetBackupInfo(this.Connection, out bool backup, out bool log);
      if (backup) {
        database.LastBackupDate = tmp.LastBackupDate;
        database.LastBackupSpan = tmp.LastBackupSpan;
        if (log) {
          database.LastBackupLogDate = tmp.LastBackupLogDate;
          database.LastBackupLogSpan = tmp.LastBackupLogSpan;
        }
      }
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
      this._selectedDatabase = (Database) this.gridViewDatabase.GetFocusedRow();
    }

    private void InstanceDetail_FormClosing(object sender, FormClosingEventArgs e) { this.Connection?.Close(); }

    private void databaseToolStripMenuItem_Click(object sender, EventArgs e) {
      this._selectedDatabase.ShrinkFiles(this.Connection, true);
      this.gridViewDatabase.RefreshData();
    }

    private void logToolStripMenuItem_Click(object sender, EventArgs e) {
      this._selectedDatabase.ShrinkFiles(this.Connection, log: true);
      this.gridViewDatabase.RefreshData();
    }

    private void InstanceDetail_Shown(object sender, EventArgs e) { this.splash?.CloseSplash(); }

    private void refreshToolStripMenuItem_Click(object sender, EventArgs e) {
      Cursor cur = this.Cursor;

      this.Cursor = Cursors.WaitCursor;
      this.Connection.Close();
      this.Connection.Open();
      InstanceDetail_Load(sender, e);
      this.gridViewDatabase.RefreshData();
      this.Cursor = cur;
    }

    private void openSSMSToolStripMenuItem_Click(object sender, EventArgs e) {
      this.Instance.OpenSSMS(this._selectedDatabase.Name);
    }
  }
}