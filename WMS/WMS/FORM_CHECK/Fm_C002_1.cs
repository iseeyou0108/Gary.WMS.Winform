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
    public partial class Fm_C002_1 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_C002", "FORM_CHECK"), System.Reflection.Assembly.GetExecutingAssembly());
        public vPublic.EditMode EditMode { get; set; }
        public List<Model.WmsStk> Stks { get; set; }
        public List<Model.WmsStk> CurStks = new List<WMS.Model.WmsStk>();
        Service.WmsCycdService serviceCycd = new WMS.Service.WmsCycdService();
        Model.WmsStk serviceWmsStk = new WMS.Model.WmsStk();

        public class ComboBoxItemObject
        {
            public string DESC { get; set; }
            public object VALUE { get; set; }
        }

        public class QcResultItem
        {
            public Model.WmsStk.QCResult QC_RESULT { get; set; }
            public string QC_RESULT_DESC { get; set; }
        }
        public class StatusCtrItem
        {
            public decimal STUS_CTR { get; set; }
            public string STUS_CTR_DESC { get; set; }
        }

        public Fm_C002_1()
        {
            InitializeComponent();
        }

        public Fm_C002_1(vPublic.EditMode _EditMode, List<Model.WmsStk> _Stks)
        {
            InitializeComponent();
            EditMode = _EditMode;
            Stks = _Stks;
        }

        private void InitialStusCtrCmb()
        {
            List<StatusCtrItem> Items = new List<StatusCtrItem>()
             {
                 new StatusCtrItem()
                 {
                    STUS_CTR= (decimal)WMS.Model.WmsStk.StusCtr.待驗庫存,
                    STUS_CTR_DESC=RM.GetString("StusCtr1")
                 },
                 new StatusCtrItem()
                 {
                    STUS_CTR= (decimal)WMS.Model.WmsStk.StusCtr.可用庫存,
                    STUS_CTR_DESC=RM.GetString("StusCtr2")
                 }
             };
            repositoryItemLookUpEdit_STUS_CTR.DataSource = Items;
        }

        private void InitialQcResultCmb()
        {
            List<QcResultItem> Items = new List<QcResultItem>()
             {
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.未檢,
                    QC_RESULT_DESC=RM.GetString("QCResult0")
                 },
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.合格,
                    QC_RESULT_DESC=RM.GetString("QCResult1")
                 },
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.不合格,
                    QC_RESULT_DESC=RM.GetString("QCResult2")
                 },
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.劣品,
                    QC_RESULT_DESC=RM.GetString("QCResult3")
                 },
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.良品,
                    QC_RESULT_DESC=RM.GetString("QCResult4")
                 },
                 new QcResultItem()
                 {
                    QC_RESULT= WMS.Model.WmsStk.QCResult.待退,
                    QC_RESULT_DESC=RM.GetString("QCResult5")
                 }
             };
            repositoryItemLookUpEdit_QC_RESULT.DataSource = Items;
            //cmbQCResult.Properties.DataSource = Items;
            //cmbQCResult.Properties.DropDownRows = Items.Count;
        }

        private void Fm_C002_1_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            vPublic.GetWmsProdItems(repositoryItemLookUpEdit_PROD_NO, "", true);
            vPublic.GetWmsOrgItems(repositoryItemLookUpEdit_OrgNo, "");
            vPublic.GetWmsPordTypeItems(repositoryItemLookUpEdit_ProdType);

            InitialStusCtrCmb();
            InitialQcResultCmb();

            lblWhNo.Text = Stks.First().WH_NO;
            lblSerNo.Text = Stks.First().UPDATE_BY;
            lblDateTime.Text = Stks.First().UPDATE_DATE.Value.ToString("yyyy/MM/dd HH:mm:ss");

            gdc_WMS_STK.DataSource = Stks;
        }

        private void gdv_WMS_STK_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "PROD_NO")
            {
                var Row = repositoryItemLookUpEdit_PROD_NO.GetDataSourceRowByDisplayValue(gdv_WMS_STK.GetFocusedRowCellValue("PROD_NO").ToString()) as DataRowView;
                gdv_WMS_STK.SetFocusedRowCellValue("PROD_NAME", Row["PROD_NAME"].ToString());
                gdv_WMS_STK.SetFocusedRowCellValue("UN", Row["UN"].ToString());
                gdv_WMS_STK.SetFocusedRowCellValue("PROD_TYPE", (Model.WmsStk.ProdType)Enum.ToObject(typeof(Model.WmsStk.ProdType), Convert.ToInt16(Row["PROD_TYPE"])));
                //gdv_WMS_STK.SetFocusedRowCellValue("PROD_TYPE_DESC", RM.GetString(string.Format("PROD_TYPE_{0}", Row["PROD_TYPE"].ToString())));
                gdv_WMS_STK.UpdateCurrentRow();
            }

            if (e.Column.FieldName == "ORG_NO")
            {
                var Row = repositoryItemLookUpEdit_OrgNo.GetDataSourceRowByDisplayValue(gdv_WMS_STK.GetFocusedRowCellValue("ORG_NO").ToString()) as DataRowView;
                gdv_WMS_STK.SetFocusedRowCellValue("ORG_SNAME", Row["SNAME"].ToString());
                gdv_WMS_STK.UpdateCurrentRow();
            }
        }

        private void repositoryItemButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gdv_WMS_STK.BeginUpdate();
            Stks.RemoveAt(gdv_WMS_STK.FocusedRowHandle);
            gdv_WMS_STK.EndUpdate();
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            gdv_WMS_STK.BeginUpdate();
            Stks.Add(new Model.WmsStk()
            {
                AREA_NO = vPublic.AsrsDefine.AREA_NO,
                WH_NO = vPublic.AsrsDefine.WH_NO_C,
                ASRS_ID = vPublic.AsrsDefine.ASRS_ID,
                BIN_NO = "",
                STUS_CTR = (decimal)WMS.Model.WmsStk.StusCtr.盤點待回庫,
                QC_RESULT = WMS.Model.WmsStk.QCResult.未檢,
                QTY = 1,
                UPDATE_BY = Stks.First().UPDATE_BY,
                UPDATE_DATE = Stks.First().UPDATE_DATE
            });

            gdv_WMS_STK.EndUpdate();
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
                this.DialogResult = DialogResult.Cancel;
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult();

            result = serviceWmsStk.GetAllWmsStk((int)cmbAsrsID.EditValue,ref CurStks);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            CurStks = CurStks.Where(o => o.UPDATE_BY == lblSerNo.Text && o.UPDATE_DATE == DateTime.Parse(lblDateTime.Text) && o.WH_NO == vPublic.AsrsDefine.WH_NO_C && o.STUS_CTR == (decimal)Model.WmsStk.StusCtr.盤點待回庫).ToList();

            result = serviceCycd.Save(Stks, CurStks);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
