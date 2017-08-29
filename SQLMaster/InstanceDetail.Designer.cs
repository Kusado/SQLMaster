namespace SQLMaster {
  partial class InstanceDetail {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstanceDetail));
      this.gridControlDatabase = new DevExpress.XtraGrid.GridControl();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.shrinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openSSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.databaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.gridViewDatabase = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colFiles = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSizeFree = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSizeFreePercent = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLogFiles = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLogSize = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLogSizeFree = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLogSizeFreePercent = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colRecoveryModel = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colstate_desc = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLastBackupDate = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLastBackupSpan = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLastBackupLogDate = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLastBackupLogSpan = new DevExpress.XtraGrid.Columns.GridColumn();
      this.buttonExit = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabase)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabase)).BeginInit();
      this.SuspendLayout();
      // 
      // gridControlDatabase
      // 
      this.gridControlDatabase.ContextMenuStrip = this.contextMenuStrip1;
      this.gridControlDatabase.DataSource = this.databaseBindingSource;
      this.gridControlDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControlDatabase.Location = new System.Drawing.Point(0, 0);
      this.gridControlDatabase.MainView = this.gridViewDatabase;
      this.gridControlDatabase.Name = "gridControlDatabase";
      this.gridControlDatabase.Size = new System.Drawing.Size(1096, 366);
      this.gridControlDatabase.TabIndex = 0;
      this.gridControlDatabase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDatabase});
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shrinkToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.openSSMSToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(136, 70);
      this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
      // 
      // shrinkToolStripMenuItem
      // 
      this.shrinkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.logToolStripMenuItem});
      this.shrinkToolStripMenuItem.Name = "shrinkToolStripMenuItem";
      this.shrinkToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
      this.shrinkToolStripMenuItem.Text = "Shrink";
      // 
      // databaseToolStripMenuItem
      // 
      this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
      this.databaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.databaseToolStripMenuItem.Text = "Database";
      this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
      // 
      // logToolStripMenuItem
      // 
      this.logToolStripMenuItem.Name = "logToolStripMenuItem";
      this.logToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.logToolStripMenuItem.Text = "Log";
      this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
      // 
      // refreshToolStripMenuItem
      // 
      this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
      this.refreshToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
      this.refreshToolStripMenuItem.Text = "Refresh";
      this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
      // 
      // openSSMSToolStripMenuItem
      // 
      this.openSSMSToolStripMenuItem.Name = "openSSMSToolStripMenuItem";
      this.openSSMSToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
      this.openSSMSToolStripMenuItem.Text = "Open SSMS";
      this.openSSMSToolStripMenuItem.Click += new System.EventHandler(this.openSSMSToolStripMenuItem_Click);
      // 
      // databaseBindingSource
      // 
      this.databaseBindingSource.DataSource = typeof(SQLMaster.Database);
      // 
      // gridViewDatabase
      // 
      this.gridViewDatabase.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colOwner,
            this.colSize,
            this.colFiles,
            this.colSizeFree,
            this.colSizeFreePercent,
            this.colLogFiles,
            this.colLogSize,
            this.colLogSizeFree,
            this.colLogSizeFreePercent,
            this.colCreateDate,
            this.colRecoveryModel,
            this.colstate_desc,
            this.colLastBackupDate,
            this.colLastBackupSpan,
            this.colLastBackupLogDate,
            this.colLastBackupLogSpan});
      this.gridViewDatabase.GridControl = this.gridControlDatabase;
      this.gridViewDatabase.HorzScrollStep = 1;
      this.gridViewDatabase.Name = "gridViewDatabase";
      this.gridViewDatabase.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
      this.gridViewDatabase.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
      this.gridViewDatabase.OptionsBehavior.Editable = false;
      this.gridViewDatabase.OptionsDetail.EnableMasterViewMode = false;
      this.gridViewDatabase.OptionsSelection.MultiSelect = true;
      this.gridViewDatabase.OptionsView.ColumnAutoWidth = false;
      this.gridViewDatabase.OptionsView.ShowGroupPanel = false;
      // 
      // colID
      // 
      this.colID.FieldName = "ID";
      this.colID.Name = "colID";
      this.colID.Visible = true;
      this.colID.VisibleIndex = 0;
      // 
      // colName
      // 
      this.colName.FieldName = "Name";
      this.colName.Name = "colName";
      this.colName.Visible = true;
      this.colName.VisibleIndex = 1;
      // 
      // colOwner
      // 
      this.colOwner.FieldName = "Owner";
      this.colOwner.Name = "colOwner";
      this.colOwner.Visible = true;
      this.colOwner.VisibleIndex = 2;
      // 
      // colSize
      // 
      this.colSize.FieldName = "Size";
      this.colSize.Name = "colSize";
      this.colSize.Visible = true;
      this.colSize.VisibleIndex = 4;
      // 
      // colFiles
      // 
      this.colFiles.FieldName = "Files";
      this.colFiles.Name = "colFiles";
      this.colFiles.OptionsColumn.ReadOnly = true;
      this.colFiles.Visible = true;
      this.colFiles.VisibleIndex = 3;
      // 
      // colSizeFree
      // 
      this.colSizeFree.FieldName = "SizeFree";
      this.colSizeFree.Name = "colSizeFree";
      this.colSizeFree.Visible = true;
      this.colSizeFree.VisibleIndex = 5;
      // 
      // colSizeFreePercent
      // 
      this.colSizeFreePercent.FieldName = "SizeFreePercent";
      this.colSizeFreePercent.Name = "colSizeFreePercent";
      this.colSizeFreePercent.Visible = true;
      this.colSizeFreePercent.VisibleIndex = 6;
      // 
      // colLogFiles
      // 
      this.colLogFiles.FieldName = "LogFiles";
      this.colLogFiles.Name = "colLogFiles";
      this.colLogFiles.OptionsColumn.ReadOnly = true;
      this.colLogFiles.Visible = true;
      this.colLogFiles.VisibleIndex = 7;
      // 
      // colLogSize
      // 
      this.colLogSize.FieldName = "LogSize";
      this.colLogSize.Name = "colLogSize";
      this.colLogSize.Visible = true;
      this.colLogSize.VisibleIndex = 8;
      // 
      // colLogSizeFree
      // 
      this.colLogSizeFree.FieldName = "LogSizeFree";
      this.colLogSizeFree.Name = "colLogSizeFree";
      this.colLogSizeFree.Visible = true;
      this.colLogSizeFree.VisibleIndex = 9;
      // 
      // colLogSizeFreePercent
      // 
      this.colLogSizeFreePercent.FieldName = "LogSizeFreePercent";
      this.colLogSizeFreePercent.Name = "colLogSizeFreePercent";
      this.colLogSizeFreePercent.Visible = true;
      this.colLogSizeFreePercent.VisibleIndex = 10;
      // 
      // colCreateDate
      // 
      this.colCreateDate.FieldName = "CreateDate";
      this.colCreateDate.Name = "colCreateDate";
      this.colCreateDate.Visible = true;
      this.colCreateDate.VisibleIndex = 11;
      // 
      // colRecoveryModel
      // 
      this.colRecoveryModel.FieldName = "RecoveryModel";
      this.colRecoveryModel.Name = "colRecoveryModel";
      this.colRecoveryModel.Visible = true;
      this.colRecoveryModel.VisibleIndex = 12;
      // 
      // colstate_desc
      // 
      this.colstate_desc.FieldName = "state_desc";
      this.colstate_desc.Name = "colstate_desc";
      this.colstate_desc.Visible = true;
      this.colstate_desc.VisibleIndex = 13;
      // 
      // colLastBackupDate
      // 
      this.colLastBackupDate.FieldName = "LastBackupDate";
      this.colLastBackupDate.Name = "colLastBackupDate";
      this.colLastBackupDate.Visible = true;
      this.colLastBackupDate.VisibleIndex = 14;
      // 
      // colLastBackupSpan
      // 
      this.colLastBackupSpan.FieldName = "LastBackupSpan";
      this.colLastBackupSpan.Name = "colLastBackupSpan";
      this.colLastBackupSpan.Visible = true;
      this.colLastBackupSpan.VisibleIndex = 15;
      // 
      // colLastBackupLogDate
      // 
      this.colLastBackupLogDate.FieldName = "LastBackupLogDate";
      this.colLastBackupLogDate.Name = "colLastBackupLogDate";
      this.colLastBackupLogDate.Visible = true;
      this.colLastBackupLogDate.VisibleIndex = 16;
      // 
      // colLastBackupLogSpan
      // 
      this.colLastBackupLogSpan.FieldName = "LastBackupLogSpan";
      this.colLastBackupLogSpan.Name = "colLastBackupLogSpan";
      this.colLastBackupLogSpan.Visible = true;
      this.colLastBackupLogSpan.VisibleIndex = 17;
      // 
      // buttonExit
      // 
      this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonExit.Location = new System.Drawing.Point(-50, -50);
      this.buttonExit.Name = "buttonExit";
      this.buttonExit.Size = new System.Drawing.Size(75, 23);
      this.buttonExit.TabIndex = 1;
      this.buttonExit.TabStop = false;
      this.buttonExit.Text = "Exit";
      this.buttonExit.UseVisualStyleBackColor = true;
      this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
      // 
      // InstanceDetail
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonExit;
      this.ClientSize = new System.Drawing.Size(1096, 366);
      this.Controls.Add(this.buttonExit);
      this.Controls.Add(this.gridControlDatabase);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "InstanceDetail";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "InstanceDetail";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstanceDetail_FormClosing);
      this.Load += new System.EventHandler(this.InstanceDetail_Load);
      this.Shown += new System.EventHandler(this.InstanceDetail_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabase)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabase)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControlDatabase;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewDatabase;
    private System.Windows.Forms.BindingSource databaseBindingSource;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem shrinkToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openSSMSToolStripMenuItem;
    private DevExpress.XtraGrid.Columns.GridColumn colID;
    private DevExpress.XtraGrid.Columns.GridColumn colName;
    private DevExpress.XtraGrid.Columns.GridColumn colOwner;
    private DevExpress.XtraGrid.Columns.GridColumn colSize;
    private DevExpress.XtraGrid.Columns.GridColumn colFiles;
    private DevExpress.XtraGrid.Columns.GridColumn colSizeFree;
    private DevExpress.XtraGrid.Columns.GridColumn colSizeFreePercent;
    private DevExpress.XtraGrid.Columns.GridColumn colLogFiles;
    private DevExpress.XtraGrid.Columns.GridColumn colLogSize;
    private DevExpress.XtraGrid.Columns.GridColumn colLogSizeFree;
    private DevExpress.XtraGrid.Columns.GridColumn colLogSizeFreePercent;
    private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
    private DevExpress.XtraGrid.Columns.GridColumn colRecoveryModel;
    private DevExpress.XtraGrid.Columns.GridColumn colstate_desc;
    private DevExpress.XtraGrid.Columns.GridColumn colLastBackupDate;
    private DevExpress.XtraGrid.Columns.GridColumn colLastBackupSpan;
    private DevExpress.XtraGrid.Columns.GridColumn colLastBackupLogDate;
    private DevExpress.XtraGrid.Columns.GridColumn colLastBackupLogSpan;
    private System.Windows.Forms.Button buttonExit;
  }
}