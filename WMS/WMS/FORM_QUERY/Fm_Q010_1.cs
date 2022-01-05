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
    public partial class Fm_Q010_1 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_Q010", "FORM_QUERY"), System.Reflection.Assembly.GetExecutingAssembly());
        public vPublic.EditMode EditMode { get; set; }
        public List<Model.WmsStk> Stks { get; set; }
        List<Model.WmsBinSta> Binstas = new List<WMS.Model.WmsBinSta>();
        Service.WmsBinstaService serviceWmsBinsta = new WMS.Service.WmsBinstaService();

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

        public Fm_Q010_1()
        {
            InitializeComponent();
        }

        public Fm_Q010_1(vPublic.EditMode _EditMode, List<Model.WmsStk> _Stks)
        {
            InitializeComponent();
            EditMode = _EditMode;
            Stks = _Stks;
        }

        private void Fm_Q010_1_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            vPublic.GetWmsProdItems(repositoryItemLookUpEdit_PROD_NO, "", true);
            vPublic.GetWmsOrgItems(repositoryItemLookUpEdit_OrgNo, "");
            vPublic.GetWmsPordTypeItems(repositoryItemLookUpEdit_ProdType);

            InitialQcResultCmb();
            InitialStusCtrCmb();
            if (EditMode == vPublic.EditMode.Update)
            {
                string BinNo = Stks.First().BIN_NO.ToString();
                this.Text=string.Format(RM.GetString("EditFormText"),BinNo);
                GetAllBinNos(EditMode, BinNo);
                cmbBinNo.EditValue = BinNo;
                cmbBinNo.Enabled = false;
                cmbAsrsID.Enabled = false;
            }
            else if (EditMode == vPublic.EditMode.Add)
            {
                this.Text = RM.GetString("AddFormText");
                GetAllBinNos(EditMode, "");
            }

            if (Stks == null)
                Stks = new List<WMS.Model.WmsStk>();


            gdc_WMS_STK.DataSource = Stks;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            gdv_WMS_STK.BeginUpdate();
            Stks.Add(new Model.WmsStk()
            {
                AREA_NO = vPublic.AsrsDefine.AREA_NO,
                WH_NO = vPublic.AsrsDefine.WH_NO,
                ASRS_ID = Convert.ToDecimal(cmbAsrsID.EditValue),
                BIN_NO = cmbBinNo.EditValue == null ? "" : cmbBinNo.EditValue.ToString(),
                STUS_CTR = (decimal)WMS.Model.WmsStk.StusCtr.待驗庫存,
                QC_RESULT = WMS.Model.WmsStk.QCResult.未檢,
                QTY = 1
            });
            
            gdv_WMS_STK.EndUpdate();
        }

        void GetAllBinNos(vPublic.EditMode _EditMode, string BinNo)
        {
            var result = _EditMode == vPublic.EditMode.Add ?
                                    serviceWmsBinsta.GetAllWmsBinstaList(vPublic.AsrsDefine.AREA_NO, vPublic.AsrsDefine.WH_NO, (int)cmbAsrsID.EditValue, ref Binstas) :
                                    serviceWmsBinsta.GetBinDataByBinNo(vPublic.AsrsDefine.AREA_NO, vPublic.AsrsDefine.WH_NO, (int)cmbAsrsID.EditValue, BinNo);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }
            if (_EditMode == vPublic.EditMode.Add)
                Binstas = Binstas.Where(o => o.BIN_STA == "_").ToList();
            else
            {
                Binstas = (List<Model.WmsBinSta>)result.Data;
            }

            List<ComboBoxItemObject> BinNoItems = new List<ComboBoxItemObject>();
            BinNoItems = Binstas.Select(o => new ComboBoxItemObject() { DESC = o.BIN_NO, VALUE = o.BIN_NO }).ToList();
            cmbBinNo.Properties.DataSource = BinNoItems;
            cmbBinNo.Properties.DropDownRows = BinNoItems.Count > 15 ? 15 : BinNoItems.Count;
            cmbBinNo.EditValue = BinNoItems.First().VALUE;
        }

        private void repositoryItemButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gdv_WMS_STK.BeginUpdate();
            Stks.RemoveAt(gdv_WMS_STK.FocusedRowHandle);
            gdv_WMS_STK.EndUpdate();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult();
            Model.WmsStk StkService = new WMS.Model.WmsStk();

            Model.WmsBinSta BinSta = new WMS.Model.WmsBinSta() { AREA_NO = vPublic.AsrsDefine.AREA_NO, WH_NO = vPublic.AsrsDefine.WH_NO, ASRS_ID = Convert.ToInt16(cmbAsrsID.EditValue), BIN_NO = cmbBinNo.EditValue.ToString() };

            Stks.ForEach(o => 
            {
                o.STUS_CTR = o.PROD_TYPE == WMS.Model.WmsStk.ProdType.載具 ? (decimal)Model.WmsStk.StusCtr.可用庫存 : (decimal)o.STUS_CTR;
                o.STOREIN_DATE = o.STOREIN_DATE ?? DateTime.Now;
                o.CREATE_DATE = o.CREATE_DATE ?? DateTime.Now;
                o.UPDATE_DATE = o.UPDATE_DATE ?? DateTime.Now;
                o.CREATE_BY = o.CREATE_BY ?? Program.wmsUser.UserNo;
                o.UPDATE_BY = o.UPDATE_BY ?? Program.wmsUser.UserNo;
            });

            if (EditMode == vPublic.EditMode.Add)
            {
                result = StkService.Add(Stks, BinSta);
            }
            else if (EditMode == vPublic.EditMode.Update)
            {
                result = StkService.Edit(Stks, BinSta);
            }

            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
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

        private void gdv_WMS_STK_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "PROD_NO")
            {
                var Row = repositoryItemLookUpEdit_PROD_NO.GetDataSourceRowByDisplayValue(gdv_WMS_STK.GetFocusedRowCellValue("PROD_NO").ToString()) as DataRowView;
                gdv_WMS_STK.SetFocusedRowCellValue("PROD_NAME", Row["PROD_NAME"].ToString());
                gdv_WMS_STK.SetFocusedRowCellValue("UN", Row["UN"].ToString());
                gdv_WMS_STK.SetFocusedRowCellValue("PROD_TYPE", (Model.WmsStk.ProdType)Enum.ToObject(typeof(Model.WmsStk.ProdType),Convert.ToInt16(Row["PROD_TYPE"])));
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
    }
}
