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
    public partial class Fm_A002_3 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_A002", "FORM_ASRS"), System.Reflection.Assembly.GetExecutingAssembly());

        Service.WcsCrnService service = new WMS.Service.WcsCrnService();
        List<Model.WcsCrnErrorLog> ErrorLogs = new List<Model.WcsCrnErrorLog>();

        public Fm_A002_3()
        {
            InitializeComponent();
        }

        private void Fm_A002_3_Load(object sender, EventArgs e)
        {
            vPublic.GetCrnItems(cmbCrnID);
            cmbCrnID.StyleController = Program.STYLER;
            dateEditEdate.StyleController = Program.STYLER;
            dateEditSdate.StyleController = Program.STYLER;

            vPublic.RestoreViewLayoutByStream(gdv_WCS_CRN_ERR_LOG, this.Name, 1, true);

            dateEditSdate.EditValue = DateTime.Now.AddDays(-14);
            dateEditEdate.EditValue = DateTime.Now.AddDays(-1);

            RefreshData();
        }

        void RefreshData()
        {
            var result = service.GetAllCrnErrorLogList((int?)cmbCrnID.EditValue, (DateTime?)dateEditSdate.EditValue, (DateTime?)dateEditEdate.EditValue);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            ErrorLogs = (List<Model.WcsCrnErrorLog>)result.Data;
            gdc_WCS_CRN_ERR_LOG.DataSource = ErrorLogs;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>();
            
            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WCS_CRN_ERR_LOG.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WCS_CRN_ERR_LOG, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WCS_CRN_ERR_LOG, this.Name, 1, false);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gdc_WCS_CRN_ERR_LOG.ShowPrintPreview();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("{0}_{1}", RM.GetString("ExcellFilename"), DateTime.Now.ToString("yyyyMMddHHmmss"));
            sfd.Filter = "Excel |*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gdv_WCS_CRN_ERR_LOG.ExportToXlsx(sfd.FileName);
            }
        }
    }
}
