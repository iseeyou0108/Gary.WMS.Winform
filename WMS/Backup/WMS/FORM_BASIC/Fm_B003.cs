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
    public partial class Fm_B003 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_B003", "FORM_BASIC"), System.Reflection.Assembly.GetExecutingAssembly());
        
        Service.CusLineSettingService service = new WMS.Service.CusLineSettingService();
        List<Model.CusLineSetting> Datas = new List<WMS.Model.CusLineSetting>();

        public Fm_B003()
        {
            InitializeComponent();
        }

        private void Fm_B003_Load(object sender, EventArgs e)
        {
            List<DevExpress.XtraEditors.LookUpEdit> ProdCmbs = new List<DevExpress.XtraEditors.LookUpEdit>()
            {
                cmbProdNo1,
                cmbProdNo2
            };
            vPublic.GetWmsProdItems(ProdCmbs, "");

            txtLineId1.StyleController = Program.STYLER;
            txtLineDesc1.StyleController = Program.STYLER;
            cmbProdNo1.StyleController = Program.STYLER;

            txtLineId2.StyleController = Program.STYLER;
            txtLineDesc2.StyleController = Program.STYLER;
            cmbProdNo2.StyleController = Program.STYLER;

            SET_PRIV();

            RefreshData();
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);
            btnSave.Visible = FormPriv.Exec;
        }

        private void RefreshData()
        {
            var result = service.GetData();
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            Datas = (List<Model.CusLineSetting>)result.Data;

            var Line1 = Datas.Where(o => o.LINE_ID == 1).SingleOrDefault();
            var Line2 = Datas.Where(o => o.LINE_ID == 2).SingleOrDefault();

            txtLineId1.Text = Line1.LINE_ID.ToString();
            txtLineDesc1.Text = Line1.LINE_DESC;
            cmbProdNo1.EditValue = Line1.PROD_NO;

            txtLineId2.Text = Line2.LINE_ID.ToString();
            txtLineDesc2.Text = Line2.LINE_DESC;
            cmbProdNo2.EditValue = Line2.PROD_NO;
        }

        private void cmbProdNo_KeyUp(object sender, KeyEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit edit = sender as DevExpress.XtraEditors.LookUpEdit;
            if (e.KeyCode == Keys.Delete)
            {
                edit.ClosePopup();
                edit.EditValue = null;
            }
            e.Handled = true;
        }

        private void btn_Select_Click_1(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbProdNo1.EditValue == null)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, RM.GetString("Msg0001"));   //料號不可為空值
                return;
            }

            if (MessageBox.Show(this, RM.GetString("ConfirmMessage"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var Line1 = Datas.Where(o => o.LINE_ID == 1).SingleOrDefault();
            var Line2 = Datas.Where(o => o.LINE_ID == 2).SingleOrDefault();

            Line1.LINE_DESC = txtLineDesc1.Text;
            Line1.PROD_NO = cmbProdNo1.EditValue.ToString();

            Line2.LINE_DESC = txtLineDesc2.Text;
            Line2.PROD_NO = cmbProdNo2.EditValue.ToString();

            var result = service.Edit(new List<Model.CusLineSetting>() { Line1, Line2 });
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);
            RefreshData();
        }
    }
}
