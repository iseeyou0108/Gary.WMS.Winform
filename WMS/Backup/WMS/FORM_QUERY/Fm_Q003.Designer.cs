namespace WMS
{
    partial class Fm_Q003
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_Q003));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbProdNo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAsrsID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnColumnSet = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.txtFilter = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gdc_WMS_STK = new DevExpress.XtraGrid.GridControl();
            this.gdv_WMS_STK = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colWH_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASRS_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_TYPE_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOT_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORG_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORG_SNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTUS_CTR_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQC_RESULT_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPDATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_CHK = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemButtonEdit_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemButtonEdit_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAsrsID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WMS_STK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WMS_STK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_CHK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Edit)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.AccessibleDescription = null;
            this.panelControl1.AccessibleName = null;
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Controls.Add(this.cmbProdNo);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.cmbAsrsID);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnColumnSet);
            this.panelControl1.Controls.Add(this.btnExport);
            this.panelControl1.Controls.Add(this.btnPrint);
            this.panelControl1.Controls.Add(this.btn_Select);
            this.panelControl1.Controls.Add(this.txtFilter);
            this.panelControl1.LookAndFeel.SkinName = "Lilian";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            // 
            // cmbProdNo
            // 
            resources.ApplyResources(this.cmbProdNo, "cmbProdNo");
            this.cmbProdNo.BackgroundImage = null;
            this.cmbProdNo.EditValue = null;
            this.cmbProdNo.Name = "cmbProdNo";
            this.cmbProdNo.Properties.AccessibleDescription = null;
            this.cmbProdNo.Properties.AccessibleName = null;
            this.cmbProdNo.Properties.AutoHeight = ((bool)(resources.GetObject("cmbProdNo.Properties.AutoHeight")));
            this.cmbProdNo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbProdNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cmbProdNo.Properties.Buttons"))))});
            this.cmbProdNo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbProdNo.Properties.Columns"), resources.GetString("cmbProdNo.Properties.Columns1")),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbProdNo.Properties.Columns2"), ((int)(resources.GetObject("cmbProdNo.Properties.Columns3"))), resources.GetString("cmbProdNo.Properties.Columns4"))});
            this.cmbProdNo.Properties.DropDownRows = 10;
            this.cmbProdNo.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
            this.cmbProdNo.Properties.NullValuePrompt = resources.GetString("cmbProdNo.Properties.NullValuePrompt");
            this.cmbProdNo.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cmbProdNo.Properties.NullValuePromptShowForEmptyValue")));
            this.cmbProdNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbProdNo_KeyUp);
            // 
            // labelControl2
            // 
            this.labelControl2.AccessibleDescription = null;
            this.labelControl2.AccessibleName = null;
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
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
            this.cmbAsrsID.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
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
            // btnExport
            // 
            this.btnExport.AccessibleDescription = null;
            this.btnExport.AccessibleName = null;
            resources.ApplyResources(this.btnExport, "btnExport");
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnExport.BackgroundImage = null;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Image = global::WMS.Properties.Resources.export_16_White;
            this.btnExport.Name = "btnExport";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.AccessibleDescription = null;
            this.btnPrint.AccessibleName = null;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btnPrint.BackgroundImage = null;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Image = global::WMS.Properties.Resources.printer_16_White;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            // txtFilter
            // 
            resources.ApplyResources(this.txtFilter, "txtFilter");
            this.txtFilter.BackgroundImage = null;
            this.txtFilter.EditValue = global::WMS.Language.Resource_WCS_TRK.String1;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.AccessibleDescription = null;
            this.txtFilter.Properties.AccessibleName = null;
            this.txtFilter.Properties.AutoHeight = ((bool)(resources.GetObject("txtFilter.Properties.AutoHeight")));
            this.txtFilter.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtFilter.Properties.Mask.AutoComplete")));
            this.txtFilter.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtFilter.Properties.Mask.BeepOnError")));
            this.txtFilter.Properties.Mask.EditMask = resources.GetString("txtFilter.Properties.Mask.EditMask");
            this.txtFilter.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtFilter.Properties.Mask.IgnoreMaskBlank")));
            this.txtFilter.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtFilter.Properties.Mask.MaskType")));
            this.txtFilter.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtFilter.Properties.Mask.PlaceHolder")));
            this.txtFilter.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtFilter.Properties.Mask.SaveLiteral")));
            this.txtFilter.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtFilter.Properties.Mask.ShowPlaceHolders")));
            this.txtFilter.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtFilter.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtFilter.Properties.NullText = resources.GetString("txtFilter.Properties.NullText");
            this.txtFilter.Properties.NullValuePrompt = resources.GetString("txtFilter.Properties.NullValuePrompt");
            this.txtFilter.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtFilter.Properties.NullValuePromptShowForEmptyValue")));
            this.txtFilter.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFilter_ButtonClick);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // groupControl1
            // 
            this.groupControl1.AccessibleDescription = null;
            this.groupControl1.AccessibleName = null;
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.Controls.Add(this.gdc_WMS_STK);
            this.groupControl1.LookAndFeel.SkinName = "Lilian";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            // 
            // gdc_WMS_STK
            // 
            this.gdc_WMS_STK.AccessibleDescription = null;
            this.gdc_WMS_STK.AccessibleName = null;
            resources.ApplyResources(this.gdc_WMS_STK, "gdc_WMS_STK");
            this.gdc_WMS_STK.BackgroundImage = null;
            this.gdc_WMS_STK.EmbeddedNavigator.AccessibleDescription = null;
            this.gdc_WMS_STK.EmbeddedNavigator.AccessibleName = null;
            this.gdc_WMS_STK.EmbeddedNavigator.AllowHtmlTextInToolTip = ((DevExpress.Utils.DefaultBoolean)(resources.GetObject("gdc_WMS_STK.EmbeddedNavigator.AllowHtmlTextInToolTip")));
            this.gdc_WMS_STK.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("gdc_WMS_STK.EmbeddedNavigator.Anchor")));
            this.gdc_WMS_STK.EmbeddedNavigator.BackgroundImage = null;
            this.gdc_WMS_STK.EmbeddedNavigator.BackgroundImageLayout = ((System.Windows.Forms.ImageLayout)(resources.GetObject("gdc_WMS_STK.EmbeddedNavigator.BackgroundImageLayout")));
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Append.Hint = resources.GetString("gdc_WMS_STK.EmbeddedNavigator.Buttons.Append.Hint");
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.CancelEdit.Hint = resources.GetString("gdc_WMS_STK.EmbeddedNavigator.Buttons.CancelEdit.Hint");
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Edit.Hint = resources.GetString("gdc_WMS_STK.EmbeddedNavigator.Buttons.Edit.Hint");
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.EndEdit.Hint = resources.GetString("gdc_WMS_STK.EmbeddedNavigator.Buttons.EndEdit.Hint");
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Remove.Hint = resources.GetString("gdc_WMS_STK.EmbeddedNavigator.Buttons.Remove.Hint");
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("gdc_WMS_STK.EmbeddedNavigator.ImeMode")));
            this.gdc_WMS_STK.EmbeddedNavigator.TextLocation = ((DevExpress.XtraEditors.NavigatorButtonsTextLocation)(resources.GetObject("gdc_WMS_STK.EmbeddedNavigator.TextLocation")));
            this.gdc_WMS_STK.EmbeddedNavigator.TextStringFormat = resources.GetString("gdc_WMS_STK.EmbeddedNavigator.TextStringFormat");
            this.gdc_WMS_STK.EmbeddedNavigator.ToolTip = resources.GetString("gdc_WMS_STK.EmbeddedNavigator.ToolTip");
            this.gdc_WMS_STK.EmbeddedNavigator.ToolTipIconType = ((DevExpress.Utils.ToolTipIconType)(resources.GetObject("gdc_WMS_STK.EmbeddedNavigator.ToolTipIconType")));
            this.gdc_WMS_STK.EmbeddedNavigator.ToolTipTitle = resources.GetString("gdc_WMS_STK.EmbeddedNavigator.ToolTipTitle");
            this.gdc_WMS_STK.Font = null;
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
            // gdv_WMS_STK
            // 
            resources.ApplyResources(this.gdv_WMS_STK, "gdv_WMS_STK");
            this.gdv_WMS_STK.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colWH_NO,
            this.colASRS_ID,
            this.colPROD_NO,
            this.colPROD_NAME,
            this.colPROD_TYPE_DESC,
            this.colLOT_NO,
            this.colORG_NO,
            this.colORG_SNAME,
            this.colSTUS_CTR_DESC,
            this.colQC_RESULT_DESC,
            this.colQTY,
            this.colPDATE,
            this.colUN});
            this.gdv_WMS_STK.GridControl = this.gdc_WMS_STK;
            this.gdv_WMS_STK.Name = "gdv_WMS_STK";
            this.gdv_WMS_STK.OptionsCustomization.AllowQuickHideColumns = false;
            this.gdv_WMS_STK.OptionsMenu.EnableColumnMenu = false;
            this.gdv_WMS_STK.OptionsMenu.EnableFooterMenu = false;
            this.gdv_WMS_STK.OptionsMenu.EnableGroupPanelMenu = false;
            this.gdv_WMS_STK.OptionsView.ColumnAutoWidth = false;
            this.gdv_WMS_STK.OptionsView.EnableAppearanceEvenRow = true;
            this.gdv_WMS_STK.OptionsView.EnableAppearanceOddRow = true;
            this.gdv_WMS_STK.OptionsView.ShowAutoFilterRow = true;
            this.gdv_WMS_STK.OptionsView.ShowGroupPanel = false;
            this.gdv_WMS_STK.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gdv_WMS_STK_CustomDrawCell);
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
            // colQC_RESULT_DESC
            // 
            resources.ApplyResources(this.colQC_RESULT_DESC, "colQC_RESULT_DESC");
            this.colQC_RESULT_DESC.FieldName = "QC_RESULT_DESC";
            this.colQC_RESULT_DESC.Name = "colQC_RESULT_DESC";
            this.colQC_RESULT_DESC.OptionsColumn.AllowEdit = false;
            this.colQC_RESULT_DESC.OptionsColumn.ReadOnly = true;
            // 
            // colQTY
            // 
            this.colQTY.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colQTY.AppearanceCell.GradientMode")));
            this.colQTY.AppearanceCell.Image = null;
            this.colQTY.AppearanceCell.Options.UseTextOptions = true;
            this.colQTY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQTY.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colQTY.AppearanceHeader.GradientMode")));
            this.colQTY.AppearanceHeader.Image = null;
            this.colQTY.AppearanceHeader.Options.UseTextOptions = true;
            this.colQTY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            resources.ApplyResources(this.colQTY, "colQTY");
            this.colQTY.FieldName = "QTY";
            this.colQTY.Name = "colQTY";
            this.colQTY.OptionsColumn.AllowEdit = false;
            this.colQTY.OptionsColumn.ReadOnly = true;
            // 
            // colPDATE
            // 
            this.colPDATE.AppearanceCell.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colPDATE.AppearanceCell.GradientMode")));
            this.colPDATE.AppearanceCell.Image = null;
            this.colPDATE.AppearanceCell.Options.UseTextOptions = true;
            this.colPDATE.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPDATE.AppearanceHeader.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("colPDATE.AppearanceHeader.GradientMode")));
            this.colPDATE.AppearanceHeader.Image = null;
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
            // repositoryItemCheckEdit_CHK
            // 
            this.repositoryItemCheckEdit_CHK.AccessibleDescription = null;
            this.repositoryItemCheckEdit_CHK.AccessibleName = null;
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
            this.repositoryItemButtonEdit_Delete.AccessibleDescription = null;
            this.repositoryItemButtonEdit_Delete.AccessibleName = null;
            resources.ApplyResources(this.repositoryItemButtonEdit_Delete, "repositoryItemButtonEdit_Delete");
            this.repositoryItemButtonEdit_Delete.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("repositoryItemButtonEdit_Delete.Mask.AutoComplete")));
            this.repositoryItemButtonEdit_Delete.Mask.BeepOnError = ((bool)(resources.GetObject("repositoryItemButtonEdit_Delete.Mask.BeepOnError")));
            this.repositoryItemButtonEdit_Delete.Mask.EditMask = resources.GetString("repositoryItemButtonEdit_Delete.Mask.EditMask");
            this.repositoryItemButtonEdit_Delete.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("repositoryItemButtonEdit_Delete.Mask.IgnoreMaskBlank")));
            this.repositoryItemButtonEdit_Delete.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemButtonEdit_Delete.Mask.MaskType")));
            this.repositoryItemButtonEdit_Delete.Mask.PlaceHolder = ((char)(resources.GetObject("repositoryItemButtonEdit_Delete.Mask.PlaceHolder")));
            this.repositoryItemButtonEdit_Delete.Mask.SaveLiteral = ((bool)(resources.GetObject("repositoryItemButtonEdit_Delete.Mask.SaveLiteral")));
            this.repositoryItemButtonEdit_Delete.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("repositoryItemButtonEdit_Delete.Mask.ShowPlaceHolders")));
            this.repositoryItemButtonEdit_Delete.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemButtonEdit_Delete.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemButtonEdit_Delete.Name = "repositoryItemButtonEdit_Delete";
            this.repositoryItemButtonEdit_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemButtonEdit_Edit
            // 
            this.repositoryItemButtonEdit_Edit.AccessibleDescription = null;
            this.repositoryItemButtonEdit_Edit.AccessibleName = null;
            resources.ApplyResources(this.repositoryItemButtonEdit_Edit, "repositoryItemButtonEdit_Edit");
            this.repositoryItemButtonEdit_Edit.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("repositoryItemButtonEdit_Edit.Mask.AutoComplete")));
            this.repositoryItemButtonEdit_Edit.Mask.BeepOnError = ((bool)(resources.GetObject("repositoryItemButtonEdit_Edit.Mask.BeepOnError")));
            this.repositoryItemButtonEdit_Edit.Mask.EditMask = resources.GetString("repositoryItemButtonEdit_Edit.Mask.EditMask");
            this.repositoryItemButtonEdit_Edit.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("repositoryItemButtonEdit_Edit.Mask.IgnoreMaskBlank")));
            this.repositoryItemButtonEdit_Edit.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("repositoryItemButtonEdit_Edit.Mask.MaskType")));
            this.repositoryItemButtonEdit_Edit.Mask.PlaceHolder = ((char)(resources.GetObject("repositoryItemButtonEdit_Edit.Mask.PlaceHolder")));
            this.repositoryItemButtonEdit_Edit.Mask.SaveLiteral = ((bool)(resources.GetObject("repositoryItemButtonEdit_Edit.Mask.SaveLiteral")));
            this.repositoryItemButtonEdit_Edit.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("repositoryItemButtonEdit_Edit.Mask.ShowPlaceHolders")));
            this.repositoryItemButtonEdit_Edit.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("repositoryItemButtonEdit_Edit.Mask.UseMaskAsDisplayFormat")));
            this.repositoryItemButtonEdit_Edit.Name = "repositoryItemButtonEdit_Edit";
            this.repositoryItemButtonEdit_Edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // Fm_Q003
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
            this.Name = "Fm_Q003";
            this.Load += new System.EventHandler(this.Fm_Q003_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAsrsID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WMS_STK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WMS_STK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_CHK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Edit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnColumnSet;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btn_Select;
        private DevExpress.XtraEditors.ButtonEdit txtFilter;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gdc_WMS_STK;
        private DevExpress.XtraGrid.Views.Grid.GridView gdv_WMS_STK;
        private DevExpress.XtraGrid.Columns.GridColumn colWH_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colASRS_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colLOT_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colORG_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSTUS_CTR_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
        private DevExpress.XtraGrid.Columns.GridColumn colPDATE;
        private DevExpress.XtraGrid.Columns.GridColumn colUN;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_CHK;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit_Delete;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit_Edit;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NAME;
        private DevExpress.XtraEditors.LookUpEdit cmbAsrsID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbProdNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colORG_SNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_TYPE_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colQC_RESULT_DESC;
    }
}