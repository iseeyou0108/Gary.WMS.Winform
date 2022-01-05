namespace WMS
{
    partial class fm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_Login));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cbLang = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new DevExpress.XtraEditors.ButtonEdit();
            this.txtUserNo = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            resources.ApplyResources(this.panelControl1, "panelControl1");
            this.panelControl1.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("panelControl1.Appearance.BackColor")));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Controls.Add(this.cbLang);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.btnLogin);
            this.panelControl1.Controls.Add(this.txtPassword);
            this.panelControl1.Controls.Add(this.txtUserNo);
            this.panelControl1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.panelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            // 
            // cbLang
            // 
            resources.ApplyResources(this.cbLang, "cbLang");
            this.cbLang.Name = "cbLang";
            this.cbLang.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("cbLang.Properties.Appearance.Font")));
            this.cbLang.Properties.Appearance.Options.UseFont = true;
            this.cbLang.Properties.AppearanceDropDown.Font = ((System.Drawing.Font)(resources.GetObject("cbLang.Properties.AppearanceDropDown.Font")));
            this.cbLang.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbLang.Properties.AppearanceDropDownHeader.Font = ((System.Drawing.Font)(resources.GetObject("cbLang.Properties.AppearanceDropDownHeader.Font")));
            this.cbLang.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.cbLang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbLang.Properties.Buttons"))))});
            this.cbLang.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo(resources.GetString("cbLang.Properties.Columns"), resources.GetString("cbLang.Properties.Columns1"))});
            this.cbLang.Properties.DisplayMember = "Text";
            this.cbLang.Properties.NullText = resources.GetString("cbLang.Properties.NullText");
            this.cbLang.Properties.ValueMember = "Value";
            this.cbLang.EditValueChanged += new System.EventHandler(this.cbLang_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl4.Appearance.Font")));
            this.labelControl4.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("labelControl4.Appearance.ForeColor")));
            resources.ApplyResources(this.labelControl4, "labelControl4");
            this.labelControl4.Name = "labelControl4";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl3.Appearance.Font")));
            this.labelControl3.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("labelControl3.Appearance.ForeColor")));
            resources.ApplyResources(this.labelControl3, "labelControl3");
            this.labelControl3.Name = "labelControl3";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl2.Appearance.Font")));
            this.labelControl2.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("labelControl2.Appearance.ForeColor")));
            resources.ApplyResources(this.labelControl2, "labelControl2");
            this.labelControl2.Name = "labelControl2";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            this.labelControl1.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("labelControl1.Appearance.ForeColor")));
            this.labelControl1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("labelControl1.Appearance.Image")));
            this.labelControl1.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Name = "labelControl1";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtPassword.Properties.Appearance.Font")));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtPassword.Properties.Buttons"))), resources.GetString("txtPassword.Properties.Buttons1"), ((int)(resources.GetObject("txtPassword.Properties.Buttons2"))), ((bool)(resources.GetObject("txtPassword.Properties.Buttons3"))), ((bool)(resources.GetObject("txtPassword.Properties.Buttons4"))), ((bool)(resources.GetObject("txtPassword.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("txtPassword.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("txtPassword.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, resources.GetString("txtPassword.Properties.Buttons8"), null, null, ((bool)(resources.GetObject("txtPassword.Properties.Buttons9"))))});
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.DoubleClick += new System.EventHandler(this.txtPassword_DoubleClick);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // txtUserNo
            // 
            resources.ApplyResources(this.txtUserNo, "txtUserNo");
            this.txtUserNo.Name = "txtUserNo";
            this.txtUserNo.Properties.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("txtUserNo.Properties.Appearance.Font")));
            this.txtUserNo.Properties.Appearance.Options.UseFont = true;
            this.txtUserNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("txtUserNo.Properties.Buttons"))), resources.GetString("txtUserNo.Properties.Buttons1"), ((int)(resources.GetObject("txtUserNo.Properties.Buttons2"))), ((bool)(resources.GetObject("txtUserNo.Properties.Buttons3"))), ((bool)(resources.GetObject("txtUserNo.Properties.Buttons4"))), ((bool)(resources.GetObject("txtUserNo.Properties.Buttons5"))), ((DevExpress.XtraEditors.ImageLocation)(resources.GetObject("txtUserNo.Properties.Buttons6"))), ((System.Drawing.Image)(resources.GetObject("txtUserNo.Properties.Buttons7"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, resources.GetString("txtUserNo.Properties.Buttons8"), null, null, ((bool)(resources.GetObject("txtUserNo.Properties.Buttons9"))))});
            this.txtUserNo.EditValueChanged += new System.EventHandler(this.txtUserNo_EditValueChanged);
            // 
            // fm_Login
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelControl1);
            this.Name = "fm_Login";
            this.Load += new System.EventHandler(this.fm_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.ButtonEdit txtUserNo;
        private DevExpress.XtraEditors.ButtonEdit txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LookUpEdit cbLang;
    }
}