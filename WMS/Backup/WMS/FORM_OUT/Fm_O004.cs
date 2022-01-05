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
    public partial class Fm_O004 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_O004", "FORM_OUT"), System.Reflection.Assembly.GetExecutingAssembly());
        
        public Fm_O004()
        {
            InitializeComponent();
        }

        private void Fm_O004_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            vPublic.GetCrnItems(cmbCrnID);
            vPublic.GetPalletSupplyDevNoItems(cmbDevNo);
            SET_PRIV();

            vPublic.RestoreViewLayoutByStream(gdv_WMS_STK, this.Name, 1, true);
            RefreshData();
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);

            btnExec.Visible = FormPriv.Exec;
        }

        void RefreshData()
        {
            Model.WmsStk StkLib = new WMS.Model.WmsStk();
            List<Model.WmsStk> Stks = new List<Model.WmsStk>();
            var result = StkLib.GetAllWmsStk(Convert.ToInt16(cmbAsrsID.EditValue), WMS.Model.WmsStk.ProdType.載具, ref Stks);

            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            if (cmbCrnID.EditValue != null)
            {
                if (!string.IsNullOrEmpty(cmbCrnID.EditValue.ToString()))
                {
                    if (cmbCrnID.EditValue.ToString() != "0")
                        Stks = Stks.Where(o => o.CRN_ID == Convert.ToInt16(cmbCrnID.EditValue)).ToList();
                }
            }

            Stks = Stks.Where(o => o.STUS_CTR == Convert.ToDecimal(Model.WmsStk.StusCtr.可用庫存)).ToList();

            gdc_WMS_STK.DataSource = Stks;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>()
            {
                colCHK
            };

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_STK.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_STK, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_STK, this.Name, 1, false);
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (gdc_WMS_STK.DataSource == null) return;
            if (gdv_WMS_STK.RowCount <= 0) return;

            var Stks = ((List<Model.WmsStk>)gdc_WMS_STK.DataSource).ToList();

            if (Stks != null)
            {
                foreach (var Stk in Stks)
                    Stk.CHK = chkAll.Checked;


                gdc_WMS_STK.DataSource = Stks;
            }
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            Model.WcsTrk TrkLib = new WMS.Model.WcsTrk();
            if (gdc_WMS_STK.DataSource == null) return;
            if (gdv_WMS_STK.RowCount <= 0) return;

            var Stks = ((List<Model.WmsStk>)gdc_WMS_STK.DataSource).ToList();

            if (Stks == null) return;
            if (Stks.Count <= 0) return;

            Stks = Stks.Where(o => o.CHK == true).ToList();
            if (Stks.Count <= 0)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0001"));    //請先選取要出庫的庫存
                return;
            }

            if (MessageBox.Show(this, RM.GetString("ConfirmMessage"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var result = TrkLib.CreatePalletOut(Stks, cmbDevNo.Text);

            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
                RefreshData();
        }
    }
}
