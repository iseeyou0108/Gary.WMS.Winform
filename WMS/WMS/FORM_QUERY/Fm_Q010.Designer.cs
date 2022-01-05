namespace WMS
{
    partial class Fm_Q010
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_Q010));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colSTUS_CTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Insert = new System.Windows.Forms.Button();
            this.cmbProdNo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAsrsID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnColumnSet = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.txtFilter = new DevExpress.XtraEditors.ButtonEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gdc_WMS_STK = new DevExpress.XtraGrid.GridControl();
            this.gdv_WMS_STK = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEdit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit_Edit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colDelete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
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
            this.repositoryItemCheckEdit_CHK = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAsrsID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WMS_STK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WMS_STK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Edit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Delete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_CHK)).BeginInit();
            this.SuspendLayout();
            // 
            // colSTUS_CTR
            // 
            resources.ApplyResources(this.colSTUS_CTR, "colSTUS_CTR");
            this.colSTUS_CTR.FieldName = "STUS_CTR";
            this.colSTUS_CTR.Name = "colSTUS_CTR";
            this.colSTUS_CTR.OptionsColumn.AllowEdit = false;
            this.colSTUS_CTR.OptionsColumn.ReadOnly = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_Insert);
            this.panelControl1.Controls.Add(this.cmbProdNo);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.cmbAsrsID);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnColumnSet);
            this.panelControl1.Controls.Add(this.btn_Select);
            this.panelControl1.Controls.Add(this.txtFilter);
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.LookAndFeel.SkinName = "Lilian";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            // 
            // btn_Insert
            // 
            resources.ApplyResources(this.btn_Insert, "btn_Insert");
            this.btn_Insert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btn_Insert.FlatAppearance.BorderSize = 0;
            this.btn_Insert.ForeColor = System.Drawing.Color.White;
            this.btn_Insert.Image = global::WMS.Properties.Resources.add_16_White;
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.UseVisualStyleBackColor = false;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // cmbProdNo
            // 
            resources.ApplyResources(this.cmbProdNo, "cmbProdNo");
            this.cmbProdNo.Name = "cmbProdNo";
            this.cmbProdNo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbProdNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cmbProdNo.Properties.Buttons"))))});
            this.cmbProdNo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbProdNo.Properties.Columns"), resources.GetString("cmbProdNo.Properties.Columns1")),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbProdNo.Properties.Columns2"), ((int)(resources.GetObject("cmbProdNo.Properties.Columns3"))), resources.GetString("cmbProdNo.Properties.Columns4"))});
            this.cmbProdNo.Properties.DropDownRows = 10;
            this.cmbProdNo.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
            this.cmbProdNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbProdNo_KeyUp);
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
            // btnColumnSet
            // 
            resources.ApplyResources(this.btnColumnSet, "btnColumnSet");
            this.btnColumnSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnColumnSet.FlatAppearance.BorderSize = 0;
            this.btnColumnSet.ForeColor = System.Drawing.Color.White;
            this.btnColumnSet.Image = global::WMS.Properties.Resources.export_16_White;
            this.btnColumnSet.Name = "btnColumnSet";
            this.btnColumnSet.UseVisualStyleBackColor = false;
            this.btnColumnSet.Click += new System.EventHandler(this.btnColumnSet_Click);
            // 
            // btn_Select
            // 
            resources.ApplyResources(this.btn_Select, "btn_Select");
            this.btn_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
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
            this.txtFilter.EditValue = global::WMS.Language.Resource_WCS_TRK.String1;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.NullText = resources.GetString("txtFilter.Properties.NullText");
            this.txtFilter.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFilter_ButtonClick);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gdc_WMS_STK);
            resources.ApplyResources(this.groupControl1, "groupControl1");
            this.groupControl1.LookAndFeel.SkinName = "Lilian";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
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
            // gdv_WMS_STK
            // 
            this.gdv_WMS_STK.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEdit,
            this.colDelete,
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
            this.gdv_WMS_STK.OptionsView.ShowAutoFilterRow = true;
            this.gdv_WMS_STK.OptionsView.ShowGroupPanel = false;
            this.gdv_WMS_STK.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gdv_WMS_STK_CustomDrawCell);
            // 
            // colEdit
            // 
            this.colEdit.ColumnEdit = this.repositoryItemButtonEdit_Edit;
            this.colEdit.Name = "colEdit";
            resources.ApplyResources(this.colEdit, "colEdit");
            // 
            // repositoryItemButtonEdit_Edit
            // 
            resources.ApplyResources(this.repositoryItemButtonEdit_Edit, "repositoryItemButtonEdit_Edit");
            this.repositoryItemButtonEdit_Edit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemButtonEdit_Edit.Buttons"))), global::WMS.Language.Resource_WCS_TRK.String1, ((int)(resources.GetObject("repositoryItemButtonEdit_Edit.Buttons1"))), ((bool)(resources.GetObject("repositoryItemButtonEdit_Edit.Buttons2"))), ((bool)(resources.GetObject("repositoryItemButtonEdit_Edit.Buttons3"))), ((bool)(resources.GetObject("repositoryItemButtonEdit_Edit.Buttons4"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("repositoryItemButtonEdit_Edit.Buttons5"))), ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit_Edit.Buttons6"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, global::WMS.Language.Resource_WCS_TRK.String1, null, null, ((bool)(resources.GetObject("repositoryItemButtonEdit_Edit.Buttons7"))))});
            this.repositoryItemButtonEdit_Edit.Name = "repositoryItemButtonEdit_Edit";
            this.repositoryItemButtonEdit_Edit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit_Edit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit_Edit_ButtonClick);
            // 
            // colDelete
            // 
            this.colDelete.ColumnEdit = this.repositoryItemButtonEdit_Delete;
            this.colDelete.Name = "colDelete";
            resources.ApplyResources(this.colDelete, "colDelete");
            // 
            // repositoryItemButtonEdit_Delete
            // 
            resources.ApplyResources(this.repositoryItemButtonEdit_Delete, "repositoryItemButtonEdit_Delete");
            this.repositoryItemButtonEdit_Delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repositoryItemButtonEdit_Delete.Buttons"))), global::WMS.Language.Resource_WCS_TRK.String1, ((int)(resources.GetObject("repositoryItemButtonEdit_Delete.Buttons1"))), ((bool)(resources.GetObject("repositoryItemButtonEdit_Delete.Buttons2"))), ((bool)(resources.GetObject("repositoryItemButtonEdit_Delete.Buttons3"))), ((bool)(resources.GetObject("repositoryItemButtonEdit_Delete.Buttons4"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("repositoryItemButtonEdit_Delete.Buttons5"))), ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit_Delete.Buttons6"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, global::WMS.Language.Resource_WCS_TRK.String1, null, null, ((bool)(resources.GetObject("repositoryItemButtonEdit_Delete.Buttons7"))))});
            this.repositoryItemButtonEdit_Delete.Name = "repositoryItemButtonEdit_Delete";
            this.repositoryItemButtonEdit_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit_Delete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit_Delete_ButtonClick);
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
            resources.ApplyResources(this.colSDATE, "colSDATE");
            this.colSDATE.FieldName = "SDATE";
            this.colSDATE.Name = "colSDATE";
            this.colSDATE.OptionsColumn.AllowEdit = false;
            this.colSDATE.OptionsColumn.ReadOnly = true;
            // 
            // colPDATE
            // 
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
            // Fm_Q010
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Fm_Q010";
            this.Load += new System.EventHandler(this.Fm_Q010_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Edit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Delete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_CHK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnColumnSet;
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
        private DevExpress.XtraGrid.Columns.GridColumn colBIN_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSDATE;
        private DevExpress.XtraGrid.Columns.GridColumn colSTUS_CTR;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_TYPE_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colQC_RESULT;
        private System.Windows.Forms.Button btn_Insert;
        private DevExpress.XtraGrid.Columns.GridColumn colEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete;
    }
}