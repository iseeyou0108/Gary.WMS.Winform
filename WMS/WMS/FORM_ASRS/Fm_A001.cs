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
    public partial class Fm_A001 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_A001", "FORM_ASRS"), System.Reflection.Assembly.GetExecutingAssembly());
        DataTable dtDetails = new DataTable();
        Model.WcsTrk CurWcsTrk = new WMS.Model.WcsTrk();

        public class TrkButton
        {
            /// <summary>
            /// 按鈕
            /// </summary>
            public Button btn { get; set; }
            /// <summary>
            /// 多選
            /// </summary>
            public bool MultipleSelect { get; set; }
            /// <summary>
            /// 顯示提示訊息
            /// </summary>
            public bool ShowConfirmMessage { get; set; }
        }

        List<TrkButton> trkButtons = new List<TrkButton>();
        Timer tmrAutoRefresh = new Timer();
        public Fm_A001()
        {
            InitializeComponent();
        }

        private void Fm_A001_Load(object sender, EventArgs e)
        {
            vPublic.GetAsrsIDItems(cmbAsrsID);
            vPublic.GetCrnItems(cmbCrnID);
            vPublic.GetEmergeItems(cmbEmerge);

            cmbAsrsID.StyleController = Program.STYLER;
            cmbCrnID.StyleController = Program.STYLER;
            txtFilter.StyleController = Program.STYLER;

            #region 註冊按鈕的工作檔操作類型

            btnCancel.Tag = Model.WcsTrk.TrkStep.Step0;     //強制取消
            btnComplete.Tag = Model.WcsTrk.TrkStep.Step91;  //強制完成
            btnEmptyOut.Tag = Model.WcsTrk.TrkStep.Step81;  //空出庫
            btnPreload.Tag = Model.WcsTrk.TrkStep.Step82;   //先入品
            btnPutok.Tag = Model.WcsTrk.TrkStep.Step30;     //置物完成
            btnRedo.Tag = Model.WcsTrk.TrkStep.Step83;      //吊車續行
            btnEmerge.Tag = Model.WcsTrk.TrkStep.Step999;   //緊急程度調整
            
            //btnCancel.Click += new EventHandler(btnTrkProcess_Click);
            //btnComplete.Click += new EventHandler(btnTrkProcess_Click);
            //btnEmptyOut.Click += new EventHandler(btnTrkProcess_Click);
            //btnPreload.Click += new EventHandler(btnTrkProcess_Click);
            //btnPutok.Click += new EventHandler(btnTrkProcess_Click);
            //btnRedo.Click += new EventHandler(btnTrkProcess_Click);
            //btnEmerge.Click += new EventHandler(btnTrkProcess_Click);

            trkButtons.Add(new TrkButton() { btn = btnCancel, MultipleSelect = true, ShowConfirmMessage = true });
            trkButtons.Add(new TrkButton() { btn = btnComplete, MultipleSelect = true, ShowConfirmMessage = true });
            trkButtons.Add(new TrkButton() { btn = btnEmptyOut, MultipleSelect = false, ShowConfirmMessage = true });
            trkButtons.Add(new TrkButton() { btn = btnPreload, MultipleSelect = false, ShowConfirmMessage = true });
            trkButtons.Add(new TrkButton() { btn = btnPutok, MultipleSelect = false, ShowConfirmMessage = true });
            trkButtons.Add(new TrkButton() { btn = btnRedo, MultipleSelect = false, ShowConfirmMessage = true });
            trkButtons.Add(new TrkButton() { btn = btnEmerge, MultipleSelect = false, ShowConfirmMessage = false });
            
            #endregion

            #region 註冊Timer

            tmrAutoRefresh.Interval = 3000;
            tmrAutoRefresh.Tick += new EventHandler(tmrAutoRefresh_Tick);
            tmrAutoRefresh.Enabled = true;
            #endregion

            SET_PRIV();

            vPublic.RestoreViewLayoutByStream(gdv_WCS_TRK, this.Name, 1, true);

            RefreshWcsTrk();
        }

        void tmrAutoRefresh_Tick(object sender, EventArgs e)
        {
            if (chkAutoRefresh.Checked)
                RefreshWcsTrk();
        }


        private void SET_PRIV()
        {
            var FormPriv = vPublic.GetFormPriv(this.Name);

            btnCancel.Visible = FormPriv.Exec;
            btnComplete.Visible = FormPriv.Exec;
            btnEmerge.Visible = FormPriv.Exec;
            btnEmptyOut.Visible = FormPriv.Exec;
            btnPreload.Visible = FormPriv.Exec;
            btnPutok.Visible = FormPriv.Exec;
        }

        /// <summary>
        /// 更新工作檔資料
        /// </summary>
        private void RefreshWcsTrk()
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult();
            string strSql = string.Empty;
            string strSqlWhere = string.Empty;
            DataTable dt = new DataTable();
            string SearchText = txtFilter.Text.Trim();
            List<vPublic.DBParameter> paeameters = new List<vPublic.DBParameter>();

            strSql = "select a.SER_NO, a.AREA_NO, a.WH_NO, a.ASRS_ID, a.BIN_NO, a.SD, a.DEV_NO, a.NEXT_DEV_NO, "+
                     "       a.TRANS_DEV_NO, a.CUR_DEV_NO, a.IO, f.IO_DESC, a.STEP, b.STEP_DESC, a.STATUS, c.STATUS_DESC, a.OPN, d.OPN_DESC,"+
                     "       a.USE_CRN_ID, a.EMERGE, a.WEIGHT, a.START_TIME, a.STEP_TIME, a.PALLET_NO, a.CREATE_DATE, a.CREATE_BY, "+
                     "       e.USER_NAME as CREATE_NAME, a.SHF_NO, a.SHF_SD, 'N' as CHK  "+
                     "from WCS_TRK a "+
                     "left join WCS_TRK_STEP_REF_VW b on a.STEP = b.STEP and b.LANG_ID = @LANG_ID "+
                     "left join WCS_TRK_STATUS_REF_VW c on a.STATUS = c.STATUS and c.LANG_ID = @LANG_ID " +
                     "left join WCS_TRK_OPN_REF_VW d on a.OPN = d.OPN and d.LANG_ID = @LANG_ID " +
                     "left join HRS_USER e on a.CREATE_BY = e.USER_NO " +
                     "left join WCS_TRK_IO_REF_VW f on a.IO = f.IO and f.LANG_ID = @LANG_ID " +
                     "where 1 = 1 {0} " +
                     "order by a.SER_NO ";

            paeameters.Add(new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) });
            if (cmbAsrsID.EditValue != null)
            {
                if (Convert.ToInt16(cmbAsrsID.EditValue) > 0)
                {
                    strSqlWhere += "and a.ASRS_ID = @ASRS_ID ";
                    paeameters.Add(new vPublic.DBParameter() { ParameterName = "ASRS_ID", Value = Convert.ToInt16(cmbAsrsID.EditValue) });
                }
            }
            if (cmbCrnID.EditValue != null)
            {
                if (Convert.ToInt16(cmbCrnID.EditValue) > 0)
                {
                    strSqlWhere += "and a.USE_CRN_ID = @USE_CRN_ID ";
                    paeameters.Add(new vPublic.DBParameter() { ParameterName = "USE_CRN_ID", Value = Convert.ToInt16(cmbCrnID.EditValue) });
                }
            }
            result = vPublic.GetDbData(string.Format(strSql, strSqlWhere), paeameters);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

           dt = result.ResultDt;
           if (!string.IsNullOrEmpty(SearchText))
           {
               var dtResult = dt.AsEnumerable()
                   .Where(i => i.Field<string>("STEP_DESC").Contains(SearchText) ||
                               i.Field<string>("STATUS_DESC").Contains(SearchText) ||
                               i.Field<string>("IO_DESC").Contains(SearchText) ||
                               i.Field<string>("DEV_NO").Contains(SearchText) ||
                               i.Field<string>("OPN_DESC").Contains(SearchText) );

               if (dtResult != null)
               {
                   if (dtResult.Count() > 0)
                   {
                       DataTable dtSearch = dtResult.CopyToDataTable();
                       gdc_WCS_TRK.DataSource = dtSearch;
                   }
                   else
                       gdc_WCS_TRK.DataSource = null;
               }
               else
                   gdc_WCS_TRK.DataSource = null;

           }
           else
           {
               gdc_WCS_TRK.DataSource = dt;
           }


           RefreshWcsTrkDetail();

           gdv_WCS_TRK_FocusedRowChanged(null, null);
        }
        /// <summary>
        /// 更新工作檔明細資料
        /// </summary>
        private void RefreshWcsTrkDetail()
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult();
            string strSql = string.Empty;
            string strSqlWhere = string.Empty;
            List<vPublic.DBParameter> paeameters = new List<vPublic.DBParameter>();

            strSql = "select a.*, isnull(b.PROD_NAME, a.PROD_NO ) PROD_NAME " +
                     "from WCS_TRK_DET a " +
                     "left join WMS_PROD b on a.PROD_NO = b.PROD_NO " +
                     "where 1 = 1 {0} " +
                     "order by a.SER_NO, a.TRK_COUNT ";

            paeameters.Add(new vPublic.DBParameter() { ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) });
            if (cmbAsrsID.EditValue != null)
            {
                if (Convert.ToInt16(cmbAsrsID.EditValue) > 0)
                {
                    strSqlWhere += "and a.ASRS_ID = @ASRS_ID ";
                    paeameters.Add(new vPublic.DBParameter() { ParameterName = "ASRS_ID", Value = Convert.ToInt16(cmbAsrsID.EditValue) });
                }
            }
            result = vPublic.GetDbData(string.Format(strSql, strSqlWhere), paeameters);
            if (result.Successed == false)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, result.Message);
                return;
            }

            dtDetails = result.ResultDt;


        }

        private void gdv_WCS_TRK_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            
        }

        /// <summary>
        /// 查詢按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshWcsTrk();
        }

        /// <summary>
        /// Gridview RowChanged事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gdv_WCS_TRK_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gdv_WCS_TRK.IsValidRowHandle(gdv_WCS_TRK.FocusedRowHandle) == false)
            {
                gdc_Detail.DataSource = null;
                return;
            }
            if (gdv_WCS_TRK.FocusedRowHandle == DevExpress.XtraGrid.GridControl.AutoFilterRowHandle)
            {
                gdc_Detail.DataSource = null;
                return;
            }

            if (dtDetails.Rows.Count > 0)
            {
                int SerNo = Convert.ToInt16(gdv_WCS_TRK.GetFocusedRowCellValue("SER_NO"));
                int AsrsID = Convert.ToInt16(gdv_WCS_TRK.GetFocusedRowCellValue("ASRS_ID"));
                DateTime CreateDate = Convert.ToDateTime(gdv_WCS_TRK.GetFocusedRowCellValue("CREATE_DATE"));

                var dtSearchDetails = dtDetails.AsEnumerable()
                    .Where(o => o.Field<decimal>("SER_NO") == SerNo &&
                                o.Field<decimal>("ASRS_ID") == AsrsID &&
                                o.Field<DateTime>("CREATE_DATE") == CreateDate);
                if (dtSearchDetails != null)
                {
                    if (dtSearchDetails.Count() > 0)
                    {
                        DataTable dtSearch = dtSearchDetails.CopyToDataTable();
                        gdc_Detail.DataSource = dtSearch;
                    }
                    else
                        gdc_Detail.DataSource = null;
                }
                else
                    gdc_Detail.DataSource = null;

            }
            else
            {
                gdc_Detail.DataSource = null;
            }
        }

        /// <summary>
        /// 搜索框按下Enter事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshWcsTrk();
        }
        /// <summary>
        /// 搜索框按鈕按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtFilter_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            RefreshWcsTrk();
        }

        /// <summary>
        /// 調整欄位按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColumnSet_Click(object sender, EventArgs e)
        {
            List<DevExpress.XtraGrid.Columns.GridColumn> EditColumns = new List<DevExpress.XtraGrid.Columns.GridColumn>();

            System.IO.Stream layoutStream = new System.IO.MemoryStream();
            gdv_WCS_TRK.SaveLayoutToStream(layoutStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);

            FORM_PUBLIC.Fm_SetGridviewColumns EditForm = new WMS.FORM_PUBLIC.Fm_SetGridviewColumns(gdv_WCS_TRK, EditColumns, this.Name, layoutStream);
            layoutStream.Seek(0, System.IO.SeekOrigin.Begin);

            if (EditForm.ShowDialog() == DialogResult.Yes)
            {
                vPublic.RestoreViewLayoutByStream(gdv_WCS_TRK, this.Name, 1, false);
            }
        }

        /// <summary>
        /// 工作檔操作(強制完成/強制取消/先入品/空出庫/置物完成)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrkProcess_Click(object sender, EventArgs e)
        {
            DataTable dtTrk = (DataTable)gdc_WCS_TRK.DataSource;
            Button btn = (sender as Button);
            TrkButton trkButton = trkButtons.Where(o => o.btn == btn).FirstOrDefault();
            Model.WcsTrk.TrkStep ProcessAction = (WMS.Model.WcsTrk.TrkStep)Enum.ToObject(typeof(WMS.Model.WcsTrk.TrkStep), Convert.ToInt16(btn.Tag));
            Model.WcsTrk Trk = new WMS.Model.WcsTrk();
            List<Model.WcsTrk> Trks = new List<WMS.Model.WcsTrk>();

            if (dtTrk == null) return;
            if (dtTrk.Rows.Count <= 0) return;
            if (trkButton == null) return;

            var CheckResult = dtTrk.AsEnumerable().Where(o => o.Field<string>("CHK") == "Y");
            if (CheckResult == null || CheckResult.Count() <= 0)
            {
                //Msg0001 請先勾選要執行操作的工作檔
                vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, RM.GetString("Msg0001"));
                return;
            }

            if (trkButton.MultipleSelect == false)
            {
                if (CheckResult.Count() > 1)
                {
                    //Msg0002 執行「{0}」僅能單選工作檔進行操作，請重新勾選。
                    vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0002"), trkButton.btn.Text));
                    return;
                }
            }

            if (trkButton.ShowConfirmMessage)
            {
                //ConfirmMessage 確定要針對選取的工作檔執行「{0}」嗎?
                if (MessageBox.Show(this, string.Format(RM.GetString("ConfirmMessage"), btn.Text), RM.GetString("MsgTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }

            var CheckList = CheckResult.CopyToDataTable();

            foreach (DataRow drTrk in CheckList.Rows)
            {
                string TrkIO = drTrk["IO"].ToString();
                int SerNo = int.Parse(drTrk["SER_NO"].ToString());
                int trkStep = int.Parse(drTrk["STEP"].ToString());

                #region 工作檔防呆

                //空出庫或者置物完成
                if (ProcessAction == WMS.Model.WcsTrk.TrkStep.Step81 || ProcessAction == WMS.Model.WcsTrk.TrkStep.Step30)
                {
                    if (TrkIO == Model.WcsTrk.IO_I)
                    {
                        //Msg0003 工作檔「{0}」為入庫類型工作檔，不能執行{1}
                        vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0003"), SerNo, trkButton.btn.Text));
                        return;
                    }
                }

                //先入品
                if (ProcessAction == WMS.Model.WcsTrk.TrkStep.Step82)
                {
                    if (TrkIO == Model.WcsTrk.IO_O)
                    {
                        //Msg0004 工作檔「{0}」為出庫類型工作檔，不能執行{1}
                        vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0004"), SerNo, trkButton.btn.Text));
                        return;
                    }
                }

                //先入品或空出庫異常
                if (ProcessAction == WMS.Model.WcsTrk.TrkStep.Step81 || ProcessAction == WMS.Model.WcsTrk.TrkStep.Step82)
                {
                    if (trkStep != Convert.ToInt16(ProcessAction))
                    {
                        //Msg0005 工作檔「{0}」非{2}作業步驟異常，不能執行{1}
                        vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0005"), SerNo, trkButton.btn.Text, trkButton.btn.Text));
                        return;
                    }
                }

                //強制取消
                if (ProcessAction == WMS.Model.WcsTrk.TrkStep.Step0)
                {
                    if (trkStep > Convert.ToInt16(WMS.Model.WcsTrk.TrkStep.Step0))
                    {
                        //Msg0006 工作檔「{0}」已啟動，不能執行{1}
                        vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0006"), SerNo, trkButton.btn.Text));
                        return;
                    }
                }

                //強制完成
                if (ProcessAction == WMS.Model.WcsTrk.TrkStep.Step91)
                {
                    if (trkStep <= Convert.ToInt16(WMS.Model.WcsTrk.TrkStep.Step0))
                    {
                        //Msg0007 工作檔「{0}」尚未啟動，不能執行{1}
                        vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0007"), SerNo, trkButton.btn.Text));
                        return;
                    }
                }

                //置物完成/續行
                if (ProcessAction == WMS.Model.WcsTrk.TrkStep.Step30 || ProcessAction == WMS.Model.WcsTrk.TrkStep.Step83)
                {
                    if (trkStep != Convert.ToInt16(WMS.Model.WcsTrk.TrkStep.Step80))
                    {
                        //Msg0009 工作檔「{0}」非吊車異常作業步驟，不能執行{1}
                        vPublic.ShowAlert(Fm_Alert.AlertType.Warnning, string.Format(RM.GetString("Msg0009"), SerNo, trkButton.btn.Text));
                        return;
                    }
                }
                #endregion

                Trks.Add(new Model.WcsTrk()
                {
                    SER_NO = SerNo,
                    AREA_NO = drTrk["AREA_NO"].ToString(),
                    WH_NO = drTrk["WH_NO"].ToString(),
                    ASRS_ID = int.Parse(drTrk["ASRS_ID"].ToString()),
                    IO = TrkIO,
                    DEV_NO = drTrk["DEV_NO"].ToString(),
                    BIN_NO = drTrk["BIN_NO"].ToString(),
                    STEP = (WMS.Model.WcsTrk.TrkStep)Enum.ToObject(typeof(WMS.Model.WcsTrk.TrkStep), Convert.ToInt16(drTrk["STEP"])),
                    OPN = (WMS.Model.WcsTrk.TrkOPN)Enum.ToObject(typeof(WMS.Model.WcsTrk.TrkOPN), Convert.ToInt16(drTrk["OPN"])),
                    OPN_DESC = drTrk["OPN_DESC"].ToString(),
                    EMERGE = (WMS.Model.WcsTrk.TrkEmerge)Enum.ToObject(typeof(WMS.Model.WcsTrk.TrkEmerge), Convert.ToInt16(drTrk["EMERGE"])),
                    CREATE_DATE = Convert.ToDateTime(drTrk["CREATE_DATE"].ToString()),
                    CREATE_BY = drTrk["CREATE_BY"].ToString(),
                    USE_CRN_ID = int.Parse(drTrk["USE_CRN_ID"].ToString())
                });
            }

            //非緊急程度調整
            if (ProcessAction != WMS.Model.WcsTrk.TrkStep.Step999)
            {
                var result = Trk.TrkProcess(Trks, ProcessAction);
                vPublic.ShowAlert(result.Successed == true ? Fm_Alert.AlertType.Successful : Fm_Alert.AlertType.Error,
                                  result.Successed == true ? string.Format(RM.GetString("Msg0008"), btn.Text) : result.Message);
            }
            else
            {
                pnlEmerge.Visible = true;
                var EditTrk = Trks.First();
                cmbEmerge.EditValue = EditTrk.EMERGE;
                txtSerNo.Text = EditTrk.SER_NO.ToString();
                txtCreateDate.Text = EditTrk.CREATE_DATE.Value.ToString("yyyy/MM/dd HH:mm:ss");
                txtOpnDesc.Text = EditTrk.OPN_DESC;
                txtUseCrnID.Text = EditTrk.USE_CRN_ID.ToString();
                txtDevNo.Text = EditTrk.DEV_NO;
                CurWcsTrk = EditTrk;
            }
            RefreshWcsTrk();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlEmerge.Visible = false;
        }

        /// <summary>
        /// 儲存 緊急程度調整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Model.WcsTrk> Trks = new List<WMS.Model.WcsTrk>();
            Model.WcsTrk Trk = new WMS.Model.WcsTrk();
            CurWcsTrk.EMERGE = (WMS.Model.WcsTrk.TrkEmerge)Enum.ToObject(typeof(WMS.Model.WcsTrk.TrkEmerge), cmbEmerge.EditValue);
            Trks.Add(CurWcsTrk);
            var result = Trk.TrkProcess(Trks, Model.WcsTrk.TrkStep.Step999);
            vPublic.ShowAlert(result.Successed == true ? Fm_Alert.AlertType.Successful : Fm_Alert.AlertType.Error,
                              result.Successed == true ? RM.GetString("SaveOK") : result.Message);

            if (result.Successed)
            {
                pnlEmerge.Visible = false;
                CurWcsTrk = new WMS.Model.WcsTrk();
                RefreshWcsTrk();
            }
        }

        private void cmbCrnID_KeyUp(object sender, KeyEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit edit = sender as DevExpress.XtraEditors.LookUpEdit;
            if (e.KeyCode == Keys.Delete)
            {
                edit.ClosePopup();
                edit.EditValue = null;
            }
            e.Handled = true;  
        }
    }
}
