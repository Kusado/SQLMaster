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
      this.gridControlDatabase = new DevExpress.XtraGrid.GridControl();
      this.databaseBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.gridViewDatabase = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.unboundSource1 = new DevExpress.Data.UnboundSource(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.shrinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colOwner = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSize = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSizeFree = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSizeFreePercent = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colLogFileName = new DevExpress.XtraGrid.Columns.GridColumn();
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
      ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabase)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabase)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.unboundSource1)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // gridControlDatabase
      // 
      this.gridControlDatabase.DataSource = this.databaseBindingSource;
      this.gridControlDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControlDatabase.Location = new System.Drawing.Point(0, 0);
      this.gridControlDatabase.MainView = this.gridViewDatabase;
      this.gridControlDatabase.Name = "gridControlDatabase";
      this.gridControlDatabase.Size = new System.Drawing.Size(650, 366);
      this.gridControlDatabase.TabIndex = 0;
      this.gridControlDatabase.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDatabase});
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
            this.colFileName,
            this.colSize,
            this.colSizeFree,
            this.colSizeFreePercent,
            this.colLogFileName,
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
      this.gridViewDatabase.OptionsView.ColumnAutoWidth = false;
      this.gridViewDatabase.OptionsView.ShowGroupPanel = false;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shrinkToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
      this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
      // 
      // shrinkToolStripMenuItem
      // 
      this.shrinkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.logToolStripMenuItem});
      this.shrinkToolStripMenuItem.Name = "shrinkToolStripMenuItem";
      this.shrinkToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.shrinkToolStripMenuItem.Text = "Shrink";
      // 
      // databaseToolStripMenuItem
      // 
      this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
      this.databaseToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.databaseToolStripMenuItem.Text = "Database";
      // 
      // logToolStripMenuItem
      // 
      this.logToolStripMenuItem.Name = "logToolStripMenuItem";
      this.logToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.logToolStripMenuItem.Text = "Log";
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
      // colFileName
      // 
      this.colFileName.FieldName = "FileName";
      this.colFileName.Name = "colFileName";
      this.colFileName.Visible = true;
      this.colFileName.VisibleIndex = 3;
      // 
      // colSize
      // 
      this.colSize.FieldName = "Size";
      this.colSize.Name = "colSize";
      this.colSize.Visible = true;
      this.colSize.VisibleIndex = 4;
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
      // colLogFileName
      // 
      this.colLogFileName.FieldName = "LogFileName";
      this.colLogFileName.Name = "colLogFileName";
      this.colLogFileName.Visible = true;
      this.colLogFileName.VisibleIndex = 7;
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
      // InstanceDetail
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(650, 366);
      this.Controls.Add(this.gridControlDatabase);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InstanceDetail";
      this.ShowIcon = false;
      this.Text = "InstanceDetail";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InstanceDetail_FormClosing);
      this.Load += new System.EventHandler(this.InstanceDetail_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabase)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.databaseBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabase)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.unboundSource1)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControlDatabase;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewDatabase;
    private DevExpress.Data.UnboundSource unboundSource1;
    private System.Windows.Forms.BindingSource databaseBindingSource;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem shrinkToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
    private DevExpress.XtraGrid.Columns.GridColumn colID;
    private DevExpress.XtraGrid.Columns.GridColumn colName;
    private DevExpress.XtraGrid.Columns.GridColumn colOwner;
    private DevExpress.XtraGrid.Columns.GridColumn colFileName;
    private DevExpress.XtraGrid.Columns.GridColumn colSize;
    private DevExpress.XtraGrid.Columns.GridColumn colSizeFree;
    private DevExpress.XtraGrid.Columns.GridColumn colSizeFreePercent;
    private DevExpress.XtraGrid.Columns.GridColumn colLogFileName;
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
  }
}