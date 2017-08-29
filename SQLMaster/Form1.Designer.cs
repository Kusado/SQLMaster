namespace SQLMaster {
  partial class Form1 {
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
      DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression1 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
      DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
      DevExpress.XtraEditors.FormatConditionRuleExpression formatConditionRuleExpression2 = new DevExpress.XtraEditors.FormatConditionRuleExpression();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.gridControl1 = new DevExpress.XtraGrid.GridControl();
      this.sqlInstanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colHost = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colServerStatus = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colInstanceName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colServiceStatus = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colServerMemoryRunning = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colServerMemoryMax = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colDatabasesSize = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colInfo = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colAbleToConnect = new DevExpress.XtraGrid.Columns.GridColumn();
      this.buttonExit = new System.Windows.Forms.Button();
      this.buttonRefresh = new System.Windows.Forms.Button();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.toolStripMenuItemStart = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItemStop = new System.Windows.Forms.ToolStripMenuItem();
      this.connectSMSSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.buttonSave = new System.Windows.Forms.Button();
      this.buttonLoad = new System.Windows.Forms.Button();
      this.buttonGetNetwork = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.sqlInstanceBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // gridControl1
      // 
      this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gridControl1.DataSource = this.sqlInstanceBindingSource;
      this.gridControl1.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.End;
      this.gridControl1.Location = new System.Drawing.Point(0, 0);
      this.gridControl1.MainView = this.gridView1;
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.Size = new System.Drawing.Size(890, 362);
      this.gridControl1.TabIndex = 0;
      this.gridControl1.UseEmbeddedNavigator = true;
      this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
      // 
      // sqlInstanceBindingSource
      // 
      this.sqlInstanceBindingSource.DataSource = typeof(SQLMaster.SqlInstance);
      // 
      // gridView1
      // 
      this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHost,
            this.colServerStatus,
            this.colInstanceName,
            this.colServiceName,
            this.colServiceStatus,
            this.colServerMemoryRunning,
            this.colServerMemoryMax,
            this.colDatabasesSize,
            this.colInfo,
            this.colDescription,
            this.colAbleToConnect});
      gridFormatRule1.ApplyToRow = true;
      gridFormatRule1.Name = "Format0";
      formatConditionRuleExpression1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
      formatConditionRuleExpression1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      formatConditionRuleExpression1.Appearance.Options.UseBackColor = true;
      formatConditionRuleExpression1.Expression = "Not [AbleToConnect]";
      gridFormatRule1.Rule = formatConditionRuleExpression1;
      gridFormatRule2.ApplyToRow = true;
      gridFormatRule2.Name = "Format1";
      formatConditionRuleExpression2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      formatConditionRuleExpression2.Appearance.BackColor2 = System.Drawing.Color.White;
      formatConditionRuleExpression2.Appearance.Options.UseBackColor = true;
      formatConditionRuleExpression2.Expression = "[AbleToConnect]";
      gridFormatRule2.Rule = formatConditionRuleExpression2;
      this.gridView1.FormatRules.Add(gridFormatRule1);
      this.gridView1.FormatRules.Add(gridFormatRule2);
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
      this.gridView1.OptionsDetail.EnableMasterViewMode = false;
      this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
      this.gridView1.OptionsView.ColumnAutoWidth = false;
      this.gridView1.OptionsView.ShowAutoFilterRow = true;
      this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
      this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
      this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
      // 
      // colHost
      // 
      this.colHost.FieldName = "Host.FQDN";
      this.colHost.Name = "colHost";
      this.colHost.OptionsColumn.AllowEdit = false;
      this.colHost.OptionsColumn.TabStop = false;
      this.colHost.Visible = true;
      this.colHost.VisibleIndex = 0;
      this.colHost.Width = 102;
      // 
      // colServerStatus
      // 
      this.colServerStatus.FieldName = "ServerStatus";
      this.colServerStatus.Name = "colServerStatus";
      this.colServerStatus.OptionsColumn.AllowEdit = false;
      this.colServerStatus.OptionsColumn.TabStop = false;
      this.colServerStatus.Visible = true;
      this.colServerStatus.VisibleIndex = 1;
      // 
      // colInstanceName
      // 
      this.colInstanceName.FieldName = "InstanceName";
      this.colInstanceName.Name = "colInstanceName";
      this.colInstanceName.OptionsColumn.AllowEdit = false;
      this.colInstanceName.OptionsColumn.TabStop = false;
      this.colInstanceName.Visible = true;
      this.colInstanceName.VisibleIndex = 2;
      // 
      // colServiceName
      // 
      this.colServiceName.FieldName = "ServiceName";
      this.colServiceName.Name = "colServiceName";
      this.colServiceName.OptionsColumn.AllowEdit = false;
      this.colServiceName.OptionsColumn.TabStop = false;
      this.colServiceName.Visible = true;
      this.colServiceName.VisibleIndex = 3;
      // 
      // colServiceStatus
      // 
      this.colServiceStatus.FieldName = "ServiceStatus";
      this.colServiceStatus.Name = "colServiceStatus";
      this.colServiceStatus.OptionsColumn.AllowEdit = false;
      this.colServiceStatus.OptionsColumn.TabStop = false;
      this.colServiceStatus.Visible = true;
      this.colServiceStatus.VisibleIndex = 8;
      this.colServiceStatus.Width = 82;
      // 
      // colServerMemoryRunning
      // 
      this.colServerMemoryRunning.FieldName = "ServerMemoryRunning";
      this.colServerMemoryRunning.Name = "colServerMemoryRunning";
      this.colServerMemoryRunning.OptionsColumn.AllowEdit = false;
      this.colServerMemoryRunning.OptionsColumn.TabStop = false;
      this.colServerMemoryRunning.Visible = true;
      this.colServerMemoryRunning.VisibleIndex = 4;
      // 
      // colServerMemoryMax
      // 
      this.colServerMemoryMax.FieldName = "ServerMemoryMax";
      this.colServerMemoryMax.Name = "colServerMemoryMax";
      this.colServerMemoryMax.OptionsColumn.AllowEdit = false;
      this.colServerMemoryMax.OptionsColumn.TabStop = false;
      // 
      // colDatabasesSize
      // 
      this.colDatabasesSize.FieldName = "DatabasesSize";
      this.colDatabasesSize.Name = "colDatabasesSize";
      this.colDatabasesSize.OptionsColumn.AllowEdit = false;
      this.colDatabasesSize.OptionsColumn.TabStop = false;
      this.colDatabasesSize.Visible = true;
      this.colDatabasesSize.VisibleIndex = 5;
      // 
      // colInfo
      // 
      this.colInfo.FieldName = "Info";
      this.colInfo.Name = "colInfo";
      this.colInfo.OptionsColumn.AllowEdit = false;
      this.colInfo.OptionsColumn.TabStop = false;
      this.colInfo.Visible = true;
      this.colInfo.VisibleIndex = 6;
      this.colInfo.Width = 107;
      // 
      // colDescription
      // 
      this.colDescription.FieldName = "Description";
      this.colDescription.Name = "colDescription";
      this.colDescription.Visible = true;
      this.colDescription.VisibleIndex = 7;
      this.colDescription.Width = 117;
      // 
      // colAbleToConnect
      // 
      this.colAbleToConnect.FieldName = "AbleToConnect";
      this.colAbleToConnect.Name = "colAbleToConnect";
      this.colAbleToConnect.OptionsColumn.AllowEdit = false;
      this.colAbleToConnect.OptionsColumn.TabStop = false;
      this.colAbleToConnect.Visible = true;
      this.colAbleToConnect.VisibleIndex = 9;
      // 
      // buttonExit
      // 
      this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonExit.Location = new System.Drawing.Point(803, 368);
      this.buttonExit.Name = "buttonExit";
      this.buttonExit.Size = new System.Drawing.Size(75, 23);
      this.buttonExit.TabIndex = 1;
      this.buttonExit.Text = "E&xit";
      this.buttonExit.UseVisualStyleBackColor = true;
      this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
      // 
      // buttonRefresh
      // 
      this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.buttonRefresh.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonRefresh.Location = new System.Drawing.Point(12, 368);
      this.buttonRefresh.Name = "buttonRefresh";
      this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
      this.buttonRefresh.TabIndex = 2;
      this.buttonRefresh.Text = "&Refresh";
      this.buttonRefresh.UseVisualStyleBackColor = true;
      this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemStart,
            this.toolStripMenuItemStop,
            this.connectSMSSToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.contextMenuStrip1.Size = new System.Drawing.Size(152, 70);
      this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
      // 
      // toolStripMenuItemStart
      // 
      this.toolStripMenuItemStart.Name = "toolStripMenuItemStart";
      this.toolStripMenuItemStart.Size = new System.Drawing.Size(151, 22);
      this.toolStripMenuItemStart.Text = "Start";
      this.toolStripMenuItemStart.Click += new System.EventHandler(this.toolStripMenuItemStart_Click);
      // 
      // toolStripMenuItemStop
      // 
      this.toolStripMenuItemStop.Name = "toolStripMenuItemStop";
      this.toolStripMenuItemStop.Size = new System.Drawing.Size(151, 22);
      this.toolStripMenuItemStop.Text = "Stop";
      this.toolStripMenuItemStop.Click += new System.EventHandler(this.toolStripMenuItemStop_Click);
      // 
      // connectSMSSToolStripMenuItem
      // 
      this.connectSMSSToolStripMenuItem.Name = "connectSMSSToolStripMenuItem";
      this.connectSMSSToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
      this.connectSMSSToolStripMenuItem.Text = "Connect SMSS";
      this.connectSMSSToolStripMenuItem.Click += new System.EventHandler(this.connectSMSSToolStripMenuItem_Click);
      // 
      // buttonSave
      // 
      this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonSave.Location = new System.Drawing.Point(722, 368);
      this.buttonSave.Name = "buttonSave";
      this.buttonSave.Size = new System.Drawing.Size(75, 23);
      this.buttonSave.TabIndex = 3;
      this.buttonSave.Text = "&Save";
      this.buttonSave.UseVisualStyleBackColor = true;
      this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
      // 
      // buttonLoad
      // 
      this.buttonLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonLoad.Location = new System.Drawing.Point(641, 368);
      this.buttonLoad.Name = "buttonLoad";
      this.buttonLoad.Size = new System.Drawing.Size(75, 23);
      this.buttonLoad.TabIndex = 4;
      this.buttonLoad.Text = "&Load";
      this.buttonLoad.UseVisualStyleBackColor = true;
      this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
      // 
      // buttonGetNetwork
      // 
      this.buttonGetNetwork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.buttonGetNetwork.Location = new System.Drawing.Point(93, 368);
      this.buttonGetNetwork.Name = "buttonGetNetwork";
      this.buttonGetNetwork.Size = new System.Drawing.Size(133, 23);
      this.buttonGetNetwork.TabIndex = 5;
      this.buttonGetNetwork.Text = "GetServersFrom&Network";
      this.buttonGetNetwork.UseVisualStyleBackColor = true;
      this.buttonGetNetwork.Click += new System.EventHandler(this.buttonGetNetwork_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonExit;
      this.ClientSize = new System.Drawing.Size(890, 403);
      this.Controls.Add(this.buttonGetNetwork);
      this.Controls.Add(this.buttonLoad);
      this.Controls.Add(this.buttonSave);
      this.Controls.Add(this.buttonRefresh);
      this.Controls.Add(this.buttonExit);
      this.Controls.Add(this.gridControl1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "FbiSqlServers";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.Shown += new System.EventHandler(this.Form1_Shown);
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.sqlInstanceBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private System.Windows.Forms.Button buttonExit;
    private System.Windows.Forms.Button buttonRefresh;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStart;
    private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStop;
    private System.Windows.Forms.Button buttonSave;
    private System.Windows.Forms.BindingSource sqlInstanceBindingSource;
    private System.Windows.Forms.Button buttonLoad;
    private System.Windows.Forms.Button buttonGetNetwork;
    private System.Windows.Forms.ToolStripMenuItem connectSMSSToolStripMenuItem;
    private DevExpress.XtraGrid.Columns.GridColumn colHost;
    private DevExpress.XtraGrid.Columns.GridColumn colServerStatus;
    private DevExpress.XtraGrid.Columns.GridColumn colInstanceName;
    private DevExpress.XtraGrid.Columns.GridColumn colServiceName;
    private DevExpress.XtraGrid.Columns.GridColumn colServiceStatus;
    private DevExpress.XtraGrid.Columns.GridColumn colServerMemoryRunning;
    private DevExpress.XtraGrid.Columns.GridColumn colServerMemoryMax;
    private DevExpress.XtraGrid.Columns.GridColumn colDatabasesSize;
    private DevExpress.XtraGrid.Columns.GridColumn colInfo;
    private DevExpress.XtraGrid.Columns.GridColumn colDescription;
    private DevExpress.XtraGrid.Columns.GridColumn colAbleToConnect;
  }
}

