using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLMaster {
  public partial class InstanceDetail : Form {
    private SqlConnection Connection;
    private SqlInstance Instance;
    private Task ConnectionOpener;
    private Database _selectedDatabase;

    public InstanceDetail(SqlInstance Instance) {
      InitializeComponent();
      this.Instance = Instance;
      this.Instance.Databases = new List<Database>();
      this.gridControlDatabase.DataSource = this.Instance.Databases;
      this.Instance = Instance;
      this.Connection = new SqlConnection(this.Instance.ConnectionString);
      this.Connection.Open();
    }

    private void InstanceDetail_Load(object sender, EventArgs e) {
      this.Instance.GetDatabases(this.Connection);
      foreach (Database database in this.Instance.Databases) {
        //Заполним размеры файлов
        database.GetFilesSize(this.Connection);
        //Заполним даты последних бекапов
        var tmp = this.Instance.GetBackupInfo(database, this.Connection, out bool backup, out bool log);
        if (backup) {
          database.LastBackupDate = tmp.LastBackupDate;
          database.LastBackupSpan = tmp.LastBackupSpan;
          if (log) {
            database.LastBackupLogDate = tmp.LastBackupLogDate;
            database.LastBackupLogSpan = tmp.LastBackupLogSpan;
          }
        }

      }
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e) {
      this._selectedDatabase = (Database)this.gridViewDatabase.GetFocusedRow();
    }

    private void InstanceDetail_FormClosing(object sender, FormClosingEventArgs e) {
      this.Connection?.Close();
    }
  }
}
