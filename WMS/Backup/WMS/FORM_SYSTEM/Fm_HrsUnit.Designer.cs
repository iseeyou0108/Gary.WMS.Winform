namespace WMS
{
    partial class Fm_HrsUnit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fm_HrsUnit));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUnitName = new DevExpress.XtraEditors.TextEdit();
            this.txtUnitNo = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.AccessibleDescription = null;
            this.layoutControl1.AccessibleName = null;
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.BackgroundImage = null;
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.txtUnitName);
            this.layoutControl1.Controls.Add(this.txtUnitNo);
            this.layoutControl1.Font = null;
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(322, 80, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // panelControl1
            // 
            this.panelControl1.AccessibleDescription = null;
            this.panelControl1.AccessibleName = null;
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Controls.Add(this.btnSave);
            this.panelControl1.Name = "panelControl1";
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
            // txtUnitName
            // 
            resources.ApplyResources(this.txtUnitName, "txtUnitName");
            this.txtUnitName.BackgroundImage = null;
            this.txtUnitName.EditValue = null;
            this.txtUnitName.Name = "txtUnitName";
            this.txtUnitName.Properties.AccessibleDescription = null;
            this.txtUnitName.Properties.AccessibleName = null;
            this.txtUnitName.Properties.AutoHeight = ((bool)(resources.GetObject("txtUnitName.Properties.AutoHeight")));
            this.txtUnitName.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtUnitName.Properties.Mask.AutoComplete")));
            this.txtUnitName.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtUnitName.Properties.Mask.BeepOnError")));
            this.txtUnitName.Properties.Mask.EditMask = resources.GetString("txtUnitName.Properties.Mask.EditMask");
            this.txtUnitName.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtUnitName.Properties.Mask.IgnoreMaskBlank")));
            this.txtUnitName.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtUnitName.Properties.Mask.MaskType")));
            this.txtUnitName.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtUnitName.Properties.Mask.PlaceHolder")));
            this.txtUnitName.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtUnitName.Properties.Mask.SaveLiteral")));
            this.txtUnitName.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtUnitName.Properties.Mask.ShowPlaceHolders")));
            this.txtUnitName.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtUnitName.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtUnitName.Properties.NullValuePrompt = resources.GetString("txtUnitName.Properties.NullValuePrompt");
            this.txtUnitName.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtUnitName.Properties.NullValuePromptShowForEmptyValue")));
            this.txtUnitName.StyleController = this.layoutControl1;
            this.txtUnitName.Validating += new System.ComponentModel.CancelEventHandler(this.txtInput_Validating);
            // 
            // txtUnitNo
            // 
            resources.ApplyResources(this.txtUnitNo, "txtUnitNo");
            this.txtUnitNo.BackgroundImage = null;
            this.txtUnitNo.EditValue = null;
            this.txtUnitNo.Name = "txtUnitNo";
            this.txtUnitNo.Properties.AccessibleDescription = null;
            this.txtUnitNo.Properties.AccessibleName = null;
            this.txtUnitNo.Properties.AutoHeight = ((bool)(resources.GetObject("txtUnitNo.Properties.AutoHeight")));
            this.txtUnitNo.Properties.Mask.AutoComplete = ((DevExpress.XtraEditors.Mask.AutoCompleteType)(resources.GetObject("txtUnitNo.Properties.Mask.AutoComplete")));
            this.txtUnitNo.Properties.Mask.BeepOnError = ((bool)(resources.GetObject("txtUnitNo.Properties.Mask.BeepOnError")));
            this.txtUnitNo.Properties.Mask.EditMask = resources.GetString("txtUnitNo.Properties.Mask.EditMask");
            this.txtUnitNo.Properties.Mask.IgnoreMaskBlank = ((bool)(resources.GetObject("txtUnitNo.Properties.Mask.IgnoreMaskBlank")));
            this.txtUnitNo.Properties.Mask.MaskType = ((DevExpress.XtraEditors.Mask.MaskType)(resources.GetObject("txtUnitNo.Properties.Mask.MaskType")));
            this.txtUnitNo.Properties.Mask.PlaceHolder = ((char)(resources.GetObject("txtUnitNo.Properties.Mask.PlaceHolder")));
            this.txtUnitNo.Properties.Mask.SaveLiteral = ((bool)(resources.GetObject("txtUnitNo.Properties.Mask.SaveLiteral")));
            this.txtUnitNo.Properties.Mask.ShowPlaceHolders = ((bool)(resources.GetObject("txtUnitNo.Properties.Mask.ShowPlaceHolders")));
            this.txtUnitNo.Properties.Mask.UseMaskAsDisplayFormat = ((bool)(resources.GetObject("txtUnitNo.Properties.Mask.UseMaskAsDisplayFormat")));
            this.txtUnitNo.Properties.NullValuePrompt = resources.GetString("txtUnitNo.Properties.NullValuePrompt");
            this.txtUnitNo.Properties.NullValuePromptShowForEmptyValue = ((bool)(resources.GetObject("txtUnitNo.Properties.NullValuePromptShowForEmptyValue")));
            this.txtUnitNo.StyleController = this.layoutControl1;
            this.txtUnitNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtInput_Validating);
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(276, 94);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.txtUnitNo;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(270, 25);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(77, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtUnitName;
            resources.ApplyResources(this.layoutControlItem2, "layoutControlItem2");
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(270, 25);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(77, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.panelControl1;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 50);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 38);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(104, 38);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(270, 38);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // Fm_HrsUnit
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.layoutControl1);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = null;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Fm_HrsUnit";
            this.Load += new System.EventHandler(this.Fm_HrsUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUnitNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txtUnitName;
        private DevExpress.XtraEditors.TextEdit txtUnitNo;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}