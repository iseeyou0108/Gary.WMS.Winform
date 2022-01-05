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
    public partial class Fm_C002 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_C002", "FORM_CHECK"), System.Reflection.Assembly.GetExecutingAssembly());

        public Fm_C002()
        {
            InitializeComponent();
        }

        private void Fm_C002_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            vPublic.GetWmsProdItems(cmbProdNo, "");
            vPublic.GetCheckOutDevNoItems(cmbDevNo);

            cmbDevNo.Enabled = false;

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
            var result = StkLib.GetAllWmsStk(Convert.ToInt16(cmbAsrsID.EditValue), WMS.Model.WmsStk.ProdType.成品_原物料, ref Stks);

            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            if (cmbProdNo.EditValue != null)
            {
                if (!string.IsNullOrEmpty(cmbProdNo.EditValue.ToString()))
                    Stks = Stks.Where(o => o.PROD_NO == cmbProdNo.EditValue.ToString()).ToList();
            }

            //盤點待回庫
            Stks = Stks.Where(o => o.STUS_CTR == Convert.ToDecimal(Model.WmsStk.StusCtr.盤點待回庫)).ToList();

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

            var result = TrkLib.CreateStkCheckOut(Stks, cmbDevNo.Text);

            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
                RefreshData();
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

        private void repositoryItemButtonEdit_Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Stks = ((List<Model.WmsStk>)gdc_WMS_STK.DataSource).ToList();
            string UPDATE_BY = gdv_WMS_STK.GetFocusedRowCellValue("UPDATE_BY").ToString();
            DateTime? UPDATE_DATE = Convert.ToDateTime(gdv_WMS_STK.GetFocusedRowCellValue("UPDATE_DATE").ToString());

            var EditStks = Stks.Where(o => o.UPDATE_BY == UPDATE_BY && o.UPDATE_DATE == UPDATE_DATE).ToList();

            Fm_C002_1 objForm = new Fm_C002_1(vPublic.EditMode.Update, EditStks);
            objForm.StartPosition = FormStartPosition.CenterParent;
            if (objForm.ShowDialog() == DialogResult.OK)
                RefreshData();
            
        }
    }
}
