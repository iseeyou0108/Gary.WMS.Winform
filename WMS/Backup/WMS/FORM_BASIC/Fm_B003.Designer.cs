namespace WMS
{
    partial class Fm_B003
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbProdNo2 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtLineDesc2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtLineId2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.btn_Select = new System.Windows.Forms.Button();
            this.cmbProdNo1 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtLineDesc1 = new DevExpress.XtraEditors.TextEdit();
            this.btnSave = new System.Windows.Forms.Button();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtLineId1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdNo2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineDesc2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineId2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdNo1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineDesc1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineId1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupControl1.Controls.Add(this.cmbProdNo2);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtLineDesc2);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtLineId2);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.btn_Select);
            this.groupControl1.Controls.Add(this.cmbProdNo1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtLineDesc1);
            this.groupControl1.Controls.Add(this.btnSave);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtLineId1);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Location = new System.Drawing.Point(9, 10);
            this.groupControl1.LookAndFeel.SkinName = "Lilian";
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(636, 290);
            this.groupControl1.TabIndex = 32;
            this.groupControl1.Text = "包裝線資料設定";
            // 
            // cmbProdNo2
            // 
            this.cmbProdNo2.Location = new System.Drawing.Point(453, 156);
            this.cmbProdNo2.Name = "cmbProdNo2";
            this.cmbProdNo2.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbProdNo2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProdNo2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROD_NO", "料號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROD_NAME", 50, "物料描述")});
            this.cmbProdNo2.Properties.DropDownRows = 10;
            this.cmbProdNo2.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
            this.cmbProdNo2.Size = new System.Drawing.Size(160, 21);
            this.cmbProdNo2.TabIndex = 45;
            this.cmbProdNo2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbProdNo_KeyUp);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(387, 159);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(24, 14);
            this.labelControl4.TabIndex = 44;
            this.labelControl4.Text = "料號";
            // 
            // txtLineDesc2
            // 
            this.txtLineDesc2.Location = new System.Drawing.Point(453, 99);
            this.txtLineDesc2.Name = "txtLineDesc2";
            this.txtLineDesc2.Size = new System.Drawing.Size(114, 21);
            this.txtLineDesc2.TabIndex = 43;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(387, 102);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(36, 14);
            this.labelControl5.TabIndex = 42;
            this.labelControl5.Text = "包裝線";
            // 
            // txtLineId2
            // 
            this.txtLineId2.Location = new System.Drawing.Point(453, 45);
            this.txtLineId2.Name = "txtLineId2";
            this.txtLineId2.Properties.ReadOnly = true;
            this.txtLineId2.Size = new System.Drawing.Size(114, 21);
            this.txtLineId2.TabIndex = 41;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(387, 48);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(60, 14);
            this.labelControl6.TabIndex = 40;
            this.labelControl6.Text = "包裝線代號";
            // 
            // btn_Select
            // 
            this.btn_Select.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(184)))), ((int)(((byte)(92)))));
            this.btn_Select.FlatAppearance.BorderSize = 0;
            this.btn_Select.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Select.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Select.ForeColor = System.Drawing.Color.White;
            this.btn_Select.Image = global::WMS.Properties.Resources.Refresh_16_W;
            this.btn_Select.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Select.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Select.Location = new System.Drawing.Point(325, 223);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(98, 23);
            this.btn_Select.TabIndex = 39;
            this.btn_Select.Text = "重整";
            this.btn_Select.UseVisualStyleBackColor = false;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click_1);
            // 
            // cmbProdNo1
            // 
            this.cmbProdNo1.Location = new System.Drawing.Point(97, 156);
            this.cmbProdNo1.Name = "cmbProdNo1";
            this.cmbProdNo1.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
            this.cmbProdNo1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProdNo1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROD_NO", "料號"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROD_NAME", 50, "物料描述")});
            this.cmbProdNo1.Properties.DropDownRows = 10;
            this.cmbProdNo1.Properties.NullText = global::WMS.Language.Resource_WCS_TRK.String1;
            this.cmbProdNo1.Size = new System.Drawing.Size(160, 21);
            this.cmbProdNo1.TabIndex = 38;
            this.cmbProdNo1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbProdNo_KeyUp);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(31, 159);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 14);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "料號";
            // 
            // txtLineDesc1
            // 
            this.txtLineDesc1.Location = new System.Drawing.Point(97, 99);
            this.txtLineDesc1.Name = "txtLineDesc1";
            this.txtLineDesc1.Size = new System.Drawing.Size(114, 21);
            this.txtLineDesc1.TabIndex = 36;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(117)))), ((int)(((byte)(216)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Image = global::WMS.Properties.Resources.ok_16_White;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnSave.Location = new System.Drawing.Point(221, 223);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 23);
            this.btnSave.TabIndex = 35;
            this.btnSave.Text = "儲存";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(31, 102);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(36, 14);
            this.labelControl2.TabIndex = 34;
            this.labelControl2.Text = "包裝線";
            // 
            // txtLineId1
            // 
            this.txtLineId1.Location = new System.Drawing.Point(97, 45);
            this.txtLineId1.Name = "txtLineId1";
            this.txtLineId1.Properties.ReadOnly = true;
            this.txtLineId1.Size = new System.Drawing.Size(114, 21);
            this.txtLineId1.TabIndex = 33;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(31, 48);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 14);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "包裝線代號";
            // 
            // Fm_B003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 311);
            this.Controls.Add(this.groupControl1);
            this.MinimumSize = new System.Drawing.Size(670, 350);
            this.Name = "Fm_B003";
            this.Text = "Fm_B003";
            this.Load += new System.EventHandler(this.Fm_B003_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdNo2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineDesc2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineId2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProdNo1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineDesc1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineId1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbProdNo2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtLineDesc2;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtLineId2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.Button btn_Select;
        private DevExpress.XtraEditors.LookUpEdit cmbProdNo1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtLineDesc1;
        private System.Windows.Forms.Button btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtLineId1;
        private DevExpress.XtraEditors.LabelControl labelControl1;


    }
}