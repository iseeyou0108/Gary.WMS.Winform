using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraBars;

namespace WMS
{
    public partial class Fm_B001 : Form
    {
        // 多國語言資源檔設定
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_B001", "FORM_BASIC"), System.Reflection.Assembly.GetExecutingAssembly());
        

        public class CheckResult
        {
            public bool Successed { get; set; }
            public string Message { get; set; }
        }

        public class WMS_PROD
        {
            public string PROD_NO { get; set; }
            public string PROD_NAME { get; set; }
            public string SPEC { get; set; }
            public string UN { get; set; }
            public decimal FULL_QTY { get; set; }
            public string VALID_FLG { get; set; }
            public string KIND { get; set; }
            
            public string SOURCE_CODE { get; set; }
            public string SOURCE_CODE_DESC { get; set; }
            public string REMARK { get; set; }
            public DateTime CREATE_DATE { get; set; }
            public string CREATE_BY { get; set; }
            public string CREATE_NAME { get; set; }
            public DateTime UPDATE_DATE { get; set; }
            public string UPDATE_BY { get; set; }
            public string UPDATE_NAME { get; set; }

            public WMS_PROD()
            {
                CREATE_DATE = DateTime.Now;
                UPDATE_DATE = DateTime.Now;
                CREATE_BY = Program.wmsUser.UserNo;
            }

            public CheckResult CheckAddExist()
            {
                CheckResult result = new CheckResult() { Successed = true, Message = "" };

                var ExecResult = vPublic.GetDbData("select count(1) cnt from WMS_PROD where PROD_NO = @PROD_NO ", new List<vPublic.DBParameter>() { new vPublic.DBParameter() { ParameterName = "PROD_NO", Value = PROD_NO } });

                if (ExecResult.Successed == false)
                {
                    result.Successed = false;
                    result.Message = ExecResult.Message;
                    return result;
                }

                if (int.Parse(ExecResult.ResultDt.Rows[0]["cnt"].ToString()) > 0)
                {
                    result.Successed = false;
                    result.Message = "Exist";
                }

                return result;
            }
        }



        List<WMS_PROD> WmsPords { get; set; }

        public Fm_B001()
        {
            InitializeComponent();
        }

        private void Fm_B003_Load(object sender, EventArgs e)
        {
            UI_SET();

            WmsPords = new List<WMS_PROD>();

            SET_PRIV();

            vPublic.RestoreViewLayoutByStream(gdv_WMS_PROD, this.Name, 1, true);
        }

        private void UI_SET()
        {
            #region INPUT元件屬性設定

            

            #endregion

            #region INPUT元件樣式設定

            txtFilter.StyleController = Program.STYLER;

            #endregion

            #region 快速鍵



            #endregion

            #region 按鈕圖案

            Bitmap bitmap;
            int b_height;

           


            #endregion
        }

        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);

            btn_Insert.Visible = FormPriv.Add;
            colEdit.Visible = FormPriv.Edit;
            colDelete.Visible = FormPriv.Delete;
        }

        

        private void RefreshData(string SearchText)
        {
            string strSql = string.Empty;

            DataTable dt = new DataTable();

            strSql = "select a.*, " +
                     "       case when a.SOURCE_CODE = 0 then 'WMS' when a.SOURCE_CODE = 1 then 'ERP' end SOURCE_CODE_DESC, " +
                     "       b.USER_NAME as CREATE_NAME, c.USER_NAME as UPDATE_NAME " +
                     "from WMS_PROD a " +
                     " left join HRS_USER b on a.CREATE_BY = b.USER_NO " +
                     " left join HRS_USER c on a.UPDATE_BY = c.USER_NO " +
                     "order by a.PROD_NO ";

            var result = vPublic.GetDbData(strSql, new List<vPublic.DBParameter>());

            if (result.Successed == false)
            {
                MessageBox.Show(this, result.Message, RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dt = result.ResultDt;
            if (!string.IsNullOrEmpty(SearchText))
            {
                var dtResult = dt.AsEnumerable()
                    .Where(i => i.Field<string>("PROD_NO").Contains(SearchText) ||
                                i.Field<string>("PROD_NAME").Contains(SearchText) ||
                                i.Field<string>("SPEC").Contains(SearchText) ||
                                i.Field<string>("UN").Contains(SearchText) ||
                                i.Field<string>("KIND").Contains(SearchText) ||
                                i.Field<string>("REMARK").Contains(SearchText));

                if (dtResult != null)
                {
                    if (dtResult.Count() > 0)
                    {
                        DataTable dtSearch = dtResult.CopyToDataTable();
                        gdc_WMS_PROD.DataSource = dtSearch;
                        SetDataList(dtSearch);
                    }
                    else
                        gdc_WMS_PROD.DataSource = null;
                }
                else
                    gdc_WMS_PROD.DataSource = null;

            }
            else
            {
                gdc_WMS_PROD.DataSource = dt;
                SetDataList(dt);
            }

            gdv_WMS_PROD.BestFitMaxRowCount = 100;
            gdv_WMS_PROD.BestFitColumns();
        }

        private void SetDataList(DataTable dt)
        {
            WmsPords = new List<WMS_PROD>();
            foreach (DataRow dr in dt.Rows)
            {
                WMS_PROD WmsOrg = new WMS_PROD()
                {
                    PROD_NO = dr["PROD_NO"].ToString(),
                    SPEC = dr["SPEC"].ToString(),
                    PROD_NAME = dr["PROD_NAME"].ToString(),
                    FULL_QTY = decimal.Parse(dr["FULL_QTY"].ToString()),
                    VALID_FLG = dr["VALID_FLG"].ToString(),
                    UN = dr["UN"].ToString(),
                    KIND = dr["KIND"].ToString(),
                    REMARK = dr["REMARK"].ToString(),
                    UPDATE_DATE = DateTime.Now,
                    UPDATE_BY = Program.wmsUser.UserNo
                };

                WmsPords.Add(WmsOrg);
            }
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshData(txtFilter.Text.Trim());
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshData(txtFilter.Text.Trim());
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Fm_B001_1 objForm = new Fm_B001_1();

            objForm.SetText(RM.GetString("AddDialogTitle"));    //新增客戶基本資料
            objForm.SetEditMode(vPublic.EditMode.Add);
            objForm.SetModal(new WMS_PROD(), WmsPords);
            objForm.ShowDialog();

            RefreshData(txtFilter.Text);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (gdc_WMS_PROD.DataSource == null) return;
            if (gdv_WMS_PROD.RowCount <= 0) return;
            if (!gdv_WMS_PROD.IsValidRowHandle(gdv_WMS_PROD.FocusedRowHandle)) return;
            if (gdv_WMS_PROD.IsFilterRow(gdv_WMS_PROD.FocusedRowHandle)) return;

            
        }

        

        private CheckResult DeleteCheck(WMS_PROD WmsOrg)
        {
            string strSql = string.Empty;
            DataTable dt = new DataTable();
            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
                var Cmd = Conn.CreateCommand();
                Cmd.CommandText = "select count(1) CNT from WMS_STK where ORG_NO = @ORG_NO ";
                Cmd.Parameters.AddWithValue("ORG_NO", WmsOrg.PROD_NO);
                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(dt);

                if (int.Parse(dt.Rows[0]["CNT"].ToString()) > 0)
                {
                    //客戶代號: {0}已被使用於庫存中，無法刪除。
                    return new CheckResult() { Successed = false, Message = string.Format(RM.GetString("S0006"), WmsOrg.PROD_NO) };
                }

                dt.Clear();

                Cmd.Parameters.Clear();
                Cmd.CommandText = "select count(1) CNT from WCS_TRK_DET where ORG_NO = @ORG_NO ";
                Cmd.Parameters.AddWithValue("ORG_NO", WmsOrg.PROD_NO);
                dap = new SqlDataAdapter(Cmd);
                dap.Fill(dt);

                if (int.Parse(dt.Rows[0]["CNT"].ToString()) > 0)
                {
                    //客戶代號: {0}已被使用於庫存中，無法刪除。
                    return new CheckResult() { Successed = false, Message = string.Format(RM.GetString("S0007"), WmsOrg.PROD_NO) };
                }

                dap.Dispose();
                Cmd.Dispose();
            }
            catch (SqlException ex)
            {
                return new CheckResult() { Successed = false, Message = ex.Message };
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();

                Conn.Dispose();
            }

            return new CheckResult() { Successed = true, Message = "" };
        }

        private void txtFilter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            RefreshData(txtFilter.Text.Trim());
        }

        private void repositoryItemButtonEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            WMS_PROD DeleteModel = new WMS_PROD()
            {
                PROD_NO = gdv_WMS_PROD.GetFocusedRowCellValue("PROD_NO").ToString(),
                SPEC = gdv_WMS_PROD.GetFocusedRowCellValue("SPEC").ToString(),
                PROD_NAME = gdv_WMS_PROD.GetFocusedRowCellValue("PROD_NAME").ToString(),

                FULL_QTY = Convert.ToDecimal(gdv_WMS_PROD.GetFocusedRowCellValue("FULL_QTY").ToString()),
                VALID_FLG = gdv_WMS_PROD.GetFocusedRowCellValue("VALID_FLG").ToString(),
                UN = gdv_WMS_PROD.GetFocusedRowCellValue("UN").ToString(),
                KIND = gdv_WMS_PROD.GetFocusedRowCellValue("KIND").ToString(),
                REMARK = gdv_WMS_PROD.GetFocusedRowCellValue("REMARK").ToString(),
                UPDATE_DATE = DateTime.Now,
                UPDATE_BY = Program.wmsUser.UserNo
            };

            var checkResult = DeleteCheck(DeleteModel);
            if (!checkResult.Successed)
            {
                MessageBox.Show(this, checkResult.Message, RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ConfirmMessage = string.Empty;
            //確定要刪除選取的客戶基本檔資料?{0}客戶代號:{1}({2})
            ConfirmMessage = string.Format(RM.GetString("DeleteConfirmMessage"), Environment.NewLine, DeleteModel.PROD_NO, DeleteModel.PROD_NAME);

            if (MessageBox.Show(this, ConfirmMessage, RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlTransaction trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var Cmd = Conn.CreateCommand();
                    Cmd.Transaction = trans;

                    Cmd.CommandText = "delete WMS_PROD where PROD_NO = @PROD_NO ";
                    Cmd.Parameters.AddWithValue("PROD_NO", DeleteModel.PROD_NO);
                    int rtn = Cmd.ExecuteNonQuery();

                    string ErrorMessage = string.Empty;
                    //刪除客戶基本檔資料-客戶代號:{0}({1})
                    bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(RM.GetString("DeleteLog"), DeleteModel.PROD_NO, DeleteModel.PROD_NAME), this.Name, ref ErrorMessage);
                    if (!LogResult)
                        throw new Exception(ErrorMessage);

                    trans.Commit();
                    Cmd.Dispose();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(this, ex.Message, RM.GetString("MsgTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            RefreshData(txtFilter.Text.Trim());
        }

        private void repositoryItemButtonEdit_Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            WMS_PROD EditModal = new WMS_PROD()
            {
                PROD_NO = gdv_WMS_PROD.GetFocusedRowCellValue("PROD_NO").ToString(),
                SPEC = gdv_WMS_PROD.GetFocusedRowCellValue("SPEC").ToString(),
                PROD_NAME = gdv_WMS_PROD.GetFocusedRowCellValue("PROD_NAME").ToString(),
                FULL_QTY = Convert.ToDecimal(gdv_WMS_PROD.GetFocusedRowCellValue("FULL_QTY").ToString()),
                VALID_FLG = gdv_WMS_PROD.GetFocusedRowCellValue("VALID_FLG").ToString(),
                UN = gdv_WMS_PROD.GetFocusedRowCellValue("UN").ToString(),
                KIND = gdv_WMS_PROD.GetFocusedRowCellValue("KIND").ToString(),
                REMARK = gdv_WMS_PROD.GetFocusedRowCellValue("REMARK").ToString(),
                UPDATE_DATE = DateTime.Now,
                UPDATE_BY = Program.wmsUser.UserNo
            };

            Fm_B001_1 objForm = new Fm_B001_1();

            objForm.SetText(RM.GetString("EditDialogTitle"));    //新增客戶基本資料
            objForm.SetEditMode(vPublic.EditMode.Update);
            objForm.SetModal(EditModal, WmsPords);
            objForm.ShowDialog();

            RefreshData(txtFilter.Text);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            colEdit.Visible = false;
            colDelete.Visible = false;

            gdc_WMS_PROD.ShowPrintPreview();

            colEdit.Visible = true;
            colDelete.Visible = true;
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);

            try
            {
                Conn.Open();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var Cmd = Conn.CreateCommand();

                Cmd.CommandText = @"CREATE TABLE SysSetting  
                                    (  
                                     SYS_TYPE   varchar (20) not null,  
                                     SYS_VALUE  varchar (20) not null,  
                                     SYS_DESC 	varchar (max) not null
                                    ) ";

                Cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
 
            }

        }

        private void btnColumnSet_Click(object sender, EventArgs e)
        {

            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>()
            {
                colEdit,
                colDelete
            };

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WMS_PROD.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WMS_PROD, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WMS_PROD, this.Name, 1,false);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = string.Format("{0}_{1}", RM.GetString("ExcellFilename"), DateTime.Now.ToString("yyyyMMddHHmmss"));
            sfd.Filter = "Excel |*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                gdv_WMS_PROD.ExportToXlsx(sfd.FileName);
            }
        }

    }
}
