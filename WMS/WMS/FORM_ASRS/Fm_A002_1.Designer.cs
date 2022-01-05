namespace WMS
{
    partial class Fm_A002_1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_A002_1));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkDisableOut = new DevExpress.XtraEditors.CheckEdit();
            this.chkDisableIn = new DevExpress.XtraEditors.CheckEdit();
            this.gdc_WCS_CRN = new DevExpress.XtraGrid.GridControl();
            this.gdv_WCS_CRN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colASRS_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRN_ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCONNECT_MODE_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINHIBIT_IN_FLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colINHIBIT_OUT_FLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colERR_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colERR_CODE_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisableOut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisableIn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WCS_CRN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WCS_CRN)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.AccessibleDescription = null;
            this.panelControl2.AccessibleName = null;
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.Controls.Add(this.chkDisableOut);
            this.panelControl2.Controls.Add(this.chkDisableIn);
            this.panelControl2.LookAndFeel.SkinName = "Lilian";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            // 
            // btnSave
            // 
            this.btnSave.AccessibleDescription = null;
            this.btnSave.AccessibleName = null;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnSave.BackgroundImage = null;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::WMS.Properties.Resources.ok_16_White;
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkDisableOut
            // 
            resources.ApplyResources(this.chkDisableOut, "chkDisableOut");
            this.chkDisableOut.BackgroundImage = null;
            this.chkDisableOut.Name = "chkDisableOut";
            this.chkDisableOut.Properties.AccessibleDescription = null;
            this.chkDisableOut.Properties.AccessibleName = null;
            this.chkDisableOut.Properties.AutoHeight = ((bool)(resources.GetObject("chkDisableOut.Properties.AutoHeight")));
            this.chkDisableOut.Properties.Caption = resources.GetString("chkDisableOut.Properties.Caption");
            this.chkDisableOut.Properties.DisplayValueChecked = resources.GetString("chkDisableOut.Properties.DisplayValueChecked");
            this.chkDisableOut.Properties.DisplayValueGrayed = resources.GetString("chkDisableOut.Properties.DisplayValueGrayed");
            this.chkDisableOut.Properties.DisplayValueUnchecked = resources.GetString("chkDisableOut.Properties.DisplayValueUnchecked");
            // 
            // chkDisableIn
            // 
            resources.ApplyResources(this.chkDisableIn, "chkDisableIn");
            this.chkDisableIn.BackgroundImage = null;
            this.chkDisableIn.Name = "chkDisableIn";
            this.chkDisableIn.Properties.AccessibleDescription = null;
            this.chkDisableIn.Properties.AccessibleName = null;
            this.chkDisableIn.Properties.AutoHeight = ((bool)(resources.GetObject("chkDisableIn.Properties.AutoHeight")));
            this.chkDisableIn.Properties.Caption = resources.GetString("chkDisableIn.Properties.Caption");
            this.chkDisableIn.Properties.DisplayValueChecked = resources.GetString("chkDisableIn.Properties.DisplayValueChecked");
            this.chkDisableIn.Properties.DisplayValueGrayed = resources.GetString("chkDisableIn.Properties.DisplayValueGrayed");
            this.chkDisableIn.Properties.DisplayValueUnchecked = resources.GetString("chkDisableIn.Properties.DisplayValueUnchecked");
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
            this.gridColumn14,
            this.colASRS_ID,
            this.colCRN_ID,
            this.colCONNECT_MODE_DESC,
            this.colINHIBIT_IN_FLG,
            this.colINHIBIT_OUT_FLG,
            this.colERR_CODE,
            this.colERR_CODE_DESC});
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
            this.gdv_WCS_CRN.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn14
            // 
            resources.ApplyResources(this.gridColumn14, "gridColumn14");
            this.gridColumn14.FieldName = "CHK";
            this.gridColumn14.Name = "gridColumn14";
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
            // Fm_A002_1
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.gdc_WCS_CRN);
            this.Controls.Add(this.panelControl2);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fm_A002_1";
            this.Load += new System.EventHandler(this.Fm_A002_1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkDisableOut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDisableIn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WCS_CRN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WCS_CRN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gdc_WCS_CRN;
        private DevExpress.XtraGrid.Views.Grid.GridView gdv_WCS_CRN;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn colASRS_ID;
        private DevExpress.XtraGrid.Columns.GridColumn colCONNECT_MODE_DESC;
        private DevExpress.XtraGrid.Columns.GridColumn colINHIBIT_IN_FLG;
        private DevExpress.XtraGrid.Columns.GridColumn colINHIBIT_OUT_FLG;
        private DevExpress.XtraGrid.Columns.GridColumn colERR_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn colERR_CODE_DESC;
        private DevExpress.XtraEditors.CheckEdit chkDisableOut;
        private DevExpress.XtraEditors.CheckEdit chkDisableIn;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_ID;
    }
}