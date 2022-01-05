namespace WMS
{
    partial class Fm_A002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_A002));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbAsrsID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chkAutoRefresh = new DevExpress.XtraEditors.CheckEdit();
            this.btnColumnSet = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gdc_WCS_CRN = new DevExpress.XtraGrid.GridControl();
            this.gdv_WCS_CRN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCHK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSER_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASRS_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONNECT_MODE_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINHIBIT_IN_FLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINHIBIT_OUT_FLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colERR_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colERR_CODE_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFROM_BIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTO_BIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOADING = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_LOCATION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_SER_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_AUTO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_INITIAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_CMD_COMP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_NORMAL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_CMD_EXIST = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_READY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnForbidden = new System.Windows.Forms.Button();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnErrorLog = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tmrAutoRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAsrsID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRefresh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WCS_CRN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WCS_CRN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.AccessibleDescription = null;
            this.panelControl1.AccessibleName = null;
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Controls.Add(this.cmbAsrsID);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.chkAutoRefresh);
            this.panelControl1.Controls.Add(this.btnColumnSet);
            this.panelControl1.Controls.Add(this.btn_Select);
            this.panelControl1.LookAndFeel.SkinName = "Lilian";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            // 
            // cmbAsrsID
            // 
            resources.ApplyResources(this.cmbAsrsID, "cmbAsrsID");
            this.cmbAsrsID.BackgroundImage = null;
            this.cmbAsrsID.EditValue = null;
            this.cmbAsrsID.Name = "cmbAsrsID";
            this.cmbAsrsID.Properties.AccessibleDescription = null;
            this.cmbAsrsID.Properties.AccessibleName = null;
            this.cmbAsrsID.Properties.AutoHeight = ((bool)(resources.GetObject("cmbAsrsID.Properties.AutoHeight")));
            this.cmbAsrsID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbAsrsID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cmbAsrsID.Properties.Buttons"))))});
            this.cmbAsrsID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbAsrsID.Properties.Columns"), resources.GetString("cmbAsrsID.Properties.Columns1"))});
            this.cmbAsrsID.Properties.DropDownRows = 10;
            this.cmbAsrsID.Properties.NullValuePrompt = resources.GetString("cmbAsrsID.Properties.NullValuePrompt");
            this.cmbAsrsID.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cmbAsrsID.Properties.NullValuePromptShowForEmptyValue")));
            // 
            // labelControl1
            // 
            this.labelControl1.AccessibleDescription = null;
            this.labelControl1.AccessibleName = null;
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // chkAutoRefresh
            // 
            resources.ApplyResources(this.chkAutoRefresh, "chkAutoRefresh");
            this.chkAutoRefresh.BackgroundImage = null;
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Properties.AccessibleDescription = null;
            this.chkAutoRefresh.Properties.AccessibleName = null;
            this.chkAutoRefresh.Properties.AutoHeight = ((bool)(resources.GetObject("chkAutoRefresh.Properties.AutoHeight")));
            this.chkAutoRefresh.Properties.Caption = resources.GetString("chkAutoRefresh.Properties.Caption");
            this.chkAutoRefresh.Properties.DisplayValueChecked = resources.GetString("chkAutoRefresh.Properties.DisplayValueChecked");
            this.chkAutoRefresh.Properties.DisplayValueGrayed = resources.GetString("chkAutoRefresh.Properties.DisplayValueGrayed");
            this.chkAutoRefresh.Properties.DisplayValueUnchecked = resources.GetString("chkAutoRefresh.Properties.DisplayValueUnchecked");
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // btnColumnSet
            // 
            this.btnColumnSet.AccessibleDescription = null;
            this.btnColumnSet.AccessibleName = null;
            resources.ApplyResources(this.btnColumnSet, "btnColumnSet");
            this.btnColumnSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnColumnSet.BackgroundImage = null;
            this.btnColumnSet.FlatAppearance.BorderSize = 0;
            this.btnColumnSet.ForeColor = System.Drawing.Color.White;
            this.btnColumnSet.Image = global::WMS.Properties.Resources.export_16_White;
            this.btnColumnSet.Name = "btnColumnSet";
            this.btnColumnSet.UseVisualStyleBackColor = false;
            this.btnColumnSet.Click += new System.EventHandler(this.btnColumnSet_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.AccessibleDescription = null;
            this.btn_Select.AccessibleName = null;
            resources.ApplyResources(this.btn_Select, "btn_Select");
            this.btn_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btn_Select.BackgroundImage = null;
            this.btn_Select.FlatAppearance.BorderSize = 0;
            this.btn_Select.ForeColor = System.Drawing.Color.White;
            this.btn_Select.Image = global::WMS.Properties.Resources.search_16_White;
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AccessibleDescription = null;
            this.groupControl1.AccessibleName = null;
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Controls.Add(this.gdc_WCS_CRN);
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.LookAndFeel.SkinName = "Lilian";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            // 
            // gdc_WCS_CRN
            // 
            this.gdc_WCS_CRN.AccessibleDescription = null;
            this.gdc_WCS_CRN.AccessibleName = null;
            resources.ApplyResources(this.gdc_WCS_CRN, "gdc_WCS_CRN");
            this.gdc_WCS_CRN.BackgroundImage = null;
            this.gdc_WCS_CRN.EmbeddedNavigator.AccessibleDescription = null;
            this.gdc_WCS_CRN.EmbeddedNavigator.AccessibleName = null;
            this.gdc_WCS_CRN.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gdc_WCS_CRN.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gdc_WCS_CRN.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gdc_WCS_CRN.EmbeddedNavigator.Anchor")));
            this.gdc_WCS_CRN.EmbeddedNavigator.BackgroundImage = null;
            this.gdc_WCS_CRN.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gdc_WCS_CRN.EmbeddedNavigator.BackgroundImageLayout")));
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.Append.Hint = resources.GetString("gdc_WCS_CRN.EmbeddedNavigator.Buttons.Append.Hint");
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.CancelEdit.Hint = resources.GetString("gdc_WCS_CRN.EmbeddedNavigator.Buttons.CancelEdit.Hint");
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.Edit.Hint = resources.GetString("gdc_WCS_CRN.EmbeddedNavigator.Buttons.Edit.Hint");
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.EndEdit.Hint = resources.GetString("gdc_WCS_CRN.EmbeddedNavigator.Buttons.EndEdit.Hint");
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.Remove.Hint = resources.GetString("gdc_WCS_CRN.EmbeddedNavigator.Buttons.Remove.Hint");
            this.gdc_WCS_CRN.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gdc_WCS_CRN.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gdc_WCS_CRN.EmbeddedNavigator.ImeMode")));
            this.gdc_WCS_CRN.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gdc_WCS_CRN.EmbeddedNavigator.TextLocation")));
            this.gdc_WCS_CRN.EmbeddedNavigator.TextStringFormat = resources.GetString("gdc_WCS_CRN.EmbeddedNavigator.TextStringFormat");
            this.gdc_WCS_CRN.EmbeddedNavigator.ToolTip = resources.GetString("gdc_WCS_CRN.EmbeddedNavigator.ToolTip");
            this.gdc_WCS_CRN.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gdc_WCS_CRN.EmbeddedNavigator.ToolTipIconType")));
            this.gdc_WCS_CRN.EmbeddedNavigator.ToolTipTitle = resources.GetString("gdc_WCS_CRN.EmbeddedNavigator.ToolTipTitle");
            this.gdc_WCS_CRN.Font = null;
            this.gdc_WCS_CRN.LookAndFeel.SkinName = "Black";
            this.gdc_WCS_CRN.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdc_WCS_CRN.MainView = this.gdv_WCS_CRN;
            this.gdc_WCS_CRN.Name = "gdc_WCS_CRN";
            this.gdc_WCS_CRN.TabStop = false;
            this.gdc_WCS_CRN.UseEmbeddedNavigator = true;
            this.gdc_WCS_CRN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdv_WCS_CRN});
            // 
            // gdv_WCS_CRN
            // 
            resources.ApplyResources(this.gdv_WCS_CRN, "gdv_WCS_CRN");
            this.gdv_WCS_CRN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCHK,
            this.colSER_NO,
            this.colASRS_ID,
            this.colCONNECT_MODE_DESC,
            this.colINHIBIT_IN_FLG,
            this.colINHIBIT_OUT_FLG,
            this.colERR_CODE,
            this.colERR_CODE_DESC,
            this.colFROM_BIN,
            this.colTO_BIN,
            this.colLOADING,
            this.colCRN_LOCATION,
            this.colIO,
            this.colCRN_ID,
            this.colCRN_SER_NO,
            this.colCRN_AUTO,
            this.colCRN_INITIAL,
            this.colCRN_CMD_COMP,
            this.colCRN_NORMAL,
            this.colCRN_CMD_EXIST,
            this.colCRN_READY});
            styleFormatCondition1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("resource.BackColor")));
            styleFormatCondition1.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("resource.ForeColor")));
            styleFormatCondition1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("resource.GradientMode")));
            styleFormatCondition1.Appearance.Image = null;
            styleFormatCondition1.Appearance.Options.UseBackColor = true;
            styleFormatCondition1.Appearance.Options.UseForeColor = true;
            styleFormatCondition1.ApplyToRow = true;
            styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Between;
            styleFormatCondition1.Value1 = new decimal(new int[] {
            78,
            0,
            0,
            0});
            styleFormatCondition1.Value2 = new decimal(new int[] {
            83,
            0,
            0,
            0});
            this.gdv_WCS_CRN.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1});
            this.gdv_WCS_CRN.GridControl = this.gdc_WCS_CRN;
            this.gdv_WCS_CRN.Name = "gdv_WCS_CRN";
            this.gdv_WCS_CRN.OptionsCustomization.AllowQuickHideColumns = false;
            this.gdv_WCS_CRN.OptionsMenu.EnableColumnMenu = false;
            this.gdv_WCS_CRN.OptionsMenu.EnableFooterMenu = false;
            this.gdv_WCS_CRN.OptionsMenu.EnableGroupPanelMenu = false;
            this.gdv_WCS_CRN.OptionsView.ColumnAutoWidth = false;
            this.gdv_WCS_CRN.OptionsView.EnableAppearanceEvenRow = true;
            this.gdv_WCS_CRN.OptionsView.EnableAppearanceOddRow = true;
            this.gdv_WCS_CRN.OptionsView.ShowAutoFilterRow = true;
            this.gdv_WCS_CRN.OptionsView.ShowGroupPanel = false;
            this.gdv_WCS_CRN.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gdv_WCS_CRN_FocusedRowChanged);
            this.gdv_WCS_CRN.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gdv_WCS_CRN_RowClick);
            // 
            // colCHK
            // 
            resources.ApplyResources(this.colCHK, "colCHK");
            this.colCHK.FieldName = "CHK";
            this.colCHK.Name = "colCHK";
            // 
            // colSER_NO
            // 
            this.colSER_NO.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colSER_NO.AppearanceCell.GradientMode")));
            this.colSER_NO.AppearanceCell.Image = null;
            this.colSER_NO.AppearanceCell.Options.UseTextOptions = true;
            this.colSER_NO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSER_NO.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colSER_NO.AppearanceHeader.GradientMode")));
            this.colSER_NO.AppearanceHeader.Image = null;
            this.colSER_NO.AppearanceHeader.Options.UseTextOptions = true;
            this.colSER_NO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colSER_NO, "colSER_NO");
            this.colSER_NO.FieldName = "SER_NO";
            this.colSER_NO.Name = "colSER_NO";
            this.colSER_NO.OptionsColumn.AllowEdit = false;
            this.colSER_NO.OptionsColumn.ReadOnly = true;
            // 
            // colASRS_ID
            // 
            this.colASRS_ID.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colASRS_ID.AppearanceCell.GradientMode")));
            this.colASRS_ID.AppearanceCell.Image = null;
            this.colASRS_ID.AppearanceCell.Options.UseTextOptions = true;
            this.colASRS_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colASRS_ID.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colASRS_ID.AppearanceHeader.GradientMode")));
            this.colASRS_ID.AppearanceHeader.Image = null;
            this.colASRS_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.colASRS_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colASRS_ID, "colASRS_ID");
            this.colASRS_ID.FieldName = "ASRS_ID";
            this.colASRS_ID.Name = "colASRS_ID";
            this.colASRS_ID.OptionsColumn.AllowEdit = false;
            this.colASRS_ID.OptionsColumn.ReadOnly = true;
            // 
            // colCONNECT_MODE_DESC
            // 
            resources.ApplyResources(this.colCONNECT_MODE_DESC, "colCONNECT_MODE_DESC");
            this.colCONNECT_MODE_DESC.FieldName = "CONNECT_MODE_DESC";
            this.colCONNECT_MODE_DESC.Name = "colCONNECT_MODE_DESC";
            this.colCONNECT_MODE_DESC.OptionsColumn.AllowEdit = false;
            this.colCONNECT_MODE_DESC.OptionsColumn.ReadOnly = true;
            // 
            // colINHIBIT_IN_FLG
            // 
            resources.ApplyResources(this.colINHIBIT_IN_FLG, "colINHIBIT_IN_FLG");
            this.colINHIBIT_IN_FLG.FieldName = "INHIBIT_IN_FLG";
            this.colINHIBIT_IN_FLG.Name = "colINHIBIT_IN_FLG";
            this.colINHIBIT_IN_FLG.OptionsColumn.AllowEdit = false;
            this.colINHIBIT_IN_FLG.OptionsColumn.ReadOnly = true;
            // 
            // colINHIBIT_OUT_FLG
            // 
            resources.ApplyResources(this.colINHIBIT_OUT_FLG, "colINHIBIT_OUT_FLG");
            this.colINHIBIT_OUT_FLG.FieldName = "INHIBIT_OUT_FLG";
            this.colINHIBIT_OUT_FLG.Name = "colINHIBIT_OUT_FLG";
            this.colINHIBIT_OUT_FLG.OptionsColumn.AllowEdit = false;
            this.colINHIBIT_OUT_FLG.OptionsColumn.ReadOnly = true;
            // 
            // colERR_CODE
            // 
            resources.ApplyResources(this.colERR_CODE, "colERR_CODE");
            this.colERR_CODE.FieldName = "ERR_CODE";
            this.colERR_CODE.Name = "colERR_CODE";
            this.colERR_CODE.OptionsColumn.AllowEdit = false;
            this.colERR_CODE.OptionsColumn.ReadOnly = true;
            // 
            // colERR_CODE_DESC
            // 
            resources.ApplyResources(this.colERR_CODE_DESC, "colERR_CODE_DESC");
            this.colERR_CODE_DESC.FieldName = "ERR_CODE_DESC";
            this.colERR_CODE_DESC.Name = "colERR_CODE_DESC";
            this.colERR_CODE_DESC.OptionsColumn.AllowEdit = false;
            this.colERR_CODE_DESC.OptionsColumn.ReadOnly = true;
            // 
            // colFROM_BIN
            // 
            resources.ApplyResources(this.colFROM_BIN, "colFROM_BIN");
            this.colFROM_BIN.FieldName = "FROM_BIN";
            this.colFROM_BIN.Name = "colFROM_BIN";
            this.colFROM_BIN.OptionsColumn.AllowEdit = false;
            this.colFROM_BIN.OptionsColumn.ReadOnly = true;
            // 
            // colTO_BIN
            // 
            resources.ApplyResources(this.colTO_BIN, "colTO_BIN");
            this.colTO_BIN.FieldName = "TO_BIN";
            this.colTO_BIN.Name = "colTO_BIN";
            this.colTO_BIN.OptionsColumn.AllowEdit = false;
            this.colTO_BIN.OptionsColumn.ReadOnly = true;
            // 
            // colLOADING
            // 
            this.colLOADING.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colLOADING.AppearanceHeader.GradientMode")));
            this.colLOADING.AppearanceHeader.Image = null;
            this.colLOADING.AppearanceHeader.Options.UseTextOptions = true;
            this.colLOADING.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colLOADING, "colLOADING");
            this.colLOADING.FieldName = "LOADING";
            this.colLOADING.Name = "colLOADING";
            this.colLOADING.OptionsColumn.AllowEdit = false;
            this.colLOADING.OptionsColumn.ReadOnly = true;
            // 
            // colCRN_LOCATION
            // 
            resources.ApplyResources(this.colCRN_LOCATION, "colCRN_LOCATION");
            this.colCRN_LOCATION.FieldName = "CRN_LOCATION";
            this.colCRN_LOCATION.Name = "colCRN_LOCATION";
            this.colCRN_LOCATION.OptionsColumn.AllowEdit = false;
            this.colCRN_LOCATION.OptionsColumn.ReadOnly = true;
            // 
            // colIO
            // 
            resources.ApplyResources(this.colIO, "colIO");
            this.colIO.FieldName = "IO";
            this.colIO.Name = "colIO";
            this.colIO.OptionsColumn.AllowEdit = false;
            this.colIO.OptionsColumn.ReadOnly = true;
            // 
            // colCRN_ID
            // 
            this.colCRN_ID.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_ID.AppearanceCell.GradientMode")));
            this.colCRN_ID.AppearanceCell.Image = null;
            this.colCRN_ID.AppearanceCell.Options.UseTextOptions = true;
            this.colCRN_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCRN_ID.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_ID.AppearanceHeader.GradientMode")));
            this.colCRN_ID.AppearanceHeader.Image = null;
            this.colCRN_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.colCRN_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colCRN_ID, "colCRN_ID");
            this.colCRN_ID.FieldName = "CRN_ID";
            this.colCRN_ID.Name = "colCRN_ID";
            this.colCRN_ID.OptionsColumn.AllowEdit = false;
            this.colCRN_ID.OptionsColumn.ReadOnly = true;
            // 
            // colCRN_SER_NO
            // 
            this.colCRN_SER_NO.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_SER_NO.AppearanceCell.GradientMode")));
            this.colCRN_SER_NO.AppearanceCell.Image = null;
            this.colCRN_SER_NO.AppearanceCell.Options.UseTextOptions = true;
            this.colCRN_SER_NO.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colCRN_SER_NO.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_SER_NO.AppearanceHeader.GradientMode")));
            this.colCRN_SER_NO.AppearanceHeader.Image = null;
            this.colCRN_SER_NO.AppearanceHeader.Options.UseTextOptions = true;
            this.colCRN_SER_NO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colCRN_SER_NO, "colCRN_SER_NO");
            this.colCRN_SER_NO.FieldName = "CRN_SER_NO";
            this.colCRN_SER_NO.Name = "colCRN_SER_NO";
            this.colCRN_SER_NO.OptionsColumn.AllowEdit = false;
            this.colCRN_SER_NO.OptionsColumn.ReadOnly = true;
            // 
            // colCRN_AUTO
            // 
            this.colCRN_AUTO.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_AUTO.AppearanceHeader.GradientMode")));
            this.colCRN_AUTO.AppearanceHeader.Image = null;
            this.colCRN_AUTO.AppearanceHeader.Options.UseTextOptions = true;
            this.colCRN_AUTO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colCRN_AUTO, "colCRN_AUTO");
            this.colCRN_AUTO.FieldName = "CRN_AUTO";
            this.colCRN_AUTO.Name = "colCRN_AUTO";
            this.colCRN_AUTO.OptionsColumn.AllowEdit = false;
            this.colCRN_AUTO.OptionsColumn.ReadOnly = true;
            // 
            // colCRN_INITIAL
            // 
            this.colCRN_INITIAL.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_INITIAL.AppearanceHeader.GradientMode")));
            this.colCRN_INITIAL.AppearanceHeader.Image = null;
            this.colCRN_INITIAL.AppearanceHeader.Options.UseTextOptions = true;
            this.colCRN_INITIAL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colCRN_INITIAL, "colCRN_INITIAL");
            this.colCRN_INITIAL.FieldName = "CRN_INITIAL";
            this.colCRN_INITIAL.Name = "colCRN_INITIAL";
            this.colCRN_INITIAL.OptionsColumn.AllowEdit = false;
            this.colCRN_INITIAL.OptionsColumn.ReadOnly = true;
            // 
            // colCRN_CMD_COMP
            // 
            this.colCRN_CMD_COMP.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_CMD_COMP.AppearanceHeader.GradientMode")));
            this.colCRN_CMD_COMP.AppearanceHeader.Image = null;
            this.colCRN_CMD_COMP.AppearanceHeader.Options.UseTextOptions = true;
            this.colCRN_CMD_COMP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colCRN_CMD_COMP, "colCRN_CMD_COMP");
            this.colCRN_CMD_COMP.FieldName = "CRN_CMD_COMP";
            this.colCRN_CMD_COMP.Name = "colCRN_CMD_COMP";
            this.colCRN_CMD_COMP.OptionsColumn.AllowEdit = false;
            this.colCRN_CMD_COMP.OptionsColumn.ReadOnly = true;
            // 
            // colCRN_NORMAL
            // 
            this.colCRN_NORMAL.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_NORMAL.AppearanceHeader.GradientMode")));
            this.colCRN_NORMAL.AppearanceHeader.Image = null;
            this.colCRN_NORMAL.AppearanceHeader.Options.UseTextOptions = true;
            this.colCRN_NORMAL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colCRN_NORMAL, "colCRN_NORMAL");
            this.colCRN_NORMAL.FieldName = "CRN_NORMAL";
            this.colCRN_NORMAL.Name = "colCRN_NORMAL";
            this.colCRN_NORMAL.OptionsColumn.AllowEdit = false;
            this.colCRN_NORMAL.OptionsColumn.ReadOnly = true;
            // 
            // colCRN_CMD_EXIST
            // 
            this.colCRN_CMD_EXIST.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_CMD_EXIST.AppearanceHeader.GradientMode")));
            this.colCRN_CMD_EXIST.AppearanceHeader.Image = null;
            this.colCRN_CMD_EXIST.AppearanceHeader.Options.UseTextOptions = true;
            this.colCRN_CMD_EXIST.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colCRN_CMD_EXIST, "colCRN_CMD_EXIST");
            this.colCRN_CMD_EXIST.FieldName = "CRN_CMD_EXIST";
            this.colCRN_CMD_EXIST.Name = "colCRN_CMD_EXIST";
            this.colCRN_CMD_EXIST.OptionsColumn.AllowEdit = false;
            this.colCRN_CMD_EXIST.OptionsColumn.ReadOnly = true;
            // 
            // colCRN_READY
            // 
            this.colCRN_READY.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colCRN_READY.AppearanceHeader.GradientMode")));
            this.colCRN_READY.AppearanceHeader.Image = null;
            this.colCRN_READY.AppearanceHeader.Options.UseTextOptions = true;
            this.colCRN_READY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            resources.ApplyResources(this.colCRN_READY, "colCRN_READY");
            this.colCRN_READY.FieldName = "CRN_READY";
            this.colCRN_READY.Name = "colCRN_READY";
            this.colCRN_READY.OptionsColumn.AllowEdit = false;
            this.colCRN_READY.OptionsColumn.ReadOnly = true;
            // 
            // panelControl2
            // 
            this.panelControl2.AccessibleDescription = null;
            this.panelControl2.AccessibleName = null;
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Controls.Add(this.btnForbidden);
            this.panelControl2.Controls.Add(this.btnRedo);
            this.panelControl2.Controls.Add(this.btnManual);
            this.panelControl2.Controls.Add(this.btnErrorLog);
            this.panelControl2.Controls.Add(this.btnReset);
            this.panelControl2.LookAndFeel.SkinName = "Lilian";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            // 
            // btnForbidden
            // 
            this.btnForbidden.AccessibleDescription = null;
            this.btnForbidden.AccessibleName = null;
            resources.ApplyResources(this.btnForbidden, "btnForbidden");
            this.btnForbidden.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.btnForbidden.BackgroundImage = null;
            this.btnForbidden.FlatAppearance.BorderSize = 0;
            this.btnForbidden.ForeColor = System.Drawing.Color.White;
            this.btnForbidden.Image = global::WMS.Properties.Resources.ok_16_White;
            this.btnForbidden.Name = "btnForbidden";
            this.btnForbidden.UseVisualStyleBackColor = false;
            this.btnForbidden.Click += new System.EventHandler(this.btnForbidden_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.AccessibleDescription = null;
            this.btnRedo.AccessibleName = null;
            resources.ApplyResources(this.btnRedo, "btnRedo");
            this.btnRedo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.btnRedo.BackgroundImage = null;
            this.btnRedo.FlatAppearance.BorderSize = 0;
            this.btnRedo.ForeColor = System.Drawing.Color.White;
            this.btnRedo.Image = global::WMS.Properties.Resources.ok_16_White;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.UseVisualStyleBackColor = false;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnManual
            // 
            this.btnManual.AccessibleDescription = null;
            this.btnManual.AccessibleName = null;
            resources.ApplyResources(this.btnManual, "btnManual");
            this.btnManual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.btnManual.BackgroundImage = null;
            this.btnManual.FlatAppearance.BorderSize = 0;
            this.btnManual.ForeColor = System.Drawing.Color.White;
            this.btnManual.Image = global::WMS.Properties.Resources.ok_16_White;
            this.btnManual.Name = "btnManual";
            this.btnManual.UseVisualStyleBackColor = false;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnErrorLog
            // 
            this.btnErrorLog.AccessibleDescription = null;
            this.btnErrorLog.AccessibleName = null;
            resources.ApplyResources(this.btnErrorLog, "btnErrorLog");
            this.btnErrorLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(43)))), ((int)(((byte)(44)))));
            this.btnErrorLog.BackgroundImage = null;
            this.btnErrorLog.FlatAppearance.BorderSize = 0;
            this.btnErrorLog.ForeColor = System.Drawing.Color.White;
            this.btnErrorLog.Image = global::WMS.Properties.Resources.Edit16;
            this.btnErrorLog.Name = "btnErrorLog";
            this.btnErrorLog.UseVisualStyleBackColor = false;
            this.btnErrorLog.Click += new System.EventHandler(this.btnErrorLog_Click);
            // 
            // btnReset
            // 
            this.btnReset.AccessibleDescription = null;
            this.btnReset.AccessibleName = null;
            resources.ApplyResources(this.btnReset, "btnReset");
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnReset.BackgroundImage = null;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Image = global::WMS.Properties.Resources.Reset_16_W;
            this.btnReset.Name = "btnReset";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // tmrAutoRefresh
            // 
            this.tmrAutoRefresh.Interval = 3000;
            this.tmrAutoRefresh.Tick += new System.EventHandler(this.tmrAutoRefresh_Tick);
            // 
            // Fm_A002
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Font = null;
            this.Icon = null;
            this.Name = "Fm_A002";
            this.Load += new System.EventHandler(this.Fm_A002_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAsrsID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoRefresh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WCS_CRN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WCS_CRN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbAsrsID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.CheckEdit chkAutoRefresh;
        private System.Windows.Forms.Button btnColumnSet;
        private System.Windows.Forms.Button btn_Select;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gdc_WCS_CRN;
        private DevExpress.XtraGrid.Views.Grid.GridView gdv_WCS_CRN;
        private DevExpress.XtraGrid.Columns.GridColumn colCHK;
        private DevExpress.XtraGrid.Columns.GridColumn colSER_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colASRS_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colCONNECT_MODE_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colINHIBIT_IN_FLG;
        private DevExpress.XtraGrid.Columns.GridColumn colINHIBIT_OUT_FLG;
        private DevExpress.XtraGrid.Columns.GridColumn colERR_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colERR_CODE_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colFROM_BIN;
        private DevExpress.XtraGrid.Columns.GridColumn colTO_BIN;
        private DevExpress.XtraGrid.Columns.GridColumn colLOADING;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_LOCATION;
        private DevExpress.XtraGrid.Columns.GridColumn colIO;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_SER_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_AUTO;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_INITIAL;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_CMD_COMP;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_NORMAL;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnForbidden;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnErrorLog;
        private System.Windows.Forms.Button btnReset;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_CMD_EXIST;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_READY;
        private System.Windows.Forms.Timer tmrAutoRefresh;
    }
}