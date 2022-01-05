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
    public partial class Fm_I001 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_I001", "FORM_IN"), System.Reflection.Assembly.GetExecutingAssembly());
        Service.WmsListService ListService = new WMS.Service.WmsListService();

        public Fm_I001()
        {
            InitializeComponent();
        }

        private void Fm_I001_Load(object sender, EventArgs e)
        {
            vPublic.GetListStatusCtrItems(cmbStatusCtr);
            vPublic.GetListStatusCtrItems(cmbStatusCtr2);
            vPublic.GetWmsProdItems(cmbProdNo, "", true);
            cmbProdNo.Properties.DisplayMember = "PROD_NO";
            cmbProdNo.Properties.ValueMember = "PROD_NO";
            vPublic.GetWmsOrgItems(cmbOrgNo, "");

            txtLineID.StyleController = Program.STYLER;
            txtListNo.StyleController = Program.STYLER;
            txtLotNo.StyleController = Program.STYLER;
            txtProdName.StyleController = Program.STYLER;
            txtRemark.StyleController = Program.STYLER;
            txtSname.StyleController = Program.STYLER;
            txtUn.StyleController = Program.STYLER;
            cmbOrgNo.StyleController = Program.STYLER;
            cmbProdNo.StyleController = Program.STYLER;
            cmbStatusCtr.StyleController = Program.STYLER;
            cmbStatusCtr2.StyleController = Program.STYLER;
            dateEditEdate.StyleController = Program.STYLER;
            dateEditSdate.StyleController = Program.STYLER;
            datePDate.StyleController = Program.STYLER;

            txtListNo.Properties.ReadOnly = true;
            txtLineID.Properties.ReadOnly = true;
            txtProdName.Properties.ReadOnly = true;
            cmbStatusCtr2.Properties.ReadOnly = true;

            dateEditSdate.EditValue = DateTime.Now.AddDays(-7);
            dateEditEdate.EditValue = DateTime.Now;

            RefreshData(Convert.ToDateTime(dateEditSdate.EditValue), Convert.ToDateTime(dateEditEdate.EditValue), null);
        }

        private void cmbStatusCtr_KeyUp(object sender, KeyEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit edit = sender as DevExpress.XtraEditors.LookUpEdit;
            if (e.KeyCode == Keys.Delete)
            {
                edit.ClosePopup();
                edit.EditValue = null;
            }
            e.Handled = true;
        }

        private void RefreshData(DateTime? Sdate, DateTime? Edate, vPublic.StatusCtr? _StatusCtr)
        {

            List<Model.WmsInLine> InLiests = new List<Model.WmsInLine>();
            var result = ListService.GetAllWmsInLine(Sdate, Edate, _StatusCtr, ref InLiests);

            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            gdc_WMS_IN_LINE.DataSource = InLiests;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            DateTime? dtStart = null;
            DateTime? dtEnd = null;
            vPublic.StatusCtr? _StatusCtr = null;

            if (dateEditSdate.EditValue != null)
                dtStart = Convert.ToDateTime(dateEditSdate.EditValue);
            if (dateEditEdate.EditValue != null)
                dtEnd = Convert.ToDateTime(dateEditEdate.EditValue);
            if (cmbStatusCtr.EditValue != null)
                _StatusCtr = (vPublic.StatusCtr)Enum.ToObject(typeof(vPublic.StatusCtr), Convert.ToInt16(cmbStatusCtr.EditValue));

            RefreshData(dtStart, dtEnd, _StatusCtr);
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>()
            {
                colEdit2,
                colDelete2
            };
            
            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_IN_LINE.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_IN_LINE, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_IN_LINE, this.Name, 1, false);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("{0}_{1}", RM.GetString("ExcellFilename"), DateTime.Now.ToString("yyyyMMddHHmmss"));
            sfd.Filter = "Excel |*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gdv_WMS_IN_LINE.ExportToXlsx(sfd.FileName);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            colEdit2.Visible = false;
            colDelete2.Visible = false;

            gdc_WMS_IN_LINE.ShowPrintPreview();

            colEdit2.Visible = true;
            colDelete2.Visible = true;
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Fm_I001_1 objForm = new Fm_I001_1();
            objForm.ShowDialog();
            btn_Select_Click(null, null);
        }

        private void repositoryItemButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string LIST_NO = gdv_WMS_IN_LINE.GetFocusedRowCellValue("LIST_NO").ToString();
            int LINE_ID = Convert.ToInt16(gdv_WMS_IN_LINE.GetFocusedRowCellValue("LINE_ID"));

            List<Model.WmsInLine> Data = new List<WMS.Model.WmsInLine>();
            var result = ListService.GetWmsInLineByListNoAndID(LIST_NO, LINE_ID, ref Data);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            if (Data == null)
            {
                //單號{0}, 項次{1}, 已被刪除, 請重新查詢確認
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0005"), LIST_NO, LINE_ID));
                return;
            }

            if (Data.Count <= 0)
            {
                //單號{0}, 項次{1}, 已被刪除, 請重新查詢確認
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0005"), LIST_NO, LINE_ID));
                return;
            }

            switch ((vPublic.StatusCtr)Data.First().STATUS_CTR)
            {
                case vPublic.StatusCtr.接單:
                case vPublic.StatusCtr.強制結單:
                case vPublic.StatusCtr.完成:
                case vPublic.StatusCtr.手動觸發強制結單:
                    break;
                case vPublic.StatusCtr.收料中:
                case vPublic.StatusCtr.出庫中:
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0004"));    //單據狀態非接單或完成狀態，無法刪除單據資料
                    return;
                    break;
                default:
                    break;
            }

            if (Data.First().WMS_QTY > 0 ||
                Data.First().TMP_QTY > 0
              )
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0004"));    //單據狀態非接單或完成狀態，無法刪除單據資料
                return;
            }

            if (MessageBox.Show(this, RM.GetString("ConfirmMessage"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            //刪除單據資料
            result = ListService.DeleteWmsInList(Data);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);
            if(result.Successed)
                btn_Select_Click(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            gpEdit.Visible = false;
        }

        private void repositoryItemButtonEdit_Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string LIST_NO = gdv_WMS_IN_LINE.GetFocusedRowCellValue("LIST_NO").ToString();
            int LINE_ID = Convert.ToInt16(gdv_WMS_IN_LINE.GetFocusedRowCellValue("LINE_ID"));

            List<Model.WmsInLine> Data = new List<WMS.Model.WmsInLine>();
            var result = ListService.GetWmsInLineByListNoAndID(LIST_NO, LINE_ID, ref Data);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            if (Data == null)
            {
                //單號{0}, 項次{1}, 已被刪除, 請重新查詢確認
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0005"), LIST_NO, LINE_ID));
                return;
            }

            if (Data.Count <= 0)
            {
                //單號{0}, 項次{1}, 已被刪除, 請重新查詢確認
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0005"), LIST_NO, LINE_ID));
                return;
            }

            switch ((vPublic.StatusCtr)Data.First().STATUS_CTR)
            {
                case vPublic.StatusCtr.接單:
                    break;
                case vPublic.StatusCtr.收料中:
                case vPublic.StatusCtr.出庫中:
                case vPublic.StatusCtr.強制結單:
                case vPublic.StatusCtr.完成:
                case vPublic.StatusCtr.手動觸發強制結單:
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0006"));    //單據狀態非接單狀態，無法編輯單據資料
                    return;
                    break;
                default:
                    break;
            }

            if (Data.First().WMS_QTY > 0 ||
                Data.First().TMP_QTY > 0
              )
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0006"));    //單據狀態非接單狀態，無法編輯單據資料
                return;
            }

            var EditModel = Data.First();

            txtListNo.Text = EditModel.LIST_NO;
            txtLineID.Text = EditModel.LINE_ID.ToString();
            txtLotNo.Text = EditModel.LOT_NO;
            
            txtRemark.Text = EditModel.REMARK;
            txtSname.Text = EditModel.SNAME;
            
            cmbOrgNo.EditValue = EditModel.ORG_NO;
            cmbProdNo.EditValue = EditModel.PROD_NO;
            txtProdName.Text = EditModel.PROD_NAME;
            txtUn.Text = EditModel.UN;
            cmbStatusCtr2.EditValue = EditModel.STATUS_CTR;
            if (EditModel.PRODUCTION_DATE.HasValue)
                datePDate.EditValue = EditModel.PRODUCTION_DATE.Value;
            else
            {
                if (!string.IsNullOrEmpty(EditModel.PDATE))
                    datePDate.EditValue = EditModel.PDATE;
                else
                    datePDate.EditValue = null;
            }

            spinQty.Value = EditModel.QTY;

            gpEdit.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string LIST_NO = txtListNo.Text.Trim();
            int LINE_ID = Convert.ToInt16(txtLineID.Text.Trim());

            List<Model.WmsInLine> Data = new List<WMS.Model.WmsInLine>();
            var result = ListService.GetWmsInLineByListNoAndID(LIST_NO, LINE_ID, ref Data);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            if (MessageBox.Show(this, RM.GetString("ConfirmEditMessage"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            var EditModel = Data.Where(o => o.LIST_NO == LIST_NO && o.LINE_ID == LINE_ID).First();

            EditModel.PROD_NO = cmbProdNo.EditValue.ToString();
            EditModel.PROD_NAME = txtProdName.Text.Trim();
            EditModel.LOT_NO = txtLotNo.Text.Trim();
            EditModel.ORG_NO = cmbOrgNo.EditValue==null?string.Empty:cmbOrgNo.EditValue.ToString();
            EditModel.SNAME = txtSname.Text.Trim();
            EditModel.UN = txtUn.Text.Trim();
            EditModel.QTY = spinQty.Value;
            if (datePDate.EditValue != null)
                EditModel.PRODUCTION_DATE = Convert.ToDateTime(datePDate.EditValue);
            else
                EditModel.PRODUCTION_DATE = null;
            EditModel.REMARK = txtRemark.Text.Trim();

            result = ListService.EditWmsInList(Data);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);
            if (result.Successed)
            {
                btn_Select_Click(null, null);
                gpEdit.Visible = false;
            }
        }

        /// <summary>
        /// 強制結單
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryItemButtonEdit_Complete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string LIST_NO = gdv_WMS_IN_LINE.GetFocusedRowCellValue("LIST_NO").ToString();
            int LINE_ID = Convert.ToInt16(gdv_WMS_IN_LINE.GetFocusedRowCellValue("LINE_ID"));

            List<Model.WmsInLine> Data = new List<WMS.Model.WmsInLine>();
            var result = ListService.GetWmsInLineByListNoAndID(LIST_NO, LINE_ID, ref Data);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            if (Data == null)
            {
                //單號{0}, 項次{1}, 已被刪除, 請重新查詢確認
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0005"), LIST_NO, LINE_ID));
                return;
            }

            if (Data.Count <= 0)
            {
                //單號{0}, 項次{1}, 已被刪除, 請重新查詢確認
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0005"), LIST_NO, LINE_ID));
                return;
            }

            switch ((vPublic.StatusCtr)Data.First().STATUS_CTR)
            {
                case vPublic.StatusCtr.強制結單:
                case vPublic.StatusCtr.完成:
                case vPublic.StatusCtr.手動觸發強制結單:
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0007"));    //單據狀態非接單或出庫中狀態，無法強制結單	
                    return;
                    break;
                case vPublic.StatusCtr.收料中:
                case vPublic.StatusCtr.出庫中:
                case vPublic.StatusCtr.接單:
                    break;
                default:
                    break;
            }

            if (Data.First().TMP_QTY > 0)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0008"));    //單據尚有作業中數量，無法強制結單
                return;
            }

            if (MessageBox.Show(this, RM.GetString("ConfirmCompleteMessage"), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            result = ListService.CompleteWmsInList(Data);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);
            if (result.Successed)
            {
                btn_Select_Click(null, null);
            }
        }


        private void cmbProdNo_EditValueChanged(object sender, EventArgs e)
        {
            var Row = cmbProdNo.Properties.GetDataSourceRowByDisplayValue(cmbProdNo.EditValue) as DataRowView;
            if (Row != null)
            {
                txtProdName.Text = Row["PROD_NAME"].ToString();
                txtUn.Text = Row["UN"].ToString();
            }
            else
            {
                txtProdName.Text = "";
                txtUn.Text = "";
            }
        }
    }
}
