namespace WMS
{
    partial class fm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fm_Main));
            this.navBarControl_Menu = new DevExpress.XtraNavBar.NavBarControl();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblClose = new DevExpress.XtraEditors.LabelControl();
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pnlStatusBar = new DevExpress.XtraEditors.PanelControl();
            this.chkShowMessage = new DevExpress.XtraEditors.CheckEdit();
            this.lblAlarmMsg = new System.Windows.Forms.Label();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl_Menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlStatusBar)).BeginInit();
            this.pnlStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowMessage.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // navBarControl_Menu
            // 
            this.navBarControl_Menu.AccessibleDescription = null;
            this.navBarControl_Menu.AccessibleName = null;
            this.navBarControl_Menu.ActiveGroup = null;
            resources.ApplyResources(this.navBarControl_Menu, "navBarControl_Menu");
            this.navBarControl_Menu.Font = null;
            this.navBarControl_Menu.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.navBarControl_Menu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.navBarControl_Menu.Name = "navBarControl_Menu";
            this.navBarControl_Menu.OptionsNavPane.ExpandedWidth = ((int)(resources.GetObject("resource.ExpandedWidth")));
            this.navBarControl_Menu.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinNavigationPaneViewInfoRegistrator("DevExpress Dark Style");
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // pnlHeader
            // 
            this.pnlHeader.AccessibleDescription = null;
            this.pnlHeader.AccessibleName = null;
            resources.ApplyResources(this.pnlHeader, "pnlHeader");
            this.pnlHeader.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pnlHeader.Appearance.BackColor")));
            this.pnlHeader.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pnlHeader.Appearance.GradientMode")));
            this.pnlHeader.Appearance.Image = null;
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblClose);
            this.pnlHeader.Controls.Add(this.lblUser);
            this.pnlHeader.Controls.Add(this.labelControl1);
            this.pnlHeader.Name = "pnlHeader";
            // 
            // lblClose
            // 
            this.lblClose.AccessibleDescription = null;
            this.lblClose.AccessibleName = null;
            resources.ApplyResources(this.lblClose, "lblClose");
            this.lblClose.Appearance.DisabledImage = null;
            this.lblClose.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblClose.Appearance.Font")));
            this.lblClose.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblClose.Appearance.ForeColor")));
            this.lblClose.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblClose.Appearance.GradientMode")));
            this.lblClose.Appearance.HoverImage = null;
            this.lblClose.Appearance.Image = global::WMS.Properties.Resources.Close_32_2;
            this.lblClose.Appearance.PressedImage = null;
            this.lblClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblClose.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblClose.Name = "lblClose";
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblUser
            // 
            this.lblUser.AccessibleDescription = null;
            this.lblUser.AccessibleName = null;
            resources.ApplyResources(this.lblUser, "lblUser");
            this.lblUser.Appearance.DisabledImage = null;
            this.lblUser.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("lblUser.Appearance.Font")));
            this.lblUser.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("lblUser.Appearance.ForeColor")));
            this.lblUser.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("lblUser.Appearance.GradientMode")));
            this.lblUser.Appearance.HoverImage = null;
            this.lblUser.Appearance.Image = global::WMS.Properties.Resources.User_24_W1;
            this.lblUser.Appearance.PressedImage = null;
            this.lblUser.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.lblUser.Name = "lblUser";
            // 
            // labelControl1
            // 
            this.labelControl1.AccessibleDescription = null;
            this.labelControl1.AccessibleName = null;
            resources.ApplyResources(this.labelControl1, "labelControl1");
            this.labelControl1.Appearance.DisabledImage = null;
            this.labelControl1.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl1.Appearance.Font")));
            this.labelControl1.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("labelControl1.Appearance.ForeColor")));
            this.labelControl1.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("labelControl1.Appearance.GradientMode")));
            this.labelControl1.Appearance.HoverImage = null;
            this.labelControl1.Appearance.Image = null;
            this.labelControl1.Appearance.PressedImage = null;
            this.labelControl1.Name = "labelControl1";
            // 
            // pnlStatusBar
            // 
            this.pnlStatusBar.AccessibleDescription = null;
            this.pnlStatusBar.AccessibleName = null;
            resources.ApplyResources(this.pnlStatusBar, "pnlStatusBar");
            this.pnlStatusBar.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("pnlStatusBar.Appearance.BackColor")));
            this.pnlStatusBar.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("pnlStatusBar.Appearance.GradientMode")));
            this.pnlStatusBar.Appearance.Image = null;
            this.pnlStatusBar.Appearance.Options.UseBackColor = true;
            this.pnlStatusBar.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.pnlStatusBar.Controls.Add(this.chkShowMessage);
            this.pnlStatusBar.Controls.Add(this.lblAlarmMsg);
            this.pnlStatusBar.Controls.Add(this.labelControl4);
            this.pnlStatusBar.Name = "pnlStatusBar";
            // 
            // chkShowMessage
            // 
            resources.ApplyResources(this.chkShowMessage, "chkShowMessage");
            this.chkShowMessage.BackgroundImage = null;
            this.chkShowMessage.Name = "chkShowMessage";
            this.chkShowMessage.Properties.AccessibleDescription = null;
            this.chkShowMessage.Properties.AccessibleName = null;
            this.chkShowMessage.Properties.AutoHeight = ((bool)(resources.GetObject("chkShowMessage.Properties.AutoHeight")));
            this.chkShowMessage.Properties.Caption = resources.GetString("chkShowMessage.Properties.Caption");
            this.chkShowMessage.Properties.DisplayValueChecked = resources.GetString("chkShowMessage.Properties.DisplayValueChecked");
            this.chkShowMessage.Properties.DisplayValueGrayed = resources.GetString("chkShowMessage.Properties.DisplayValueGrayed");
            this.chkShowMessage.Properties.DisplayValueUnchecked = resources.GetString("chkShowMessage.Properties.DisplayValueUnchecked");
            this.chkShowMessage.CheckedChanged += new System.EventHandler(this.chkShowMessage_CheckedChanged);
            // 
            // lblAlarmMsg
            // 
            this.lblAlarmMsg.AccessibleDescription = null;
            this.lblAlarmMsg.AccessibleName = null;
            resources.ApplyResources(this.lblAlarmMsg, "lblAlarmMsg");
            this.lblAlarmMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblAlarmMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.lblAlarmMsg.Name = "lblAlarmMsg";
            // 
            // labelControl4
            // 
            this.labelControl4.AccessibleDescription = null;
            this.labelControl4.AccessibleName = null;
            resources.ApplyResources(this.labelControl4, "labelControl4");
            this.labelControl4.Appearance.DisabledImage = null;
            this.labelControl4.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("labelControl4.Appearance.Font")));
            this.labelControl4.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("labelControl4.Appearance.ForeColor")));
            this.labelControl4.Appearance.GradientMode = ((System.Drawing.Drawing2D.LinearGradientMode)(resources.GetObject("labelControl4.Appearance.GradientMode")));
            this.labelControl4.Appearance.HoverImage = null;
            this.labelControl4.Appearance.Image = null;
            this.labelControl4.Appearance.PressedImage = null;
            this.labelControl4.Name = "labelControl4";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // fm_Main
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlStatusBar);
            this.Controls.Add(this.navBarControl_Menu);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = null;
            this.IsMdiContainer = true;
            this.Name = "fm_Main";
            this.Load += new System.EventHandler(this.fm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl_Menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlStatusBar)).EndInit();
            this.pnlStatusBar.ResumeLayout(false);
            this.pnlStatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowMessage.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraNavBar.NavBarControl navBarControl_Menu;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblUser;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblClose;
        private DevExpress.XtraEditors.PanelControl pnlStatusBar;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.Label lblAlarmMsg;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.CheckEdit chkShowMessage;


    }
}