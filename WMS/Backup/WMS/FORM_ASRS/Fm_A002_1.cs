using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class Fm_A002_1 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_A002", "FORM_ASRS"), System.Reflection.Assembly.GetExecutingAssembly());
        public List<Model.WcsCrn> Crns = new List<WMS.Model.WcsCrn>();
        Service.WcsCrnService service = new WMS.Service.WcsCrnService();

        public Fm_A002_1()
        {
            InitializeComponent();
        }

        public Fm_A002_1(List<Model.WcsCrn> _Crns)
        {
            InitializeComponent();
            Crns = _Crns;
        }

        private void Fm_A002_1_Load(object sender, EventArgs e)
        {
            gdc_WCS_CRN.DataSource = Crns;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x10) // The upper right "X" was clicked
            {
                AutoValidate = AutoValidate.Disable; //Deactivate all validations
            }
            base.WndProc(ref m);
        }

        // To capture the "Esc" key
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                AutoValidate = AutoValidate.Disable;
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Crns.Any(o => o.CHK))
            {
                //請先勾選要設定的吊車	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0001"));
                return;
            }

            //確定要針對選取的吊車執行「禁用設定」嗎?
            if (MessageBox.Show(this, RM.GetString("ConfirmMessage"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var result = service.SubmitCrnDisableSettings(Crns.Where(o=>o.CHK).ToList(), chkDisableIn.Checked, chkDisableOut.Checked);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
                Close();
        }

    }
}
