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
    public partial class Fm_I002_1 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_I002", "FORM_IN"), System.Reflection.Assembly.GetExecutingAssembly());

        Service.PalletInService palletInService = new WMS.Service.PalletInService();
        Service.WmsListService ListService = new WMS.Service.WmsListService();

        List<Model.WmsInLine> InLines = new List<WMS.Model.WmsInLine>();
        public List<Model.WmsInLine> SelectedList = new List<WMS.Model.WmsInLine>();

        public Fm_I002_1()
        {
            InitializeComponent();
        }

        private void Fm_I002_1_Load(object sender, EventArgs e)
        {
            cmbListNo.StyleController = Program.STYLER;
            txtFilter.StyleController = Program.STYLER;
            txtPalletNo.StyleController = Program.STYLER;
            
            RefreshData("", "");
            InitialListNoCombobox();
            SelectedList = new List<WMS.Model.WmsInLine>();
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

        private void InitialListNoCombobox()
        {
            cmbListNo.Properties.DisplayMember = "LIST_NO";
            cmbListNo.Properties.ValueMember = "LIST_NO";
            cmbListNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cmbListNo.Properties.DropDownRows = 14;
            cmbListNo.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            cmbListNo.KeyUp += new KeyEventHandler(cmbStatusCtr_KeyUp);

            cmbListNo.Properties.Columns.Clear();
            cmbListNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = colLIST_NO2.Caption, FieldName = "LIST_NO", Width = 20 });
            cmbListNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = colERP_LIST_NO.Caption, FieldName = "ERP_LIST_NO", Width = 20 });
            cmbListNo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = colERP_LIST_TYPE.Caption, FieldName = "ERP_LIST_TYPE", Width = 20 });

            cmbListNo.Properties.DataSource = InLines
                .GroupBy(o => new
                {
                    LIST_NO = o.LIST_NO,
                    ERP_LIST_NO = o.ERP_LIST_NO,
                    ERP_LIST_TYPE = o.ERP_LIST_TYPE
                })
            .Select(o => new Model.WmsOutList()
            {
                LIST_NO = o.Key.LIST_NO,
                ERP_LIST_NO = o.Key.ERP_LIST_NO,
                ERP_LIST_TYPE = o.Key.ERP_LIST_TYPE
            }).ToList();

        }

        private void RefreshData(string ListNo, string FilterString)
        {
            var result = ListService.GetAvailableWmsInLine(ref InLines);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            if (!string.IsNullOrEmpty(ListNo))
                InLines = InLines.Where(o => o.LIST_NO == ListNo).ToList();

            if (!string.IsNullOrEmpty(FilterString))
            {
                InLines = InLines.Where(o => (o.PROD_NO ?? string.Empty).Contains(FilterString) ||
                    (o.LOT_NO ?? string.Empty).Contains(FilterString) ||
                    (o.ORG_NO ?? string.Empty).Contains(FilterString) ||
                    (o.SNAME ?? string.Empty).Contains(FilterString) ||
                    (o.CREATE_BY ?? string.Empty).Contains(FilterString) ||
                    (o.CREATE_NAME ?? string.Empty).Contains(FilterString) ||
                    (o.PROD_NAME ?? string.Empty).Contains(FilterString)).ToList();
            }

            var test2NotInTest1 = InLines.Where(t2 => SelectedList.Any(t1 => t2.LIST_NO == t1.LIST_NO && t2.LINE_ID == t1.LINE_ID));

            foreach (var Item in test2NotInTest1)
            {
                Item.CHK = true;
                Item.IN_QTY = SelectedList.First(o => o.LIST_NO == Item.LIST_NO && o.LINE_ID == Item.LINE_ID).IN_QTY;
            }

            gdc_WMS_IN_LINE.DataSource = InLines;
        }

        private void txtPalletNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            txtPalletNo.Text = palletInService.GenPalletNo();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                RefreshData((cmbListNo.EditValue ?? string.Empty).ToString(), txtFilter.Text.Trim());
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData((cmbListNo.EditValue ?? string.Empty).ToString(), txtFilter.Text.Trim());
        }

        private void txtFilter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            RefreshData((cmbListNo.EditValue ?? string.Empty).ToString(), txtFilter.Text.Trim());
        }

        private void gdv_WMS_IN_LINE_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "CHK")
            {
                if (e.RowHandle >= 0)
                {
                    Boolean value = (Boolean)e.Value;
                    string ListNo = gdv_WMS_IN_LINE.GetRowCellValue(e.RowHandle, "LIST_NO").ToString();
                    int LineID = Convert.ToInt16(gdv_WMS_IN_LINE.GetRowCellValue(e.RowHandle, "LINE_ID").ToString());
                    //勾選
                    if (value)
                    {
                        if (SelectedList.Count <= 0)
                        {
                            SelectedList.Add(InLines.Where(o => o.LIST_NO == ListNo && o.LINE_ID == LineID).First());
                        }
                        else
                        {
                            var Exists = SelectedList.Any(o => o.LIST_NO == ListNo && o.LINE_ID == LineID);
                            if (!Exists)
                                SelectedList.Add(InLines.Where(o => o.LIST_NO == ListNo && o.LINE_ID == LineID).First());
                        }
                    }
                    else //取消/沒有勾選
                    {
                        if (SelectedList.Count <= 0)
                        {
                            //SelectedList.Add(OutLines.Where(o => o.LIST_NO == ListNo && o.LINE_ID == LineID).First());
                        }
                        else
                        {
                            var Exists = SelectedList.Any(o => o.LIST_NO == ListNo && o.LINE_ID == LineID);
                            if (Exists)
                            {
                                var itemToRemove = SelectedList.Single(r => r.LIST_NO == ListNo && r.LINE_ID == LineID);
                                SelectedList.Remove(itemToRemove);
                            }

                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SelectedList == null)
            {
                //請先勾選要組盤的入庫單據資料	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("ListNullMsg"));
                return;
            }
            if (SelectedList.Count <= 0)
            {
                //請先勾選要組盤的入庫單據資料	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("ListNullMsg"));
                return;
            }
            if (string.IsNullOrEmpty(txtPalletNo.Text))
            {
                txtPalletNo.Focus();
                //組盤條碼不可為空值，請先輸入條碼資料	
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("PalletNoNullMsg"));
                return;
            }

            var NotAvailableList = SelectedList.Where(o => o.IN_QTY > o.QTY).FirstOrDefault();
            if (NotAvailableList != null)
            {
                //單號:{0}, 項次:{1}, 組盤數量不可>單據數量
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg001"), NotAvailableList.LIST_NO, NotAvailableList.LINE_ID));
                return;
            }

            NotAvailableList = SelectedList.Where(o => o.IN_QTY <= 0).FirstOrDefault();
            if (NotAvailableList != null)
            {
                //單號:{0}, 項次:{1}, 組盤數量不可等於0
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg002"), NotAvailableList.LIST_NO, NotAvailableList.LINE_ID));
                return;
            }

            NotAvailableList = SelectedList.Where(o => o.IN_QTY > o.AVAILABLE_QTY).FirstOrDefault();
            if (NotAvailableList != null)
            {
                //單號:{0}, 項次:{1}, 組盤數量不可>可組盤量
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg003"), NotAvailableList.LIST_NO, NotAvailableList.LINE_ID));
                return;
            }

            var PalletList = SelectedList.Select(o => new Model.CusBarcodeInfo()
            {
                PALLET_NO = txtPalletNo.Text.Trim(),
                LIST_NO = o.LIST_NO,
                LINE_ID = o.LINE_ID,
                STATUS = vPublic.BarcodeInStatus.未啟動,
                QTY = o.IN_QTY,
                UN = o.UN,
                PROD_NO = o.PROD_NO,
                PROD_NAME = o.PROD_NAME,
                ORG_NO = o.ORG_NO,
                LOT_NO = o.LOT_NO,
                PRODUCTION_DATE = o.PRODUCTION_DATE,
                REMARK = o.REMARK,
                CREATE_BY = Program.wmsUser.UserNo,
                CREATE_DATE = DateTime.Now
            }).ToList();

            var result = palletInService.CreateCusBarcodeInfo(PalletList);
            if (result.Successed)
            {
                this.DialogResult = DialogResult.Yes;
                Close();
            }
            else
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, result.Message);
                return;
            }
        }

    }
}
