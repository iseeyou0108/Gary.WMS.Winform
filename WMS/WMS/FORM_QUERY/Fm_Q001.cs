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
    public partial class Fm_Q001 : Form
    {
        class Q001Model
        {
            public string WH_NO { get; set; }
            public decimal ASRS_ID { get; set; }
            public decimal CRN_ID { get; set; }
            public int BIN_CNT { get; set; }
            public int I_CNT { get; set; }
            public int IX_CNT { get; set; }
            public int O_CNT { get; set; }
            public int OX_CNT { get; set; }
            public int E_CNT { get; set; }
            public int B_CNT { get; set; }
            public int S_CNT { get; set; }
            public double USAGE_RATE { get; set; }
        }

        public Fm_Q001()
        {
            InitializeComponent();
        }

        private void Fm_Q001_Load(object sender, EventArgs e)
        {
            vPublic.RestoreViewLayoutByStream(gdv_WMS_BINSTA, this.Name, 1, true);
            RefreshData();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var result = vPublic.GetDbData("select a.WH_NO, a.ASRS_ID, a.CRN_ID, a.BIN_NO, a.BIN_STA, a.INHIBIT_IN_FLG, a.INHIBIT_OUT_FLG "+
                                           "from WMS_BINSTA a where a.WH_NO = 'A' ", new List<vPublic.DBParameter>());
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            var GroupList = from t in result.ResultDt.AsEnumerable()
                            group t by new
                            {
                                WH_NO = t.Field<string>("WH_NO"),
                                ASRS_ID = t.Field<decimal>("ASRS_ID"),
                                CRN_ID = t.Field<decimal>("CRN_ID")
                            } into m
                            select new
                            {
                                WH_NO = m.Key.WH_NO,
                                ASRS_ID = m.Key.ASRS_ID,
                                CRN_ID = m.Key.CRN_ID,
                                BIN_CTN = m.Count()
                            };

            var UsageRateList = GroupList.Select(i => new Q001Model()
            {
                WH_NO = i.WH_NO,
                ASRS_ID = i.ASRS_ID,
                CRN_ID = i.CRN_ID,
                BIN_CNT = i.BIN_CTN,
                B_CNT = 0,
                E_CNT = 0,
                I_CNT = 0,
                IX_CNT = 0,
                O_CNT = 0,
                OX_CNT = 0,
                S_CNT = 0,
                USAGE_RATE = 0
            }).ToList();

            foreach (var Item in UsageRateList)
            {
                //庫存庫位數
                Item.S_CNT = result.ResultDt.AsEnumerable()
                    .Where(o => o.Field<string>("WH_NO") == Item.WH_NO &&
                        o.Field<decimal>("ASRS_ID") == Item.ASRS_ID &&
                        o.Field<decimal>("CRN_ID") == Item.CRN_ID &&
                        o.Field<string>("BIN_STA") == "$"
                    ).Count();

                //空庫位數
                Item.E_CNT = result.ResultDt.AsEnumerable()
                    .Where(o => o.Field<string>("WH_NO") == Item.WH_NO &&
                        o.Field<decimal>("ASRS_ID") == Item.ASRS_ID &&
                        o.Field<decimal>("CRN_ID") == Item.CRN_ID &&
                        o.Field<string>("BIN_STA") == "_"
                    ).Count();

                //空棧板庫位數
                Item.B_CNT = result.ResultDt.AsEnumerable()
                    .Where(o => o.Field<string>("WH_NO") == Item.WH_NO &&
                        o.Field<decimal>("ASRS_ID") == Item.ASRS_ID &&
                        o.Field<decimal>("CRN_ID") == Item.CRN_ID &&
                        o.Field<string>("BIN_STA") == "B"
                    ).Count();

                //入庫中
                Item.I_CNT = result.ResultDt.AsEnumerable()
                    .Where(o => o.Field<string>("WH_NO") == Item.WH_NO &&
                        o.Field<decimal>("ASRS_ID") == Item.ASRS_ID &&
                        o.Field<decimal>("CRN_ID") == Item.CRN_ID &&
                        o.Field<string>("BIN_STA") == "I"
                    ).Count();

                //出庫中
                Item.O_CNT = result.ResultDt.AsEnumerable()
                    .Where(o => o.Field<string>("WH_NO") == Item.WH_NO &&
                        o.Field<decimal>("ASRS_ID") == Item.ASRS_ID &&
                        o.Field<decimal>("CRN_ID") == Item.CRN_ID &&
                        o.Field<string>("BIN_STA") == "O"
                    ).Count();

                //入庫禁用
                Item.IX_CNT = result.ResultDt.AsEnumerable()
                    .Where(o => o.Field<string>("WH_NO") == Item.WH_NO &&
                        o.Field<decimal>("ASRS_ID") == Item.ASRS_ID &&
                        o.Field<decimal>("CRN_ID") == Item.CRN_ID &&
                        o.Field<string>("INHIBIT_IN_FLG") == "Y"
                    ).Count();

                //出庫禁用
                Item.OX_CNT = result.ResultDt.AsEnumerable()
                    .Where(o => o.Field<string>("WH_NO") == Item.WH_NO &&
                        o.Field<decimal>("ASRS_ID") == Item.ASRS_ID &&
                        o.Field<decimal>("CRN_ID") == Item.CRN_ID &&
                        o.Field<string>("INHIBIT_OUT_FLG") == "Y"
                    ).Count();

                //使用率
                Item.USAGE_RATE = Math.Round((double)(Item.S_CNT + Item.B_CNT + Item.I_CNT + Item.IX_CNT + Item.O_CNT + Item.OX_CNT) / Item.BIN_CNT, 2) * 100;
            }

            gdc_WMS_BINSTA.DataSource = UsageRateList;
        }

        private void gdv_WMS_BINSTA_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            if ((e.Item as DevExpress.XtraGrid.GridColumnSummaryItem).FieldName == "USAGE_RATE")
            {
                int S_CNT = Convert.ToInt32(gdv_WMS_BINSTA.Columns["S_CNT"].SummaryItem.SummaryValue.ToString());
                int B_CNT = Convert.ToInt32(gdv_WMS_BINSTA.Columns["B_CNT"].SummaryItem.SummaryValue.ToString());
                int I_CNT = Convert.ToInt32(gdv_WMS_BINSTA.Columns["I_CNT"].SummaryItem.SummaryValue.ToString());
                int IX_CNT = Convert.ToInt32(gdv_WMS_BINSTA.Columns["IX_CNT"].SummaryItem.SummaryValue.ToString());
                int O_CNT = Convert.ToInt32(gdv_WMS_BINSTA.Columns["O_CNT"].SummaryItem.SummaryValue.ToString());
                int OX_CNT = Convert.ToInt32(gdv_WMS_BINSTA.Columns["OX_CNT"].SummaryItem.SummaryValue.ToString());
                int BIN_CNT = Convert.ToInt32(gdv_WMS_BINSTA.Columns["BIN_CNT"].SummaryItem.SummaryValue.ToString());
                e.TotalValue = string.Format("{0}%", Math.Round((double)(S_CNT + B_CNT + I_CNT + IX_CNT + O_CNT + OX_CNT) / BIN_CNT, 2) * 100);
            }
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            gdc_WMS_BINSTA.ShowPrintPreview();
        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>();

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_BINSTA.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_BINSTA, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_BINSTA, this.Name, 1, false);
            }
        }


    }
}
