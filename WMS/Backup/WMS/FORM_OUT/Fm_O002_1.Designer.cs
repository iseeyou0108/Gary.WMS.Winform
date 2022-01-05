namespace WMS
{
    partial class Fm_O002_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_O002_1));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtFilter = new DevExpress.XtraEditors.ButtonEdit();
            this.cmbListNo = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Select = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gdc_WMS_OUT_LINE = new DevExpress.XtraGrid.GridControl();
            this.gdv_WMS_OUT_LINE = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCHK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLIST_NO2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLINE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colERP_LIST_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colERP_LIST_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colERP_LINE_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS_CTR_DESC2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOT_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORG_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWMS_QTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTMP_QTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRODUCTION_DATE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colREMARK2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_DATE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCREATE_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUPDATE_DATE2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUPDATE_NAME2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbListNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WMS_OUT_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WMS_OUT_LINE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.txtFilter);
            this.panelControl1.Controls.Add(this.cmbListNo);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.btn_Select);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Lilian";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1418, 34);
            this.panelControl1.TabIndex = 8;
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.EditValue = "";
            this.txtFilter.Location = new System.Drawing.Point(1112, 6);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleRight, ((System.Drawing.Image)(resources.GetObject("txtFilter.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.txtFilter.Properties.NullText = "Search someting";
            this.txtFilter.Size = new System.Drawing.Size(213, 22);
            this.txtFilter.TabIndex = 17;
            this.txtFilter.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtFilter_ButtonClick);
            this.txtFilter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilter_KeyPress);
            // 
            // cmbListNo
            // 
            this.cmbListNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbListNo.Location = new System.Drawing.Point(933, 6);
            this.cmbListNo.Name = "cmbListNo";
            this.cmbListNo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbListNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbListNo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "單據狀態")});
            this.cmbListNo.Properties.DropDownRows = 10;
            this.cmbListNo.Properties.NullText = "";
            this.cmbListNo.Size = new System.Drawing.Size(173, 21);
            this.cmbListNo.TabIndex = 16;
            this.cmbListNo.QueryCloseUp += new System.ComponentModel.CancelEventHandler(this.cmbListNo_QueryCloseUp);
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(903, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "單號";
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
            this.btn_Select.Location = new System.Drawing.Point(1331, 6);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 22);
            this.btn_Select.TabIndex = 4;
            this.btn_Select.Text = "查詢";
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gdc_WMS_OUT_LINE);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 34);
            this.groupControl1.LookAndFeel.SkinName = "Lilian";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(3);
            this.groupControl1.Size = new System.Drawing.Size(1418, 457);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "出庫單據資料";
            // 
            // gdc_WMS_OUT_LINE
            // 
            this.gdc_WMS_OUT_LINE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdc_WMS_OUT_LINE.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gdc_WMS_OUT_LINE.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gdc_WMS_OUT_LINE.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gdc_WMS_OUT_LINE.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gdc_WMS_OUT_LINE.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gdc_WMS_OUT_LINE.EmbeddedNavigator.TextStringFormat = "資料筆數: {0}/{1}";
            this.gdc_WMS_OUT_LINE.Location = new System.Drawing.Point(5, 26);
            this.gdc_WMS_OUT_LINE.LookAndFeel.SkinName = "Black";
            this.gdc_WMS_OUT_LINE.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdc_WMS_OUT_LINE.MainView = this.gdv_WMS_OUT_LINE;
            this.gdc_WMS_OUT_LINE.Name = "gdc_WMS_OUT_LINE";
            this.gdc_WMS_OUT_LINE.Size = new System.Drawing.Size(1408, 426);
            this.gdc_WMS_OUT_LINE.TabIndex = 6;
            this.gdc_WMS_OUT_LINE.TabStop = false;
            this.gdc_WMS_OUT_LINE.UseEmbeddedNavigator = true;
            this.gdc_WMS_OUT_LINE.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdv_WMS_OUT_LINE});
            // 
            // gdv_WMS_OUT_LINE
            // 
            this.gdv_WMS_OUT_LINE.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCHK,
            this.colLIST_NO2,
            this.colLINE_ID,
            this.colERP_LIST_TYPE,
            this.colERP_LIST_NO,
            this.colERP_LINE_ID,
            this.colSTATUS_CTR_DESC2,
            this.colPROD_NO,
            this.colPROD_NAME,
            this.colLOT_NO,
            this.colORG_NO,
            this.colSNAME,
            this.colQTY,
            this.colWMS_QTY,
            this.colTMP_QTY,
            this.colUN,
            this.colPRODUCTION_DATE,
            this.colREMARK2,
            this.colCREATE_DATE2,
            this.colCREATE_NAME2,
            this.colUPDATE_DATE2,
            this.colUPDATE_NAME2});
            this.gdv_WMS_OUT_LINE.GridControl = this.gdc_WMS_OUT_LINE;
            this.gdv_WMS_OUT_LINE.Name = "gdv_WMS_OUT_LINE";
            this.gdv_WMS_OUT_LINE.OptionsCustomization.AllowQuickHideColumns = false;
            this.gdv_WMS_OUT_LINE.OptionsMenu.EnableColumnMenu = false;
            this.gdv_WMS_OUT_LINE.OptionsMenu.EnableFooterMenu = false;
            this.gdv_WMS_OUT_LINE.OptionsMenu.EnableGroupPanelMenu = false;
            this.gdv_WMS_OUT_LINE.OptionsView.ColumnAutoWidth = false;
            this.gdv_WMS_OUT_LINE.OptionsView.EnableAppearanceEvenRow = true;
            this.gdv_WMS_OUT_LINE.OptionsView.EnableAppearanceOddRow = true;
            this.gdv_WMS_OUT_LINE.OptionsView.ShowAutoFilterRow = true;
            this.gdv_WMS_OUT_LINE.OptionsView.ShowGroupPanel = false;
            this.gdv_WMS_OUT_LINE.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gdv_WMS_OUT_LINE_CellValueChanged);
            // 
            // colCHK
            // 
            this.colCHK.Caption = "選取";
            this.colCHK.FieldName = "CHK";
            this.colCHK.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colCHK.Name = "colCHK";
            this.colCHK.Visible = true;
            this.colCHK.VisibleIndex = 0;
            this.colCHK.Width = 35;
            // 
            // colLIST_NO2
            // 
            this.colLIST_NO2.Caption = "單號";
            this.colLIST_NO2.FieldName = "LIST_NO";
            this.colLIST_NO2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colLIST_NO2.Name = "colLIST_NO2";
            this.colLIST_NO2.OptionsColumn.AllowEdit = false;
            this.colLIST_NO2.OptionsColumn.ReadOnly = true;
            this.colLIST_NO2.Visible = true;
            this.colLIST_NO2.VisibleIndex = 1;
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
            this.colLINE_ID.VisibleIndex = 2;
            this.colLINE_ID.Width = 55;
            // 
            // colERP_LIST_TYPE
            // 
            this.colERP_LIST_TYPE.Caption = "ERP單據類型";
            this.colERP_LIST_TYPE.FieldName = "ERP_LIST_TYPE";
            this.colERP_LIST_TYPE.Name = "colERP_LIST_TYPE";
            this.colERP_LIST_TYPE.OptionsColumn.AllowEdit = false;
            this.colERP_LIST_TYPE.OptionsColumn.ReadOnly = true;
            this.colERP_LIST_TYPE.Visible = true;
            this.colERP_LIST_TYPE.VisibleIndex = 3;
            this.colERP_LIST_TYPE.Width = 100;
            // 
            // colERP_LIST_NO
            // 
            this.colERP_LIST_NO.Caption = "ERP單號";
            this.colERP_LIST_NO.FieldName = "ERP_LIST_NO";
            this.colERP_LIST_NO.Name = "colERP_LIST_NO";
            this.colERP_LIST_NO.OptionsColumn.AllowEdit = false;
            this.colERP_LIST_NO.OptionsColumn.ReadOnly = true;
            this.colERP_LIST_NO.Visible = true;
            this.colERP_LIST_NO.VisibleIndex = 4;
            this.colERP_LIST_NO.Width = 160;
            // 
            // colERP_LINE_ID
            // 
            this.colERP_LINE_ID.AppearanceCell.Options.UseTextOptions = true;
            this.colERP_LINE_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colERP_LINE_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.colERP_LINE_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colERP_LINE_ID.Caption = "ERP項次";
            this.colERP_LINE_ID.FieldName = "ERP_LINE_ID";
            this.colERP_LINE_ID.Name = "colERP_LINE_ID";
            this.colERP_LINE_ID.OptionsColumn.AllowEdit = false;
            this.colERP_LINE_ID.OptionsColumn.ReadOnly = true;
            this.colERP_LINE_ID.Visible = true;
            this.colERP_LINE_ID.VisibleIndex = 5;
            this.colERP_LINE_ID.Width = 65;
            // 
            // colSTATUS_CTR_DESC2
            // 
            this.colSTATUS_CTR_DESC2.Caption = "單據狀態";
            this.colSTATUS_CTR_DESC2.FieldName = "STATUS_CTR_DESC";
            this.colSTATUS_CTR_DESC2.Name = "colSTATUS_CTR_DESC2";
            this.colSTATUS_CTR_DESC2.OptionsColumn.AllowEdit = false;
            this.colSTATUS_CTR_DESC2.OptionsColumn.ReadOnly = true;
            this.colSTATUS_CTR_DESC2.Visible = true;
            this.colSTATUS_CTR_DESC2.VisibleIndex = 6;
            this.colSTATUS_CTR_DESC2.Width = 90;
            // 
            // colPROD_NO
            // 
            this.colPROD_NO.Caption = "料號";
            this.colPROD_NO.FieldName = "PROD_NO";
            this.colPROD_NO.Name = "colPROD_NO";
            this.colPROD_NO.OptionsColumn.AllowEdit = false;
            this.colPROD_NO.OptionsColumn.ReadOnly = true;
            this.colPROD_NO.Visible = true;
            this.colPROD_NO.VisibleIndex = 7;
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
            this.colPROD_NAME.VisibleIndex = 8;
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
            this.colLOT_NO.VisibleIndex = 9;
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
            this.colORG_NO.VisibleIndex = 10;
            this.colORG_NO.Width = 90;
            // 
            // colSNAME
            // 
            this.colSNAME.Caption = "客戶";
            this.colSNAME.FieldName = "SNAME";
            this.colSNAME.Name = "colSNAME";
            this.colSNAME.OptionsColumn.AllowEdit = false;
            this.colSNAME.OptionsColumn.ReadOnly = true;
            this.colSNAME.Visible = true;
            this.colSNAME.VisibleIndex = 11;
            this.colSNAME.Width = 120;
            // 
            // colQTY
            // 
            this.colQTY.AppearanceCell.Options.UseTextOptions = true;
            this.colQTY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQTY.AppearanceHeader.Options.UseTextOptions = true;
            this.colQTY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQTY.Caption = "單據數量";
            this.colQTY.DisplayFormat.FormatString = "0.00";
            this.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQTY.FieldName = "QTY";
            this.colQTY.Name = "colQTY";
            this.colQTY.OptionsColumn.AllowEdit = false;
            this.colQTY.OptionsColumn.ReadOnly = true;
            this.colQTY.Visible = true;
            this.colQTY.VisibleIndex = 12;
            // 
            // colWMS_QTY
            // 
            this.colWMS_QTY.AppearanceCell.Options.UseTextOptions = true;
            this.colWMS_QTY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colWMS_QTY.AppearanceHeader.Options.UseTextOptions = true;
            this.colWMS_QTY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colWMS_QTY.Caption = "WMS完成數量";
            this.colWMS_QTY.DisplayFormat.FormatString = "0.00";
            this.colWMS_QTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colWMS_QTY.FieldName = "WMS_QTY";
            this.colWMS_QTY.Name = "colWMS_QTY";
            this.colWMS_QTY.OptionsColumn.AllowEdit = false;
            this.colWMS_QTY.OptionsColumn.ReadOnly = true;
            this.colWMS_QTY.Visible = true;
            this.colWMS_QTY.VisibleIndex = 13;
            this.colWMS_QTY.Width = 88;
            // 
            // colTMP_QTY
            // 
            this.colTMP_QTY.AppearanceCell.Options.UseTextOptions = true;
            this.colTMP_QTY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTMP_QTY.AppearanceHeader.Options.UseTextOptions = true;
            this.colTMP_QTY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colTMP_QTY.Caption = "WMS作業中數量";
            this.colTMP_QTY.DisplayFormat.FormatString = "0.00";
            this.colTMP_QTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTMP_QTY.FieldName = "TMP_QTY";
            this.colTMP_QTY.Name = "colTMP_QTY";
            this.colTMP_QTY.OptionsColumn.AllowEdit = false;
            this.colTMP_QTY.OptionsColumn.ReadOnly = true;
            this.colTMP_QTY.Visible = true;
            this.colTMP_QTY.VisibleIndex = 14;
            this.colTMP_QTY.Width = 100;
            // 
            // colUN
            // 
            this.colUN.Caption = "單位";
            this.colUN.FieldName = "UN";
            this.colUN.Name = "colUN";
            this.colUN.OptionsColumn.AllowEdit = false;
            this.colUN.OptionsColumn.ReadOnly = true;
            this.colUN.Visible = true;
            this.colUN.VisibleIndex = 15;
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
            this.colPRODUCTION_DATE.VisibleIndex = 16;
            // 
            // colREMARK2
            // 
            this.colREMARK2.Caption = "備註";
            this.colREMARK2.FieldName = "REMARK";
            this.colREMARK2.Name = "colREMARK2";
            this.colREMARK2.OptionsColumn.AllowEdit = false;
            this.colREMARK2.OptionsColumn.ReadOnly = true;
            this.colREMARK2.Visible = true;
            this.colREMARK2.VisibleIndex = 17;
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
            this.colCREATE_DATE2.VisibleIndex = 18;
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
            this.colCREATE_NAME2.VisibleIndex = 19;
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
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnClose);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 491);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1418, 33);
            this.panelControl2.TabIndex = 13;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::WMS.Properties.Resources.Close_16_W;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(712, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::WMS.Properties.Resources.ok_16_White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(631, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "確定";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Fm_O002_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 524);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "Fm_O002_1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "挑選單據";
            this.Load += new System.EventHandler(this.Fm_O002_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbListNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WMS_OUT_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WMS_OUT_LINE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbListNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Button btn_Select;
        private DevExpress.XtraEditors.ButtonEdit txtFilter;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gdc_WMS_OUT_LINE;
        private DevExpress.XtraGrid.Views.Grid.GridView gdv_WMS_OUT_LINE;
        private DevExpress.XtraGrid.Columns.GridColumn colLIST_NO2;
        private DevExpress.XtraGrid.Columns.GridColumn colLINE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colERP_LIST_TYPE;
        private DevExpress.XtraGrid.Columns.GridColumn colERP_LIST_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colERP_LINE_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS_CTR_DESC2;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colLOT_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colORG_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
        private DevExpress.XtraGrid.Columns.GridColumn colWMS_QTY;
        private DevExpress.XtraGrid.Columns.GridColumn colTMP_QTY;
        private DevExpress.XtraGrid.Columns.GridColumn colUN;
        private DevExpress.XtraGrid.Columns.GridColumn colPRODUCTION_DATE;
        private DevExpress.XtraGrid.Columns.GridColumn colREMARK2;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_DATE2;
        private DevExpress.XtraGrid.Columns.GridColumn colCREATE_NAME2;
        private DevExpress.XtraGrid.Columns.GridColumn colUPDATE_DATE2;
        private DevExpress.XtraGrid.Columns.GridColumn colUPDATE_NAME2;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn colCHK;
        private System.Windows.Forms.Button btnClose;
    }
}