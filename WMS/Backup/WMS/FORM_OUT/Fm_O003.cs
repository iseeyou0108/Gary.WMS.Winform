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
    public partial class Fm_O003 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_O003", "FORM_OUT"), System.Reflection.Assembly.GetExecutingAssembly());
        

        public Fm_O003()
        {
            InitializeComponent();
        }

        private void Fm_O003_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            vPublic.GetCrnItems(cmbCrnID);
            vPublic.GetStoreOutDevNoItems(cmbDevNo);
            SET_PRIV();

            vPublic.RestoreViewLayoutByStream(gdv_WMS_BINSTA, this.Name, 1, true);

            RefreshData();
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);

            btnExec.Visible = FormPriv.Exec;
        }

        void RefreshData()
        {
            Service.WmsBinstaService BinStaService = new WMS.Service.WmsBinstaService();
            List<Model.WmsBinSta> Binstas = new List<Model.WmsBinSta>();
            var result = BinStaService.GetAllWmsBinstaList(vPublic.AsrsDefine.AREA_NO, vPublic.AsrsDefine.WH_NO, Convert.ToInt16(cmbAsrsID.EditValue), ref Binstas);

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
                        Binstas = Binstas.Where(o => o.CRN_ID == Convert.ToInt16(cmbCrnID.EditValue)).ToList();
                }
            }

            Binstas = Binstas.Where(o => o.BIN_STA == "P").ToList();

            gdc_WMS_BINSTA.DataSource = Binstas;
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>()
            {
                colCHK
            };

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_BINSTA.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_BINSTA, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_BINSTA, this.Name, 1, false);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (gdc_WMS_BINSTA.DataSource == null) return;
            if (gdv_WMS_BINSTA.RowCount <= 0) return;
            
            var BinStas = ((List<Model.WmsBinSta>)gdc_WMS_BINSTA.DataSource).ToList();

            if (BinStas != null)
            {
                foreach (var BinSta in BinStas)
                    BinSta.CHK = chkAll.Checked;


                gdc_WMS_BINSTA.DataSource = BinStas;
            }
        }

        private void btnExec_Click(object sender, EventArgs e)
        {
            Model.WcsTrk TrkService = new WMS.Model.WcsTrk();

            if (gdc_WMS_BINSTA.DataSource == null) return;
            if (gdv_WMS_BINSTA.RowCount <= 0) return;
            
            var BinStas = ((List<Model.WmsBinSta>)gdc_WMS_BINSTA.DataSource).ToList();
            var CheckLists = BinStas.Any(o => o.CHK == true);

            if (CheckLists == null)
            {
                //Msg0001 請先勾選要出庫的先入品庫存
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0001"));
                return;
            }

            if (CheckLists == false)
            {
                //Msg0001 請先勾選要出庫的先入品庫存
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0001"));
                return;
            }

            if (MessageBox.Show(this, RM.GetString("ConfirmMessage"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;


            BinStas = BinStas.Where(o => o.CHK == true).ToList();
            var result = TrkService.CreateUnknownStkOut(BinStas, cmbDevNo.Text);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
                RefreshData();
        }
    }
}
