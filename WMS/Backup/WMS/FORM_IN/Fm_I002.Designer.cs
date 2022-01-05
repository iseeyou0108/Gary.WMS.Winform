namespace WMS
{
    partial class Fm_I002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_I002));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Insert = new System.Windows.Forms.Button();
            this.txtFilter = new DevExpress.XtraEditors.ButtonEdit();
            this.btnColumnSet = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gdc_CUS_BARCODE_INFO = new DevExpress.XtraGrid.GridControl();
            this.gdv_CUS_BARCODE_INFO = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDelete2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit_Delete = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colPALLET_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_NO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOT_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORG_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORG_SNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRODUCTION_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREMARK2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_DATE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUPDATE_DATE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUPDATE_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_CUS_BARCODE_INFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_CUS_BARCODE_INFO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Delete)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_Insert);
            this.panelControl1.Controls.Add(this.txtFilter);
            this.panelControl1.Controls.Add(this.btnColumnSet);
            this.panelControl1.Controls.Add(this.btn_Select);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Lilian";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1107, 34);
            this.panelControl1.TabIndex = 10;
            // 
            // btn_Insert
            // 
            this.btn_Insert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Insert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(173)))), ((int)(((byte)(78)))));
            this.btn_Insert.FlatAppearance.BorderSize = 0;
            this.btn_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Insert.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Insert.ForeColor = System.Drawing.Color.White;
            this.btn_Insert.Image = global::WMS.Properties.Resources.add_16_White;
            this.btn_Insert.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Insert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Insert.Location = new System.Drawing.Point(5, 6);
            this.btn_Insert.Name = "btn_Insert";
            this.btn_Insert.Size = new System.Drawing.Size(75, 22);
            this.btn_Insert.TabIndex = 11;
            this.btn_Insert.Text = "新增";
            this.btn_Insert.UseVisualStyleBackColor = false;
            this.btn_Insert.Click += new System.EventHandler(this.btn_Insert_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.EditValue = global::WMS.Language.Resource_WCS_TRK.String1;
            this.txtFilter.Location = new System.Drawing.Point(704, 6);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, global::WMS.Language.Resource_WCS_TRK.String1, -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtFilter.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, global::WMS.Language.Resource_WCS_TRK.String1, null, null, true)});
            this.txtFilter.Properties.NullText = "Search someting";
            this.txtFilter.Size = new System.Drawing.Size(213, 22);
            this.txtFilter.TabIndex = 10;
            this.txtFilter.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFilter_ButtonClick);
            this.txtFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilter_KeyDown);
            // 
            // btnColumnSet
            // 
            this.btnColumnSet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColumnSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnColumnSet.FlatAppearance.BorderSize = 0;
            this.btnColumnSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColumnSet.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.btnColumnSet.ForeColor = System.Drawing.Color.White;
            this.btnColumnSet.Image = global::WMS.Properties.Resources.export_16_White;
            this.btnColumnSet.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnColumnSet.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnColumnSet.Location = new System.Drawing.Point(1004, 6);
            this.btnColumnSet.Name = "btnColumnSet";
            this.btnColumnSet.Size = new System.Drawing.Size(91, 22);
            this.btnColumnSet.TabIndex = 9;
            this.btnColumnSet.Text = "欄位設定";
            this.btnColumnSet.UseVisualStyleBackColor = false;
            this.btnColumnSet.Click += new System.EventHandler(this.btnColumnSet_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btn_Select.FlatAppearance.BorderSize = 0;
            this.btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Select.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Select.ForeColor = System.Drawing.Color.White;
            this.btn_Select.Image = global::WMS.Properties.Resources.search_16_White;
            this.btn_Select.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Select.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Select.Location = new System.Drawing.Point(923, 6);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 22);
            this.btn_Select.TabIndex = 4;
            this.btn_Select.Text = "查詢";
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl1.AppearanceCaption.Options.UseFont = true;
            this.groupControl1.Controls.Add(this.gdc_CUS_BARCODE_INFO);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 34);
            this.groupControl1.LookAndFeel.SkinName = "Lilian";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1107, 508);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "組盤資料";
            // 
            // gdc_CUS_BARCODE_INFO
            // 
            this.gdc_CUS_BARCODE_INFO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdc_CUS_BARCODE_INFO.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gdc_CUS_BARCODE_INFO.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gdc_CUS_BARCODE_INFO.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gdc_CUS_BARCODE_INFO.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gdc_CUS_BARCODE_INFO.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gdc_CUS_BARCODE_INFO.EmbeddedNavigator.TextStringFormat = "資料筆數: {0}/{1}";
            this.gdc_CUS_BARCODE_INFO.Location = new System.Drawing.Point(2, 24);
            this.gdc_CUS_BARCODE_INFO.LookAndFeel.SkinName = "Black";
            this.gdc_CUS_BARCODE_INFO.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdc_CUS_BARCODE_INFO.MainView = this.gdv_CUS_BARCODE_INFO;
            this.gdc_CUS_BARCODE_INFO.Name = "gdc_CUS_BARCODE_INFO";
            this.gdc_CUS_BARCODE_INFO.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit_Delete});
            this.gdc_CUS_BARCODE_INFO.Size = new System.Drawing.Size(1103, 482);
            this.gdc_CUS_BARCODE_INFO.TabIndex = 10;
            this.gdc_CUS_BARCODE_INFO.TabStop = false;
            this.gdc_CUS_BARCODE_INFO.UseEmbeddedNavigator = true;
            this.gdc_CUS_BARCODE_INFO.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdv_CUS_BARCODE_INFO});
            // 
            // gdv_CUS_BARCODE_INFO
            // 
            this.gdv_CUS_BARCODE_INFO.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDelete2,
            this.colPALLET_NO,
            this.colLIST_NO2,
            this.colLINE_ID,
            this.colSTATUS,
            this.colSTATUS_DESC,
            this.colPROD_NO,
            this.colPROD_NAME,
            this.colLOT_NO,
            this.colORG_NO,
            this.colORG_SNAME,
            this.colQTY,
            this.colUN,
            this.colPRODUCTION_DATE,
            this.colREMARK2,
            this.colCREATE_DATE2,
            this.colCREATE_NAME2,
            this.colUPDATE_DATE2,
            this.colUPDATE_NAME2});
            this.gdv_CUS_BARCODE_INFO.GridControl = this.gdc_CUS_BARCODE_INFO;
            this.gdv_CUS_BARCODE_INFO.GroupCount = 1;
            this.gdv_CUS_BARCODE_INFO.Name = "gdv_CUS_BARCODE_INFO";
            this.gdv_CUS_BARCODE_INFO.OptionsCustomization.AllowQuickHideColumns = false;
            this.gdv_CUS_BARCODE_INFO.OptionsMenu.EnableColumnMenu = false;
            this.gdv_CUS_BARCODE_INFO.OptionsMenu.EnableFooterMenu = false;
            this.gdv_CUS_BARCODE_INFO.OptionsMenu.EnableGroupPanelMenu = false;
            this.gdv_CUS_BARCODE_INFO.OptionsView.ColumnAutoWidth = false;
            this.gdv_CUS_BARCODE_INFO.OptionsView.EnableAppearanceEvenRow = true;
            this.gdv_CUS_BARCODE_INFO.OptionsView.EnableAppearanceOddRow = true;
            this.gdv_CUS_BARCODE_INFO.OptionsView.ShowGroupPanel = false;
            this.gdv_CUS_BARCODE_INFO.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPALLET_NO, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colDelete2
            // 
            this.colDelete2.ColumnEdit = this.repositoryItemButtonEdit_Delete;
            this.colDelete2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colDelete2.Name = "colDelete2";
            this.colDelete2.Visible = true;
            this.colDelete2.VisibleIndex = 0;
            this.colDelete2.Width = 38;
            // 
            // repositoryItemButtonEdit_Delete
            // 
            this.repositoryItemButtonEdit_Delete.AutoHeight = false;
            this.repositoryItemButtonEdit_Delete.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, global::WMS.Language.Resource_WCS_TRK.String1, -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit_Delete.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, global::WMS.Language.Resource_WCS_TRK.String1, null, null, true)});
            this.repositoryItemButtonEdit_Delete.Name = "repositoryItemButtonEdit_Delete";
            this.repositoryItemButtonEdit_Delete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit_Delete.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit_Delete_ButtonClick);
            // 
            // colPALLET_NO
            // 
            this.colPALLET_NO.Caption = "組盤條碼";
            this.colPALLET_NO.FieldName = "PALLET_NO";
            this.colPALLET_NO.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colPALLET_NO.Name = "colPALLET_NO";
            this.colPALLET_NO.OptionsColumn.AllowEdit = false;
            this.colPALLET_NO.OptionsColumn.ReadOnly = true;
            this.colPALLET_NO.Visible = true;
            this.colPALLET_NO.VisibleIndex = 1;
            this.colPALLET_NO.Width = 100;
            // 
            // colLIST_NO2
            // 
            this.colLIST_NO2.Caption = "單號";
            this.colLIST_NO2.FieldName = "LIST_NO";
            this.colLIST_NO2.Name = "colLIST_NO2";
            this.colLIST_NO2.OptionsColumn.AllowEdit = false;
            this.colLIST_NO2.OptionsColumn.ReadOnly = true;
            this.colLIST_NO2.Visible = true;
            this.colLIST_NO2.VisibleIndex = 3;
            this.colLIST_NO2.Width = 160;
            // 
            // colLINE_ID
            // 
            this.colLINE_ID.AppearanceCell.Options.UseTextOptions = true;
            this.colLINE_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colLINE_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.colLINE_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colLINE_ID.Caption = "項次";
            this.colLINE_ID.FieldName = "LINE_ID";
            this.colLINE_ID.Name = "colLINE_ID";
            this.colLINE_ID.OptionsColumn.AllowEdit = false;
            this.colLINE_ID.OptionsColumn.ReadOnly = true;
            this.colLINE_ID.Visible = true;
            this.colLINE_ID.VisibleIndex = 4;
            this.colLINE_ID.Width = 55;
            // 
            // colSTATUS
            // 
            this.colSTATUS.Caption = "狀態";
            this.colSTATUS.FieldName = "STATUS";
            this.colSTATUS.Name = "colSTATUS";
            this.colSTATUS.OptionsColumn.AllowEdit = false;
            this.colSTATUS.OptionsColumn.ReadOnly = true;
            this.colSTATUS.Visible = true;
            this.colSTATUS.VisibleIndex = 1;
            // 
            // colSTATUS_DESC
            // 
            this.colSTATUS_DESC.Caption = "狀態說明";
            this.colSTATUS_DESC.FieldName = "STATUS_DESC";
            this.colSTATUS_DESC.Name = "colSTATUS_DESC";
            this.colSTATUS_DESC.OptionsColumn.AllowEdit = false;
            this.colSTATUS_DESC.OptionsColumn.ReadOnly = true;
            this.colSTATUS_DESC.Visible = true;
            this.colSTATUS_DESC.VisibleIndex = 2;
            // 
            // colPROD_NO
            // 
            this.colPROD_NO.Caption = "料號";
            this.colPROD_NO.FieldName = "PROD_NO";
            this.colPROD_NO.Name = "colPROD_NO";
            this.colPROD_NO.OptionsColumn.AllowEdit = false;
            this.colPROD_NO.OptionsColumn.ReadOnly = true;
            this.colPROD_NO.Visible = true;
            this.colPROD_NO.VisibleIndex = 5;
            this.colPROD_NO.Width = 120;
            // 
            // colPROD_NAME
            // 
            this.colPROD_NAME.Caption = "物料描述";
            this.colPROD_NAME.FieldName = "PROD_NAME";
            this.colPROD_NAME.Name = "colPROD_NAME";
            this.colPROD_NAME.OptionsColumn.AllowEdit = false;
            this.colPROD_NAME.OptionsColumn.ReadOnly = true;
            this.colPROD_NAME.Visible = true;
            this.colPROD_NAME.VisibleIndex = 6;
            this.colPROD_NAME.Width = 150;
            // 
            // colLOT_NO
            // 
            this.colLOT_NO.Caption = "批號";
            this.colLOT_NO.FieldName = "LOT_NO";
            this.colLOT_NO.Name = "colLOT_NO";
            this.colLOT_NO.OptionsColumn.AllowEdit = false;
            this.colLOT_NO.OptionsColumn.ReadOnly = true;
            this.colLOT_NO.Visible = true;
            this.colLOT_NO.VisibleIndex = 7;
            this.colLOT_NO.Width = 150;
            // 
            // colORG_NO
            // 
            this.colORG_NO.Caption = "客戶代號";
            this.colORG_NO.FieldName = "ORG_NO";
            this.colORG_NO.Name = "colORG_NO";
            this.colORG_NO.OptionsColumn.AllowEdit = false;
            this.colORG_NO.OptionsColumn.ReadOnly = true;
            this.colORG_NO.Visible = true;
            this.colORG_NO.VisibleIndex = 8;
            this.colORG_NO.Width = 90;
            // 
            // colORG_SNAME
            // 
            this.colORG_SNAME.Caption = "客戶";
            this.colORG_SNAME.FieldName = "ORG_SNAME";
            this.colORG_SNAME.Name = "colORG_SNAME";
            this.colORG_SNAME.OptionsColumn.AllowEdit = false;
            this.colORG_SNAME.OptionsColumn.ReadOnly = true;
            this.colORG_SNAME.Visible = true;
            this.colORG_SNAME.VisibleIndex = 9;
            this.colORG_SNAME.Width = 120;
            // 
            // colQTY
            // 
            this.colQTY.AppearanceCell.Options.UseTextOptions = true;
            this.colQTY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQTY.AppearanceHeader.Options.UseTextOptions = true;
            this.colQTY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQTY.Caption = "數量";
            this.colQTY.DisplayFormat.FormatString = "0.00";
            this.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQTY.FieldName = "QTY";
            this.colQTY.Name = "colQTY";
            this.colQTY.OptionsColumn.AllowEdit = false;
            this.colQTY.OptionsColumn.ReadOnly = true;
            this.colQTY.Visible = true;
            this.colQTY.VisibleIndex = 10;
            // 
            // colUN
            // 
            this.colUN.Caption = "單位";
            this.colUN.FieldName = "UN";
            this.colUN.Name = "colUN";
            this.colUN.OptionsColumn.AllowEdit = false;
            this.colUN.OptionsColumn.ReadOnly = true;
            this.colUN.Visible = true;
            this.colUN.VisibleIndex = 11;
            this.colUN.Width = 55;
            // 
            // colPRODUCTION_DATE
            // 
            this.colPRODUCTION_DATE.Caption = "生產日期";
            this.colPRODUCTION_DATE.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.colPRODUCTION_DATE.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colPRODUCTION_DATE.FieldName = "PDATE";
            this.colPRODUCTION_DATE.Name = "colPRODUCTION_DATE";
            this.colPRODUCTION_DATE.OptionsColumn.AllowEdit = false;
            this.colPRODUCTION_DATE.OptionsColumn.ReadOnly = true;
            this.colPRODUCTION_DATE.Visible = true;
            this.colPRODUCTION_DATE.VisibleIndex = 12;
            // 
            // colREMARK2
            // 
            this.colREMARK2.Caption = "備註";
            this.colREMARK2.FieldName = "REMARK";
            this.colREMARK2.Name = "colREMARK2";
            this.colREMARK2.OptionsColumn.AllowEdit = false;
            this.colREMARK2.OptionsColumn.ReadOnly = true;
            this.colREMARK2.Visible = true;
            this.colREMARK2.VisibleIndex = 13;
            // 
            // colCREATE_DATE2
            // 
            this.colCREATE_DATE2.Caption = "建檔時間";
            this.colCREATE_DATE2.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.colCREATE_DATE2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCREATE_DATE2.FieldName = "CREATE_DATE";
            this.colCREATE_DATE2.Name = "colCREATE_DATE2";
            this.colCREATE_DATE2.OptionsColumn.AllowEdit = false;
            this.colCREATE_DATE2.OptionsColumn.ReadOnly = true;
            this.colCREATE_DATE2.Visible = true;
            this.colCREATE_DATE2.VisibleIndex = 14;
            this.colCREATE_DATE2.Width = 130;
            // 
            // colCREATE_NAME2
            // 
            this.colCREATE_NAME2.Caption = "建檔人員";
            this.colCREATE_NAME2.FieldName = "CREATE_NAME";
            this.colCREATE_NAME2.Name = "colCREATE_NAME2";
            this.colCREATE_NAME2.OptionsColumn.AllowEdit = false;
            this.colCREATE_NAME2.OptionsColumn.ReadOnly = true;
            this.colCREATE_NAME2.Visible = true;
            this.colCREATE_NAME2.VisibleIndex = 15;
            // 
            // colUPDATE_DATE2
            // 
            this.colUPDATE_DATE2.Caption = "最後異動時間";
            this.colUPDATE_DATE2.DisplayFormat.FormatString = "yyyy/MM/dd HH:mm:ss";
            this.colUPDATE_DATE2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colUPDATE_DATE2.FieldName = "UPDATE_DATE";
            this.colUPDATE_DATE2.Name = "colUPDATE_DATE2";
            this.colUPDATE_DATE2.OptionsColumn.AllowEdit = false;
            this.colUPDATE_DATE2.OptionsColumn.ReadOnly = true;
            this.colUPDATE_DATE2.Width = 130;
            // 
            // colUPDATE_NAME2
            // 
            this.colUPDATE_NAME2.Caption = "最後異動人員";
            this.colUPDATE_NAME2.FieldName = "UPDATE_NAME";
            this.colUPDATE_NAME2.Name = "colUPDATE_NAME2";
            this.colUPDATE_NAME2.OptionsColumn.AllowEdit = false;
            this.colUPDATE_NAME2.OptionsColumn.ReadOnly = true;
            this.colUPDATE_NAME2.Width = 81;
            // 
            // Fm_I002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 542);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Fm_I002";
            this.Text = "Fm_I002";
            this.Load += new System.EventHandler(this.Fm_I002_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdc_CUS_BARCODE_INFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_CUS_BARCODE_INFO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_Delete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnColumnSet;
        private System.Windows.Forms.Button btn_Select;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gdc_CUS_BARCODE_INFO;
        private DevExpress.XtraGrid.Views.Grid.GridView gdv_CUS_BARCODE_INFO;
        private DevExpress.XtraGrid.Columns.GridColumn colDelete2;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit_Delete;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_NO2;
        private DevExpress.XtraGrid.Columns.GridColumn colLINE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colPALLET_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLOT_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colORG_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colORG_SNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
        private DevExpress.XtraGrid.Columns.GridColumn colUN;
        private DevExpress.XtraGrid.Columns.GridColumn colPRODUCTION_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colREMARK2;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_DATE2;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn colUPDATE_DATE2;
        private DevExpress.XtraGrid.Columns.GridColumn colUPDATE_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS_DESC;
        private DevExpress.XtraEditors.ButtonEdit txtFilter;
        private System.Windows.Forms.Button btn_Insert;
    }
}