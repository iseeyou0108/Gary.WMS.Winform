namespace WMS
{
    partial class Fm_Q002
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_Q002));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnPlus1F = new System.Windows.Forms.Button();
            this.btnMinus1F = new System.Windows.Forms.Button();
            this.cmbRow = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAsrsID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Select = new System.Windows.Forms.Button();
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_stk = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_palet = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_EmptyBin = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Unknown = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Out = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_In = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Forbidden = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Forbidden_X = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup_Settings = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_Lock = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_UnLock = new DevExpress.XtraNavBar.NavBarItem();
            this.gdcData = new DevExpress.XtraGrid.GridControl();
            this.gdvData = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.gdc_WMS_STK = new DevExpress.XtraGrid.GridControl();
            this.repositoryItemCheckEdit_CHK = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemButtonEdit_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gdv_WMS_STK = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWH_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASRS_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIN_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_TYPE_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOT_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORG_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORG_SNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTUS_CTR_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQC_RESULT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTUS_CTR = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAsrsID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdcData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WMS_STK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_CHK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WMS_STK)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnPlus1F);
            this.panelControl1.Controls.Add(this.btnMinus1F);
            this.panelControl1.Controls.Add(this.cmbRow);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.cmbAsrsID);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btn_Select);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.LookAndFeel.SkinName = "Lilian";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            // 
            // btnPlus1F
            // 
            this.btnPlus1F.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.btnPlus1F.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnPlus1F, "btnPlus1F");
            this.btnPlus1F.ForeColor = System.Drawing.Color.White;
            this.btnPlus1F.Image = global::WMS.Properties.Resources.add_16_White;
            this.btnPlus1F.Name = "btnPlus1F";
            this.btnPlus1F.UseVisualStyleBackColor = false;
            this.btnPlus1F.Click += new System.EventHandler(this.btnPlus1F_Click);
            // 
            // btnMinus1F
            // 
            this.btnMinus1F.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.btnMinus1F.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnMinus1F, "btnMinus1F");
            this.btnMinus1F.ForeColor = System.Drawing.Color.White;
            this.btnMinus1F.Image = global::WMS.Properties.Resources.Minus_16_W;
            this.btnMinus1F.Name = "btnMinus1F";
            this.btnMinus1F.UseVisualStyleBackColor = false;
            this.btnMinus1F.Click += new System.EventHandler(this.btnMinus1F_Click);
            // 
            // cmbRow
            // 
            resources.ApplyResources(this.cmbRow, "cmbRow");
            this.cmbRow.Name = "cmbRow";
            this.cmbRow.Properties.Appearance.Options.UseTextOptions = true;
            this.cmbRow.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.cmbRow.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cmbRow.Properties.Buttons"))))});
            this.cmbRow.Properties.DropDownRows = 10;
            this.cmbRow.Properties.Items.AddRange(new object[] {
            resources.GetString("cmbRow.Properties.Items"),
            resources.GetString("cmbRow.Properties.Items1"),
            resources.GetString("cmbRow.Properties.Items2"),
            resources.GetString("cmbRow.Properties.Items3"),
            resources.GetString("cmbRow.Properties.Items4"),
            resources.GetString("cmbRow.Properties.Items5"),
            resources.GetString("cmbRow.Properties.Items6"),
            resources.GetString("cmbRow.Properties.Items7"),
            resources.GetString("cmbRow.Properties.Items8"),
            resources.GetString("cmbRow.Properties.Items9")});
            this.cmbRow.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbRow.SelectedIndexChanged += new System.EventHandler(this.cmbRow_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // cmbAsrsID
            // 
            resources.ApplyResources(this.cmbAsrsID, "cmbAsrsID");
            this.cmbAsrsID.Name = "cmbAsrsID";
            this.cmbAsrsID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbAsrsID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cmbAsrsID.Properties.Buttons"))))});
            this.cmbAsrsID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbAsrsID.Properties.Columns"), resources.GetString("cmbAsrsID.Properties.Columns1"))});
            this.cmbAsrsID.Properties.DropDownRows = 10;
            this.cmbAsrsID.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
            // 
            // labelControl1
            // 
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // btn_Select
            // 
            resources.ApplyResources(this.btn_Select, "btn_Select");
            this.btn_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btn_Select.FlatAppearance.BorderSize = 0;
            this.btn_Select.ForeColor = System.Drawing.Color.White;
            this.btn_Select.Image = global::WMS.Properties.Resources.Refresh_16_W;
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            resources.ApplyResources(this.navBarControl1, "navBarControl1");
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1,
            this.navBarGroup_Settings});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem_palet,
            this.navBarItem_stk,
            this.navBarItem_EmptyBin,
            this.navBarItem_Forbidden_X,
            this.navBarItem_Forbidden,
            this.navBarItem_Unknown,
            this.navBarItem_In,
            this.navBarItem_Out,
            this.navBarItem_Lock,
            this.navBarItem_UnLock});
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Black");
            // 
            // navBarGroup1
            // 
            resources.ApplyResources(this.navBarGroup1, "navBarGroup1");
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_stk),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_palet),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_EmptyBin),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Unknown),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Out),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_In),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Forbidden),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Forbidden_X)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarItem_stk
            // 
            resources.ApplyResources(this.navBarItem_stk, "navBarItem_stk");
            this.navBarItem_stk.Name = "navBarItem_stk";
            this.navBarItem_stk.SmallImage = global::WMS.Properties.Resources.Box_32_2;
            // 
            // navBarItem_palet
            // 
            resources.ApplyResources(this.navBarItem_palet, "navBarItem_palet");
            this.navBarItem_palet.Name = "navBarItem_palet";
            this.navBarItem_palet.SmallImage = global::WMS.Properties.Resources.palet_32;
            // 
            // navBarItem_EmptyBin
            // 
            resources.ApplyResources(this.navBarItem_EmptyBin, "navBarItem_EmptyBin");
            this.navBarItem_EmptyBin.Name = "navBarItem_EmptyBin";
            this.navBarItem_EmptyBin.SmallImage = global::WMS.Properties.Resources.Empty_32;
            // 
            // navBarItem_Unknown
            // 
            resources.ApplyResources(this.navBarItem_Unknown, "navBarItem_Unknown");
            this.navBarItem_Unknown.Name = "navBarItem_Unknown";
            this.navBarItem_Unknown.SmallImage = global::WMS.Properties.Resources.Unknown_32;
            // 
            // navBarItem_Out
            // 
            resources.ApplyResources(this.navBarItem_Out, "navBarItem_Out");
            this.navBarItem_Out.Name = "navBarItem_Out";
            this.navBarItem_Out.SmallImage = global::WMS.Properties.Resources.Out_32;
            // 
            // navBarItem_In
            // 
            resources.ApplyResources(this.navBarItem_In, "navBarItem_In");
            this.navBarItem_In.Name = "navBarItem_In";
            this.navBarItem_In.SmallImage = global::WMS.Properties.Resources.In_32;
            // 
            // navBarItem_Forbidden
            // 
            resources.ApplyResources(this.navBarItem_Forbidden, "navBarItem_Forbidden");
            this.navBarItem_Forbidden.Name = "navBarItem_Forbidden";
            this.navBarItem_Forbidden.SmallImage = global::WMS.Properties.Resources.Forbidden_32_r;
            // 
            // navBarItem_Forbidden_X
            // 
            resources.ApplyResources(this.navBarItem_Forbidden_X, "navBarItem_Forbidden_X");
            this.navBarItem_Forbidden_X.Name = "navBarItem_Forbidden_X";
            this.navBarItem_Forbidden_X.SmallImage = global::WMS.Properties.Resources.Forbidden_32_b;
            // 
            // navBarGroup_Settings
            // 
            resources.ApplyResources(this.navBarGroup_Settings, "navBarGroup_Settings");
            this.navBarGroup_Settings.Expanded = true;
            this.navBarGroup_Settings.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Lock),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_UnLock)});
            this.navBarGroup_Settings.Name = "navBarGroup_Settings";
            // 
            // navBarItem_Lock
            // 
            resources.ApplyResources(this.navBarItem_Lock, "navBarItem_Lock");
            this.navBarItem_Lock.Name = "navBarItem_Lock";
            this.navBarItem_Lock.SmallImage = global::WMS.Properties.Resources.Forbidden_32_r;
            this.navBarItem_Lock.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_Lock_LinkClicked);
            // 
            // navBarItem_UnLock
            // 
            resources.ApplyResources(this.navBarItem_UnLock, "navBarItem_UnLock");
            this.navBarItem_UnLock.Name = "navBarItem_UnLock";
            this.navBarItem_UnLock.SmallImage = global::WMS.Properties.Resources.Unlock_32;
            this.navBarItem_UnLock.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItem_UnLock_LinkClicked);
            // 
            // gdcData
            // 
            resources.ApplyResources(this.gdcData, "gdcData");
            this.gdcData.LookAndFeel.SkinName = "Black";
            this.gdcData.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdcData.MainView = this.gdvData;
            this.gdcData.Name = "gdcData";
            this.gdcData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdvData});
            // 
            // gdvData
            // 
            this.gdvData.GridControl = this.gdcData;
            this.gdvData.IndicatorWidth = 35;
            this.gdvData.Name = "gdvData";
            this.gdvData.OptionsSelection.MultiSelect = true;
            this.gdvData.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
            this.gdvData.OptionsView.ShowGroupPanel = false;
            this.gdvData.OptionsView.ShowViewCaption = true;
            resources.ApplyResources(this.gdvData, "gdvData");
            this.gdvData.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gdvData_CustomDrawFooterCell);
            this.gdvData.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gdvData_CustomDrawRowIndicator);
            this.gdvData.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gdvData_CustomDrawCell);
            this.gdvData.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gdvData_RowCellClick);
            // 
            // gdc_WMS_STK
            // 
            resources.ApplyResources(this.gdc_WMS_STK, "gdc_WMS_STK");
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.TextStringFormat = resources.GetString("gdc_WMS_STK.EmbeddedNavigator.TextStringFormat");
            this.gdc_WMS_STK.LookAndFeel.SkinName = "Black";
            this.gdc_WMS_STK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdc_WMS_STK.MainView = this.gdv_WMS_STK;
            this.gdc_WMS_STK.Name = "gdc_WMS_STK";
            this.gdc_WMS_STK.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit_CHK,
            this.repositoryItemButtonEdit_Delete,
            this.repositoryItemButtonEdit_Edit});
            this.gdc_WMS_STK.TabStop = false;
            this.gdc_WMS_STK.UseEmbeddedNavigator = true;
            this.gdc_WMS_STK.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdv_WMS_STK});
            // 
            // repositoryItemCheckEdit_CHK
            // 
            resources.ApplyResources(this.repositoryItemCheckEdit_CHK, "repositoryItemCheckEdit_CHK");
            this.repositoryItemCheckEdit_CHK.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit_CHK.Name = "repositoryItemCheckEdit_CHK";
            this.repositoryItemCheckEdit_CHK.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit_CHK.PictureChecked = global::WMS.Properties.Resources.Checked20;
            this.repositoryItemCheckEdit_CHK.PictureGrayed = global::WMS.Properties.Resources.UnChecked20;
            this.repositoryItemCheckEdit_CHK.PictureUnchecked = global::WMS.Properties.Resources.Checked20;
            this.repositoryItemCheckEdit_CHK.ValueChecked = "Y";
            this.repositoryItemCheckEdit_CHK.ValueGrayed = "N";
            this.repositoryItemCheckEdit_CHK.ValueUnchecked = "N";
            // 
            // repositoryItemButtonEdit_Delete
            // 
            resources.ApplyResources(this.repositoryItemButtonEdit_Delete, "repositoryItemButtonEdit_Delete");
            this.repositoryItemButtonEdit_Delete.Name = "repositoryItemButtonEdit_Delete";
            this.repositoryItemButtonEdit_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemButtonEdit_Edit
            // 
            resources.ApplyResources(this.repositoryItemButtonEdit_Edit, "repositoryItemButtonEdit_Edit");
            this.repositoryItemButtonEdit_Edit.Name = "repositoryItemButtonEdit_Edit";
            this.repositoryItemButtonEdit_Edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // gdv_WMS_STK
            // 
            this.gdv_WMS_STK.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWH_NO,
            this.colASRS_ID,
            this.colBIN_NO,
            this.colPROD_NO,
            this.colPROD_NAME,
            this.colPROD_TYPE_DESC,
            this.colLOT_NO,
            this.colORG_NO,
            this.colORG_SNAME,
            this.colSTUS_CTR_DESC,
            this.colQC_RESULT,
            this.colQTY,
            this.colSDATE,
            this.colPDATE,
            this.colUN,
            this.colSTUS_CTR});
            this.gdv_WMS_STK.GridControl = this.gdc_WMS_STK;
            this.gdv_WMS_STK.Name = "gdv_WMS_STK";
            this.gdv_WMS_STK.OptionsCustomization.AllowQuickHideColumns = false;
            this.gdv_WMS_STK.OptionsMenu.EnableColumnMenu = false;
            this.gdv_WMS_STK.OptionsMenu.EnableFooterMenu = false;
            this.gdv_WMS_STK.OptionsMenu.EnableGroupPanelMenu = false;
            this.gdv_WMS_STK.OptionsView.ColumnAutoWidth = false;
            this.gdv_WMS_STK.OptionsView.EnableAppearanceEvenRow = true;
            this.gdv_WMS_STK.OptionsView.EnableAppearanceOddRow = true;
            this.gdv_WMS_STK.OptionsView.ShowGroupPanel = false;
            // 
            // colWH_NO
            // 
            resources.ApplyResources(this.colWH_NO, "colWH_NO");
            this.colWH_NO.FieldName = "WH_NO";
            this.colWH_NO.Name = "colWH_NO";
            this.colWH_NO.OptionsColumn.AllowEdit = false;
            this.colWH_NO.OptionsColumn.ReadOnly = true;
            // 
            // colASRS_ID
            // 
            this.colASRS_ID.AppearanceCell.Options.UseTextOptions = true;
            this.colASRS_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colASRS_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.colASRS_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colASRS_ID, "colASRS_ID");
            this.colASRS_ID.FieldName = "ASRS_ID";
            this.colASRS_ID.Name = "colASRS_ID";
            this.colASRS_ID.OptionsColumn.AllowEdit = false;
            this.colASRS_ID.OptionsColumn.ReadOnly = true;
            // 
            // colBIN_NO
            // 
            resources.ApplyResources(this.colBIN_NO, "colBIN_NO");
            this.colBIN_NO.FieldName = "BIN_NO";
            this.colBIN_NO.Name = "colBIN_NO";
            this.colBIN_NO.OptionsColumn.AllowEdit = false;
            this.colBIN_NO.OptionsColumn.ReadOnly = true;
            // 
            // colPROD_NO
            // 
            resources.ApplyResources(this.colPROD_NO, "colPROD_NO");
            this.colPROD_NO.FieldName = "PROD_NO";
            this.colPROD_NO.Name = "colPROD_NO";
            this.colPROD_NO.OptionsColumn.AllowEdit = false;
            this.colPROD_NO.OptionsColumn.ReadOnly = true;
            // 
            // colPROD_NAME
            // 
            resources.ApplyResources(this.colPROD_NAME, "colPROD_NAME");
            this.colPROD_NAME.FieldName = "PROD_NAME";
            this.colPROD_NAME.Name = "colPROD_NAME";
            this.colPROD_NAME.OptionsColumn.AllowEdit = false;
            this.colPROD_NAME.OptionsColumn.ReadOnly = true;
            // 
            // colPROD_TYPE_DESC
            // 
            resources.ApplyResources(this.colPROD_TYPE_DESC, "colPROD_TYPE_DESC");
            this.colPROD_TYPE_DESC.FieldName = "PROD_TYPE_DESC";
            this.colPROD_TYPE_DESC.Name = "colPROD_TYPE_DESC";
            this.colPROD_TYPE_DESC.OptionsColumn.AllowEdit = false;
            this.colPROD_TYPE_DESC.OptionsColumn.ReadOnly = true;
            // 
            // colLOT_NO
            // 
            resources.ApplyResources(this.colLOT_NO, "colLOT_NO");
            this.colLOT_NO.FieldName = "LOT_NO";
            this.colLOT_NO.Name = "colLOT_NO";
            this.colLOT_NO.OptionsColumn.AllowEdit = false;
            this.colLOT_NO.OptionsColumn.ReadOnly = true;
            // 
            // colORG_NO
            // 
            resources.ApplyResources(this.colORG_NO, "colORG_NO");
            this.colORG_NO.FieldName = "ORG_NO";
            this.colORG_NO.Name = "colORG_NO";
            this.colORG_NO.OptionsColumn.AllowEdit = false;
            this.colORG_NO.OptionsColumn.ReadOnly = true;
            // 
            // colORG_SNAME
            // 
            resources.ApplyResources(this.colORG_SNAME, "colORG_SNAME");
            this.colORG_SNAME.FieldName = "ORG_SNAME";
            this.colORG_SNAME.Name = "colORG_SNAME";
            this.colORG_SNAME.OptionsColumn.AllowEdit = false;
            this.colORG_SNAME.OptionsColumn.ReadOnly = true;
            // 
            // colSTUS_CTR_DESC
            // 
            resources.ApplyResources(this.colSTUS_CTR_DESC, "colSTUS_CTR_DESC");
            this.colSTUS_CTR_DESC.FieldName = "STUS_CTR_DESC";
            this.colSTUS_CTR_DESC.Name = "colSTUS_CTR_DESC";
            this.colSTUS_CTR_DESC.OptionsColumn.AllowEdit = false;
            this.colSTUS_CTR_DESC.OptionsColumn.ReadOnly = true;
            // 
            // colQC_RESULT
            // 
            resources.ApplyResources(this.colQC_RESULT, "colQC_RESULT");
            this.colQC_RESULT.FieldName = "QC_RESULT_DESC";
            this.colQC_RESULT.Name = "colQC_RESULT";
            this.colQC_RESULT.OptionsColumn.AllowEdit = false;
            this.colQC_RESULT.OptionsColumn.ReadOnly = true;
            // 
            // colQTY
            // 
            this.colQTY.AppearanceCell.Options.UseTextOptions = true;
            this.colQTY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQTY.AppearanceHeader.Options.UseTextOptions = true;
            this.colQTY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colQTY, "colQTY");
            this.colQTY.DisplayFormat.FormatString = "0.00";
            this.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQTY.FieldName = "QTY";
            this.colQTY.Name = "colQTY";
            this.colQTY.OptionsColumn.AllowEdit = false;
            this.colQTY.OptionsColumn.ReadOnly = true;
            // 
            // colSDATE
            // 
            this.colSDATE.AppearanceCell.Options.UseTextOptions = true;
            this.colSDATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSDATE.AppearanceHeader.Options.UseTextOptions = true;
            this.colSDATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colSDATE, "colSDATE");
            this.colSDATE.FieldName = "SDATE";
            this.colSDATE.Name = "colSDATE";
            this.colSDATE.OptionsColumn.AllowEdit = false;
            this.colSDATE.OptionsColumn.ReadOnly = true;
            // 
            // colPDATE
            // 
            this.colPDATE.AppearanceCell.Options.UseTextOptions = true;
            this.colPDATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPDATE.AppearanceHeader.Options.UseTextOptions = true;
            this.colPDATE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colPDATE, "colPDATE");
            this.colPDATE.FieldName = "PDATE";
            this.colPDATE.Name = "colPDATE";
            this.colPDATE.OptionsColumn.AllowEdit = false;
            this.colPDATE.OptionsColumn.ReadOnly = true;
            // 
            // colUN
            // 
            resources.ApplyResources(this.colUN, "colUN");
            this.colUN.FieldName = "UN";
            this.colUN.Name = "colUN";
            this.colUN.OptionsColumn.AllowEdit = false;
            this.colUN.OptionsColumn.ReadOnly = true;
            // 
            // colSTUS_CTR
            // 
            resources.ApplyResources(this.colSTUS_CTR, "colSTUS_CTR");
            this.colSTUS_CTR.FieldName = "STUS_CTR";
            this.colSTUS_CTR.Name = "colSTUS_CTR";
            this.colSTUS_CTR.OptionsColumn.AllowEdit = false;
            this.colSTUS_CTR.OptionsColumn.ReadOnly = true;
            // 
            // Fm_Q002
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gdcData);
            this.Controls.Add(this.gdc_WMS_STK);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Fm_Q002";
            this.Load += new System.EventHandler(this.Fm_Q002_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAsrsID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdcData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WMS_STK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_CHK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WMS_STK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btn_Select;
        private DevExpress.XtraEditors.ComboBoxEdit cmbRow;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit cmbAsrsID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_palet;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_stk;
        private DevExpress.XtraGrid.GridControl gdcData;
        private DevExpress.XtraGrid.Views.Grid.GridView gdvData;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_EmptyBin;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Forbidden_X;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Forbidden;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Unknown;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_In;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Out;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_Settings;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Lock;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_UnLock;
        private System.Windows.Forms.Button btnPlus1F;
        private System.Windows.Forms.Button btnMinus1F;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraGrid.GridControl gdc_WMS_STK;
        private DevExpress.XtraGrid.Views.Grid.GridView gdv_WMS_STK;
        private DevExpress.XtraGrid.Columns.GridColumn colWH_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colASRS_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colBIN_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_TYPE_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colLOT_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colORG_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colORG_SNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colSTUS_CTR_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colQC_RESULT;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
        private DevExpress.XtraGrid.Columns.GridColumn colSDATE;
        private DevExpress.XtraGrid.Columns.GridColumn colPDATE;
        private DevExpress.XtraGrid.Columns.GridColumn colUN;
        private DevExpress.XtraGrid.Columns.GridColumn colSTUS_CTR;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_CHK;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit_Delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit_Edit;
    }
}