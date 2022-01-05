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
    public partial class Fm_C003 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_C003", "FORM_CHECK"), System.Reflection.Assembly.GetExecutingAssembly());
        Service.WmsCycdService serviceWmsCycd = new WMS.Service.WmsCycdService();

        public Fm_C003()
        {
            InitializeComponent();
        }

        private void Fm_C003_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            vPublic.GetWmsProdItems(cmbProdNo, "");

            SET_PRIV();

            vPublic.RestoreViewLayoutByStream(gdv_WMS_CYCD, this.Name, 1, true);

            RefreshData();
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);

            btnReply.Visible = FormPriv.Exec;
        }

        private void RefreshData()
        {

            List<Model.WmsCycd> Data = new List<Model.WmsCycd>();
            var result = serviceWmsCycd.GetData(null, null, cmbProdNo.EditValue == null ? string.Empty : cmbProdNo.EditValue.ToString());

            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            Data = (List<Model.WmsCycd>)result.Data;

            if (chkReplyFlag.Checked)
                Data = Data.Where(o => o.REPLY_FLG == WMS.Model.WmsCycd.ReplyFlag.未回報).ToList();

            gdc_WMS_CYCD.DataSource = Data;

            chkAll.Checked = false;
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>()
            {
                colCHK
            };

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_CYCD.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_CYCD, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_CYCD, this.Name, 1, false);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("{0}_{1}", RM.GetString("ExcellFilename"), DateTime.Now.ToString("yyyyMMddHHmmss"));
            sfd.Filter = "Excel |*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gdv_WMS_CYCD.ExportToXlsx(sfd.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gdc_WMS_CYCD.ShowPrintPreview();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            //var Data = (List<Model.WmsCycd>)gdc_WMS_CYCD.DataSource;

            //Data.ForEach(o => { o.CHK = chkAll.Checked; });

            gdv_WMS_CYCD.BeginUpdate();
            ((List<Model.WmsCycd>)gdc_WMS_CYCD.DataSource).ForEach(o => { o.CHK = chkAll.Checked; });
            gdv_WMS_CYCD.EndUpdate();
        }
    }
}
