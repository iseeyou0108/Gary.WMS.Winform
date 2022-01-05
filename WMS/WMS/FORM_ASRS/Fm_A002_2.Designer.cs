namespace WMS
{
    partial class Fm_A002_2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_A002_2));
            DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmbType = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDevice = new DevExpress.XtraEditors.LabelControl();
            this.cmbAction = new DevExpress.XtraEditors.LookUpEdit();
            this.lblAction = new DevExpress.XtraEditors.LabelControl();
            this.cmbTo = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.cmbFrom = new DevExpress.XtraEditors.LookUpEdit();
            this.lblFrom = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdc_WCS_CRN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdv_WCS_CRN)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.AccessibleDescription = null;
            this.panelControl2.AccessibleName = null;
            resources.ApplyResources(this.panelControl2, "panelControl2");
            this.panelControl2.Controls.Add(this.cmbType);
            this.panelControl2.Controls.Add(this.lblDevice);
            this.panelControl2.Controls.Add(this.cmbAction);
            this.panelControl2.Controls.Add(this.lblAction);
            this.panelControl2.Controls.Add(this.cmbTo);
            this.panelControl2.Controls.Add(this.lblTo);
            this.panelControl2.Controls.Add(this.cmbFrom);
            this.panelControl2.Controls.Add(this.lblFrom);
            this.panelControl2.Controls.Add(this.btnSave);
            this.panelControl2.LookAndFeel.SkinName = "Lilian";
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            // 
            // cmbType
            // 
            resources.ApplyResources(this.cmbType, "cmbType");
            this.cmbType.BackgroundImage = null;
            this.cmbType.EditValue = null;
            this.cmbType.Name = "cmbType";
            this.cmbType.Properties.AccessibleDescription = null;
            this.cmbType.Properties.AccessibleName = null;
            this.cmbType.Properties.AutoHeight = ((bool)(resources.GetObject("cmbType.Properties.AutoHeight")));
            this.cmbType.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cmbType.Properties.Buttons"))))});
            this.cmbType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbType.Properties.Columns"), resources.GetString("cmbType.Properties.Columns1"))});
            this.cmbType.Properties.DisplayMember = "DESC";
            this.cmbType.Properties.DropDownRows = 10;
            this.cmbType.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
            this.cmbType.Properties.NullValuePrompt = resources.GetString("cmbType.Properties.NullValuePrompt");
            this.cmbType.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cmbType.Properties.NullValuePromptShowForEmptyValue")));
            this.cmbType.Properties.ValueMember = "VALUE";
            this.cmbType.EditValueChanged += new System.EventHandler(this.cmbType_EditValueChanged);
            // 
            // lblDevice
            // 
            this.lblDevice.AccessibleDescription = null;
            this.lblDevice.AccessibleName = null;
            resources.ApplyResources(this.lblDevice, "lblDevice");
            this.lblDevice.Name = "lblDevice";
            // 
            // cmbAction
            // 
            resources.ApplyResources(this.cmbAction, "cmbAction");
            this.cmbAction.BackgroundImage = null;
            this.cmbAction.EditValue = null;
            this.cmbAction.Name = "cmbAction";
            this.cmbAction.Properties.AccessibleDescription = null;
            this.cmbAction.Properties.AccessibleName = null;
            this.cmbAction.Properties.AutoHeight = ((bool)(resources.GetObject("cmbAction.Properties.AutoHeight")));
            this.cmbAction.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbAction.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cmbAction.Properties.Buttons"))))});
            this.cmbAction.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbAction.Properties.Columns"), resources.GetString("cmbAction.Properties.Columns1"))});
            this.cmbAction.Properties.DisplayMember = "DESC";
            this.cmbAction.Properties.DropDownRows = 10;
            this.cmbAction.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
            this.cmbAction.Properties.NullValuePrompt = resources.GetString("cmbAction.Properties.NullValuePrompt");
            this.cmbAction.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cmbAction.Properties.NullValuePromptShowForEmptyValue")));
            this.cmbAction.Properties.ValueMember = "VALUE";
            this.cmbAction.EditValueChanged += new System.EventHandler(this.cmbAction_EditValueChanged);
            // 
            // lblAction
            // 
            this.lblAction.AccessibleDescription = null;
            this.lblAction.AccessibleName = null;
            resources.ApplyResources(this.lblAction, "lblAction");
            this.lblAction.Name = "lblAction";
            // 
            // cmbTo
            // 
            resources.ApplyResources(this.cmbTo, "cmbTo");
            this.cmbTo.BackgroundImage = null;
            this.cmbTo.EditValue = null;
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Properties.AccessibleDescription = null;
            this.cmbTo.Properties.AccessibleName = null;
            this.cmbTo.Properties.AutoHeight = ((bool)(resources.GetObject("cmbTo.Properties.AutoHeight")));
            this.cmbTo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cmbTo.Properties.Buttons"))))});
            this.cmbTo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbTo.Properties.Columns"), resources.GetString("cmbTo.Properties.Columns1"))});
            this.cmbTo.Properties.DisplayMember = "DESC";
            this.cmbTo.Properties.DropDownRows = 10;
            this.cmbTo.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
            this.cmbTo.Properties.NullValuePrompt = resources.GetString("cmbTo.Properties.NullValuePrompt");
            this.cmbTo.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cmbTo.Properties.NullValuePromptShowForEmptyValue")));
            this.cmbTo.Properties.ValueMember = "VALUE";
            // 
            // lblTo
            // 
            this.lblTo.AccessibleDescription = null;
            this.lblTo.AccessibleName = null;
            resources.ApplyResources(this.lblTo, "lblTo");
            this.lblTo.Name = "lblTo";
            // 
            // cmbFrom
            // 
            resources.ApplyResources(this.cmbFrom, "cmbFrom");
            this.cmbFrom.BackgroundImage = null;
            this.cmbFrom.EditValue = null;
            this.cmbFrom.Name = "cmbFrom";
            this.cmbFrom.Properties.AccessibleDescription = null;
            this.cmbFrom.Properties.AccessibleName = null;
            this.cmbFrom.Properties.AutoHeight = ((bool)(resources.GetObject("cmbFrom.Properties.AutoHeight")));
            this.cmbFrom.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cmbFrom.Properties.Buttons"))))});
            this.cmbFrom.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cmbFrom.Properties.Columns"), resources.GetString("cmbFrom.Properties.Columns1"))});
            this.cmbFrom.Properties.DisplayMember = "DESC";
            this.cmbFrom.Properties.DropDownRows = 10;
            this.cmbFrom.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
            this.cmbFrom.Properties.NullValuePrompt = resources.GetString("cmbFrom.Properties.NullValuePrompt");
            this.cmbFrom.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("cmbFrom.Properties.NullValuePromptShowForEmptyValue")));
            this.cmbFrom.Properties.ValueMember = "VALUE";
            // 
            // lblFrom
            // 
            this.lblFrom.AccessibleDescription = null;
            this.lblFrom.AccessibleName = null;
            resources.ApplyResources(this.lblFrom, "lblFrom");
            this.lblFrom.Name = "lblFrom";
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
            // Fm_A002_2
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
            this.Name = "Fm_A002_2";
            this.Load += new System.EventHandler(this.Fm_A002_2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbFrom.Properties)).EndInit();
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
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn colCRN_ID;
        private DevExpress.XtraEditors.LabelControl lblFrom;
        private DevExpress.XtraEditors.LookUpEdit cmbType;
        private DevExpress.XtraEditors.LabelControl lblDevice;
        private DevExpress.XtraEditors.LookUpEdit cmbAction;
        private DevExpress.XtraEditors.LabelControl lblAction;
        private DevExpress.XtraEditors.LookUpEdit cmbTo;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.LookUpEdit cmbFrom;
    }
}