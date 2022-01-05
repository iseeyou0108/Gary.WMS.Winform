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
    public partial class Fm_Q002 : Form
    {
        Service.WmsBinstaService service = new WMS.Service.WmsBinstaService();

        public class BinStaCell
        {
            public string AREA_NO { get; set; }
            public string WH_NO { get; set; }
            public int ASRS_ID { get; set; }
            public string BIN_NO { get; set; }
            public int RowNo { get; set; }
            public int BayNo { get; set; }
            public int LevelNo { get; set; }
            public string BinSta { get; set; }
            public bool Forbidden { get; set; }
        }

        int _MaxLevelNo = 0;

        public List<BinStaCell> Cells { get; set; }
        
        public Fm_Q002()
        {
            InitializeComponent();
            vPublic.GetAsrsIDItems(cmbAsrsID);
            cmbAsrsID.StyleController = Program.STYLER;
            PaintBinStaCell(Convert.ToInt16(cmbAsrsID.EditValue), Convert.ToInt16(cmbRow.Text));
        }

        private void Fm_Q002_Load(object sender, EventArgs e)
        {

        }

        private void PaintBinStaCell(int AsrsID, int RowNo)
        {
            DataTable dt = new DataTable();
            gdvData.OptionsView.ColumnAutoWidth = false;
            

            List<Model.WmsBinSta> Binstas = new List<WMS.Model.WmsBinSta>();
            var result = service.GetAllWmsBinstaList(vPublic.AsrsDefine.AREA_NO, vPublic.AsrsDefine.WH_NO, AsrsID, ref Binstas);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            gdvData.Columns.Clear();
            
            Cells = new List<BinStaCell>();

            Cells = Binstas
                .Where(o => o.AREA_NO == vPublic.AsrsDefine.AREA_NO &&
                    o.WH_NO == vPublic.AsrsDefine.WH_NO &&
                    o.ASRS_ID == AsrsID &&
                    o.ROW_NO == RowNo
                    )
                .Select(o => new BinStaCell()
                {
                    AREA_NO = o.AREA_NO,
                    WH_NO= o.WH_NO,
                    ASRS_ID = (int)o.ASRS_ID,
                    BIN_NO = o.BIN_NO,
                    BayNo = (int)o.BAY_NO,
                    RowNo = (int)o.ROW_NO,
                    LevelNo = (int)o.LEVEL_NO,
                    BinSta = o.BIN_STA == "$" ? (o.PROD_TYPE == WMS.Model.WmsStk.ProdType.載具 ? "B" : "$") : o.BIN_STA,
                    Forbidden = (o.INHIBIT_IN_FLG == "Y" || o.INHIBIT_OUT_FLG == "Y")
                }).ToList();

            var MaxBayNo = Cells.Max(o => o.BayNo);
            var MaxLevelNo = Cells.Max(o => o.LevelNo);
            _MaxLevelNo = MaxLevelNo;
            
            for (int i = 0; i < MaxBayNo; i++)
            {
                var Col = new DevExpress.XtraGrid.Columns.GridColumn();

                Col.Caption = (i + 1).ToString();
                Col.FieldName = string.Format("Bay{0:000}Sta", i + 1);
                Col.Visible = true;
                Col.VisibleIndex = i;
                Col.Width = 30;
                Col.MinWidth = 30;
                Col.OptionsColumn.AllowEdit = false;
                Col.OptionsColumn.ReadOnly = true;
                Col.OptionsColumn.AllowMove = false;
                Col.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
                Col.OptionsFilter.AllowFilter = false;
                gdvData.Columns.Add(Col);

                dt.Columns.Add(string.Format("Bay{0:000}Sta", i + 1), typeof(string));
            }
            int LevelNo = MaxLevelNo;
            while (LevelNo > 0)
            {
                DataRow dr = dt.NewRow();

                for (int BayNo = 1; BayNo <= MaxBayNo; BayNo++)
                {
                    dr[string.Format("Bay{0:000}Sta", BayNo)] = Cells.Where(o => o.RowNo == RowNo && o.BayNo == BayNo && o.LevelNo == LevelNo).First().BIN_NO;
                }
                
                dt.Rows.Add(dr);
                LevelNo--;
            }

            gdcData.DataSource = dt;
        }

        private void gdvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            Bitmap objImg = null;
            Bitmap objDisa = null;

            if ((e.CellValue) != null)
            {
                var CellItem = Cells.Where(o => o.BIN_NO == e.CellValue).First();

                switch (CellItem.BinSta)
                {
                    case "_":
                        objImg = (Bitmap)navBarItem_EmptyBin.SmallImage;
                        break;
                    case "$":
                        objImg = (Bitmap)navBarItem_stk.SmallImage;
                        break;
                    case "B":
                        objImg = (Bitmap)navBarItem_palet.SmallImage;
                        break;
                    case "P":
                        objImg = (Bitmap)navBarItem_Unknown.SmallImage;
                        break;
                    case "I":
                        objImg = (Bitmap)navBarItem_In.SmallImage;
                        break;
                    case "O":
                        objImg = (Bitmap)navBarItem_Out.SmallImage;
                        break;
                    case "X":
                        objImg = (Bitmap)navBarItem_Forbidden_X.SmallImage;
                        break;
                    default:
                        objImg = (Bitmap)navBarItem_Forbidden_X.SmallImage;
                        break;
                }

                if(CellItem.Forbidden)
                    objDisa = (Bitmap)navBarItem_Forbidden.SmallImage;

                if (objImg != null) //imageIndex < imgBINSTA.Images.Count)
                {
                    Rectangle lnw = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);

                    System.Drawing.Imaging.ImageAttributes attr = new System.Drawing.Imaging.ImageAttributes();
                    attr.SetColorKey(objImg.GetPixel(0, 0), objImg.GetPixel(0, 0));

                    e.Graphics.DrawImage(objImg, e.Bounds);

                    if (objDisa != null) //显示禁用图标
                    {
                        e.Graphics.DrawImage(objDisa, lnw, 0, 0, objDisa.Width, objDisa.Height, GraphicsUnit.Pixel, attr);
                    }
                }
                if (this.gdvData.IsCellSelected(e.RowHandle, e.Column))
                {
                    Color newcolor = Color.Black;

                    Pen mypen = new Pen(newcolor);
                    mypen.Width = 3;
                    e.Graphics.DrawRectangle(mypen, e.Bounds);
                }

                e.Handled = true;
            }

            
        }

        private void cmbRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PaintBinStaCell(Convert.ToInt16(cmbAsrsID.EditValue), Convert.ToInt16(cmbRow.Text));
            Cursor.Current = Cursors.Default;
        }

        private void gdvData_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            gdvData.ViewCaption = e.CellValue.ToString();

            Model.WmsStk StkService = new WMS.Model.WmsStk();
            List<Model.WmsStk> Stks = new List<WMS.Model.WmsStk>();
            var result = StkService.GetAllWmsStk((int)cmbAsrsID.EditValue, ref Stks);
            if (result.Successed == false)
            {
                gdc_WMS_STK.DataSource = null;
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }
            else
            {
                Stks = Stks.Where(o => o.BIN_NO == gdvData.ViewCaption).ToList();
                gdc_WMS_STK.DataSource = Stks;
            }
        }

        private void gdvData_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator) return;

            string LevelNo = Math.Abs(e.RowHandle - _MaxLevelNo).ToString();
            e.Info.DisplayText = LevelNo;
        }

        private void gdvData_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            e.Info.DisplayText = e.Handled.ToString();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            PaintBinStaCell(Convert.ToInt16(cmbAsrsID.EditValue), Convert.ToInt16(cmbRow.Text));
            Cursor.Current = Cursors.Default;
        }

        /// <summary>
        /// 禁用/解禁用設定
        /// </summary>
        /// <param name="Lock">true=禁用, false=解禁</param>
        private void LockSetting(bool Lock)
        {
            if (gdvData.GetSelectedCells().Count() <= 0) return;

            var SelectedCells = gdvData.GetSelectedCells().ToList();

            var BinNos = SelectedCells.Select(cell => gdvData.GetRowCellValue(cell.RowHandle, cell.Column).ToString()).ToList();

            var EditCells = Cells.Where(o => BinNos.Any(l => l.Contains(o.BIN_NO))).ToList();

            var result = service.SubmitDisableSettings(EditCells, Lock);
            vPublic.ShowAlert(result.Successed == false ? Fm_Alert.AlertType.Error : Fm_Alert.AlertType.Successful
                              , result.Message);

            if (result.Successed)
            {
                btn_Select.PerformClick();
            }
        }

        private void navBarItem_Lock_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LockSetting(true);
        }

        private void navBarItem_UnLock_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LockSetting(false);
        }

        private void btnPlus1F_Click(object sender, EventArgs e)
        {
            gdvData.RowHeight = gdvData.RowHeight + 2;
            foreach (DevExpress.XtraGrid.Columns.GridColumn colTmp in gdvData.Columns)
            {
                colTmp.Width = colTmp.Width + 2;
            }
        }

        private void btnMinus1F_Click(object sender, EventArgs e)
        {
            gdvData.RowHeight = gdvData.RowHeight - 2;
            foreach (DevExpress.XtraGrid.Columns.GridColumn colTmp in gdvData.Columns)
            {
                colTmp.Width = colTmp.Width - 2;
            }
        }


    }
}
