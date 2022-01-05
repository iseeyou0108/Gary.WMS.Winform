namespace WMS
{
    partial class Fm_O004
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbCrnID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cmbAsrsID = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnColumnSet = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gdc_WMS_STK = new DevExpress.XtraGrid.GridControl();
            this.gdv_WMS_STK = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCHK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWH_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASRS_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBIN_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROD_TYPE_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit_CHK = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.cmbDevNo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExec = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCrnID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAsrsID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WMS_STK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WMS_STK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_CHK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.cmbCrnID);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.cmbAsrsID);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnColumnSet);
            this.panelControl1.Controls.Add(this.btn_Select);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.SkinName = "Lilian";
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1047, 34);
            this.panelControl1.TabIndex = 8;
            // 
            // cmbCrnID
            // 
            this.cmbCrnID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCrnID.Location = new System.Drawing.Point(797, 7);
            this.cmbCrnID.Name = "cmbCrnID";
            this.cmbCrnID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbCrnID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbCrnID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "倉庫")});
            this.cmbCrnID.Properties.DropDownRows = 10;
            this.cmbCrnID.Properties.NullText = "";
            this.cmbCrnID.Size = new System.Drawing.Size(60, 21);
            this.cmbCrnID.TabIndex = 19;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(767, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 14);
            this.labelControl2.TabIndex = 18;
            this.labelControl2.Text = "吊車";
            // 
            // cmbAsrsID
            // 
            this.cmbAsrsID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAsrsID.Location = new System.Drawing.Point(701, 7);
            this.cmbAsrsID.Name = "cmbAsrsID";
            this.cmbAsrsID.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbAsrsID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAsrsID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "倉庫")});
            this.cmbAsrsID.Properties.DropDownRows = 10;
            this.cmbAsrsID.Properties.NullText = "";
            this.cmbAsrsID.Size = new System.Drawing.Size(60, 21);
            this.cmbAsrsID.TabIndex = 17;
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(659, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(36, 14);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "倉庫ID";
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
            this.btnColumnSet.Location = new System.Drawing.Point(944, 6);
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
            this.btn_Select.Location = new System.Drawing.Point(863, 6);
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
            this.groupControl1.Controls.Add(this.gdc_WMS_STK);
            this.groupControl1.Controls.Add(this.panelControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 34);
            this.groupControl1.LookAndFeel.SkinName = "Lilian";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1047, 439);
            this.groupControl1.TabIndex = 12;
            this.groupControl1.Text = "空棧板庫存資料";
            // 
            // gdc_WMS_STK
            // 
            this.gdc_WMS_STK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gdc_WMS_STK.EmbeddedNavigator.TextStringFormat = "資料筆數: {0}/{1}";
            this.gdc_WMS_STK.Location = new System.Drawing.Point(2, 58);
            this.gdc_WMS_STK.LookAndFeel.SkinName = "Black";
            this.gdc_WMS_STK.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gdc_WMS_STK.MainView = this.gdv_WMS_STK;
            this.gdc_WMS_STK.Name = "gdc_WMS_STK";
            this.gdc_WMS_STK.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit_CHK});
            this.gdc_WMS_STK.Size = new System.Drawing.Size(1043, 379);
            this.gdc_WMS_STK.TabIndex = 5;
            this.gdc_WMS_STK.TabStop = false;
            this.gdc_WMS_STK.UseEmbeddedNavigator = true;
            this.gdc_WMS_STK.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gdv_WMS_STK});
            // 
            // gdv_WMS_STK
            // 
            this.gdv_WMS_STK.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCHK,
            this.colWH_NO,
            this.colASRS_ID,
            this.colCRN_ID,
            this.colBIN_NO,
            this.colPROD_NO,
            this.colPROD_NAME,
            this.colPROD_TYPE_DESC,
            this.colQTY,
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
            // 
            // colCHK
            // 
            this.colCHK.Caption = "選取";
            this.colCHK.FieldName = "CHK";
            this.colCHK.Name = "colCHK";
            this.colCHK.Visible = true;
            this.colCHK.VisibleIndex = 0;
            this.colCHK.Width = 36;
            // 
            // colWH_NO
            // 
            this.colWH_NO.Caption = "儲區";
            this.colWH_NO.FieldName = "WH_NO";
            this.colWH_NO.Name = "colWH_NO";
            this.colWH_NO.OptionsColumn.AllowEdit = false;
            this.colWH_NO.OptionsColumn.ReadOnly = true;
            this.colWH_NO.Visible = true;
            this.colWH_NO.VisibleIndex = 1;
            this.colWH_NO.Width = 55;
            // 
            // colASRS_ID
            // 
            this.colASRS_ID.AppearanceCell.Options.UseTextOptions = true;
            this.colASRS_ID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colASRS_ID.AppearanceHeader.Options.UseTextOptions = true;
            this.colASRS_ID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colASRS_ID.Caption = "倉庫ID";
            this.colASRS_ID.FieldName = "ASRS_ID";
            this.colASRS_ID.Name = "colASRS_ID";
            this.colASRS_ID.OptionsColumn.AllowEdit = false;
            this.colASRS_ID.OptionsColumn.ReadOnly = true;
            this.colASRS_ID.Visible = true;
            this.colASRS_ID.VisibleIndex = 2;
            this.colASRS_ID.Width = 65;
            // 
            // colCRN_ID
            // 
            this.colCRN_ID.Caption = "吊車";
            this.colCRN_ID.FieldName = "CRN_ID";
            this.colCRN_ID.Name = "colCRN_ID";
            this.colCRN_ID.OptionsColumn.AllowEdit = false;
            this.colCRN_ID.OptionsColumn.ReadOnly = true;
            this.colCRN_ID.Visible = true;
            this.colCRN_ID.VisibleIndex = 3;
            // 
            // colBIN_NO
            // 
            this.colBIN_NO.Caption = "庫位";
            this.colBIN_NO.FieldName = "BIN_NO";
            this.colBIN_NO.Name = "colBIN_NO";
            this.colBIN_NO.OptionsColumn.AllowEdit = false;
            this.colBIN_NO.OptionsColumn.ReadOnly = true;
            this.colBIN_NO.Visible = true;
            this.colBIN_NO.VisibleIndex = 4;
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
            // colPROD_TYPE_DESC
            // 
            this.colPROD_TYPE_DESC.Caption = "物料類型";
            this.colPROD_TYPE_DESC.FieldName = "PROD_TYPE_DESC";
            this.colPROD_TYPE_DESC.Name = "colPROD_TYPE_DESC";
            this.colPROD_TYPE_DESC.OptionsColumn.AllowEdit = false;
            this.colPROD_TYPE_DESC.OptionsColumn.ReadOnly = true;
            this.colPROD_TYPE_DESC.Visible = true;
            this.colPROD_TYPE_DESC.VisibleIndex = 7;
            // 
            // colQTY
            // 
            this.colQTY.AppearanceCell.Options.UseTextOptions = true;
            this.colQTY.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQTY.AppearanceHeader.Options.UseTextOptions = true;
            this.colQTY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colQTY.Caption = "數量";
            this.colQTY.DisplayFormat.FormatString = "0";
            this.colQTY.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colQTY.FieldName = "QTY";
            this.colQTY.Name = "colQTY";
            this.colQTY.OptionsColumn.AllowEdit = false;
            this.colQTY.OptionsColumn.ReadOnly = true;
            this.colQTY.Visible = true;
            this.colQTY.VisibleIndex = 9;
            // 
            // colUN
            // 
            this.colUN.Caption = "單位";
            this.colUN.FieldName = "UN";
            this.colUN.Name = "colUN";
            this.colUN.OptionsColumn.AllowEdit = false;
            this.colUN.OptionsColumn.ReadOnly = true;
            this.colUN.Visible = true;
            this.colUN.VisibleIndex = 8;
            this.colUN.Width = 55;
            // 
            // repositoryItemCheckEdit_CHK
            // 
            this.repositoryItemCheckEdit_CHK.AutoHeight = false;
            this.repositoryItemCheckEdit_CHK.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit_CHK.Name = "repositoryItemCheckEdit_CHK";
            this.repositoryItemCheckEdit_CHK.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit_CHK.PictureChecked = global::WMS.Properties.Resources.Checked20;
            this.repositoryItemCheckEdit_CHK.PictureGrayed = global::WMS.Properties.Resources.UnChecked20;
            this.repositoryItemCheckEdit_CHK.PictureUnchecked = global::WMS.Properties.Resources.Checked20;
            this.repositoryItemCheckEdit_CHK.ValueGrayed = false;
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.chkAll);
            this.panelControl2.Controls.Add(this.cmbDevNo);
            this.panelControl2.Controls.Add(this.label1);
            this.panelControl2.Controls.Add(this.btnExec);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 24);
            this.panelControl2.LookAndFeel.SkinName = "Lilian";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1043, 34);
            this.panelControl2.TabIndex = 9;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(241, 8);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "全選";
            this.chkAll.Size = new System.Drawing.Size(53, 19);
            this.chkAll.TabIndex = 20;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cmbDevNo
            // 
            this.cmbDevNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevNo.FormattingEnabled = true;
            this.cmbDevNo.Location = new System.Drawing.Point(72, 6);
            this.cmbDevNo.Name = "cmbDevNo";
            this.cmbDevNo.Size = new System.Drawing.Size(66, 22);
            this.cmbDevNo.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "站台編號";
            // 
            // btnExec
            // 
            this.btnExec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExec.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnExec.FlatAppearance.BorderSize = 0;
            this.btnExec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExec.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.btnExec.ForeColor = System.Drawing.Color.White;
            this.btnExec.Image = global::WMS.Properties.Resources.ok_16_White;
            this.btnExec.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExec.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExec.Location = new System.Drawing.Point(144, 6);
            this.btnExec.Name = "btnExec";
            this.btnExec.Size = new System.Drawing.Size(91, 22);
            this.btnExec.TabIndex = 17;
            this.btnExec.Text = "確認出庫";
            this.btnExec.UseVisualStyleBackColor = false;
            this.btnExec.Click += new System.EventHandler(this.btnExec_Click);
            // 
            // Fm_O004
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 473);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "Fm_O004";
            this.Text = "Fm_O004";
            this.Load += new System.EventHandler(this.Fm_O004_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCrnID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAsrsID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WMS_STK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WMS_STK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit_CHK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbAsrsID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button btnColumnSet;
        private System.Windows.Forms.Button btn_Select;
        private DevExpress.XtraEditors.LookUpEdit cmbCrnID;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gdc_WMS_STK;
        private DevExpress.XtraGrid.Views.Grid.GridView gdv_WMS_STK;
        private DevExpress.XtraGrid.Columns.GridColumn colWH_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colASRS_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colQTY;
        private DevExpress.XtraGrid.Columns.GridColumn colUN;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit_CHK;
        private DevExpress.XtraGrid.Columns.GridColumn colCHK;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colBIN_NO;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.ComboBox cmbDevNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExec;
        private DevExpress.XtraGrid.Columns.GridColumn colPROD_TYPE_DESC;
        private DevExpress.XtraEditors.CheckEdit chkAll;
    }
}