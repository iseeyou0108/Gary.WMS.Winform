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
    public partial class Fm_Q007 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_Q007", "FORM_QUERY"), System.Reflection.Assembly.GetExecutingAssembly());

        public Fm_Q007()
        {
            InitializeComponent();
        }

        private void Fm_Q007_Load(object sender, EventArgs e)
        {
            txtFilter.StyleController = Program.STYLER;
            dateEditSdate.StyleController = Program.STYLER;
            dateEditEdate.StyleController = Program.STYLER;
            vPublic.RestoreViewLayoutByStream(gdv_WMS_USER_OPR_HIST, this.Name, 1, true);

            dateEditSdate.EditValue = DateTime.Now.AddDays(-14);
            dateEditEdate.EditValue = DateTime.Now;

            RefreshData();
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>();

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_USER_OPR_HIST.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_USER_OPR_HIST, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_USER_OPR_HIST, this.Name, 1, false);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            string strSql = string.Empty, strSqlWhere = string.Empty;
            strSql = "select a.*, isnull(b.FORM_TEXT,a.ACT_PROG) FORM_NAME, isnull(c.USER_NAME, a.CREATE_BY) CREATE_NAME " +
                                           " from WMS_USER_OPR_HIST a  " +
                                           " left join HRS_MENU_VW b on b.LANG_ID = @LANG_ID and a.ACT_PROG = b.FORM_NAME " +
                                           " left join HRS_USER c on a.CREATE_BY = c.USER_NO "+
                                           " where 1 = 1 {0} "+
                                           " order by a.CREATE_DATE ";

            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();
            parameters.Add(new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = (int)Program.LangID });

            if (dateEditSdate.EditValue != null)
            {
                strSqlWhere += " and a.CREATE_DATE >= @SDATE ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "SDATE", Value = (DateTime)dateEditSdate.EditValue });
            }

            if (dateEditEdate.EditValue != null)
            {
                strSqlWhere += " and a.CREATE_DATE <= @EDATE ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "EDATE", Value = (DateTime)dateEditEdate.EditValue });
            }

            var result = vPublic.GetDbData(string.Format(strSql, strSqlWhere), parameters);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            //處理SearchString
            if (!string.IsNullOrEmpty(txtFilter.Text))
            {
                result.ResultDt = result.ResultDt.AsEnumerable().Where(o => o.Field<string>("ACT_PROG").Contains(txtFilter.Text) ||
                    (o.Field<string>("ACT_REMARK") ?? string.Empty).Contains(txtFilter.Text) ||
                    (o.Field<string>("FORM_NAME") ?? string.Empty).Contains(txtFilter.Text) ||
                    (o.Field<string>("CREATE_NAME") ?? string.Empty).Contains(txtFilter.Text)
                    ).CopyToDataTable();
            }

            gdc_WMS_USER_OPR_HIST.DataSource = result.ResultDt;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gdc_WMS_USER_OPR_HIST.ShowPrintPreview();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("{0}_{1}", RM.GetString("ExcellFilename"), DateTime.Now.ToString("yyyyMMddHHmmss"));
            sfd.Filter = "Excel |*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gdv_WMS_USER_OPR_HIST.ExportToXlsx(sfd.FileName);
            }
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshData();
        }

        private void txtFilter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            RefreshData();
        }

    }
}
