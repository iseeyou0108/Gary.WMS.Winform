using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace WMS
{
    public class vPublic
    {
        static System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_WCS_TRK", ""), System.Reflection.Assembly.GetExecutingAssembly());
        static System.Resources.ResourceManager RMPublic = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_Public", ""), System.Reflection.Assembly.GetExecutingAssembly());
        
        public class CrnItems
        {
            public int AsrsID { get; set; }
            public int CrnID { get; set; }
            public string Desc { get; set; }
        }
        public class AsrsIDItems
        {
            public int AsrsID { get; set; }
            public string Desc { get; set; }
        }

        public class StatusCtrItems
        {
            public StatusCtr ListStatusCtr { get; set; }
            public string Desc { get; set; }
        }

        public class ListCtrItems
        {
            public ListCtr Value { get; set; }
            public string Desc { get; set; }
        }

        public class ProdTypeItems
        {
            public Model.WmsStk.ProdType PROD_TYPE {get; set;}
            public string PROD_TYPE_DESC { get; set; }
        }

        public class DevNoItems
        {
            public string DevNo { get; set; }
            public string Desc { get; set; }
            public int StnType { get; set; }
        }

        public class EmergeItems
        {
            public Model.WcsTrk.TrkEmerge Emerge { get; set; }
            public string Desc { get; set; }
        }

        public class ShippingStrategyItems
        {
            public Model.WcsTrk.StoreOutStrategy Strategy { get; set; }
            public string Desc { get; set; }
        }

        public class AsrsDefine
        {
            /// <summary>
            /// 工廠代號
            /// </summary>
            public static string AREA_NO { get { return "ASRS"; } }
            /// <summary>
            /// 自動倉
            /// </summary>
            public static string WH_NO { get { return "A"; } }
            /// <summary>
            /// 倉庫代號
            /// </summary>
            public static int ASRS_ID { get { return 1; } }
            /// <summary>
            /// 撿料倉
            /// </summary>
            public static string WH_NO_P { get { return "P"; } }
            /// <summary>
            /// 併板倉
            /// </summary>
            public static string WH_NO_C { get { return "C"; } }
        }
        public class SystemProdNo
        {
            public static string EmptyPallet { get { return "PALLET"; } }
        }

        /// <summary>
        /// 單據狀態
        /// </summary>
        public enum StatusCtr
        {
            接單 = 0,
            收料中 = 8,
            出庫中 = 33,
            強制結單 = 98,
            完成 = 90,
            手動觸發強制結單 = 99
        }

        /// <summary>
        /// 單據類型
        /// </summary>
        public enum ListCtr
        {
            入庫單據 = 1,
            出庫單據 = 2
        }

        public enum EditMode
        {
            Add = 1,
            Update = 2,
            Query = 0
        }

        public enum SystemLanguage
        {
            zh_TW = 1,
            zh_CN = 2,
            en_US = 3
        }

        public enum BarcodeInStatus
        {
            未啟動 = 0,
            作業中 = 1,
            已完成 = 2
        }

        /// <summary>
        /// 資料庫連線字串
        /// </summary>
        public static string ConnStr { get; set; }

        /// <summary>
        /// db執行結果
        /// </summary>
        public class DBExecResult
        {
            public bool Successed { get; set; }
            public string Message { get; set; }
            public int ErrorCode { get; set; }
            public object Data { get; set; }
            public System.Data.DataTable ResultDt { get; set; }
        }

        /// <summary>
        /// db參數
        /// </summary>
        public class DBParameter
        {
            public string ParameterName { get; set; }
            public object Value { get; set; }
        }

        public class FormPriv
        {
            public string FormName { get; set; }
            public bool View { get; set; }
            public bool Add { get; set; }
            public bool Edit { get; set; }
            public bool Delete { get; set; }
            public bool Exec { get; set; }

            public FormPriv()
            {
                View = false;
                Add = false;
                Edit = false;
                Delete = false;
                Exec = false;
            }
        }

        /// <summary>
        /// 設定db連線字串
        /// </summary>
        /// <param name="_ConnStr"></param>
        public static void SetConnStr(string _ConnStr)
        {
            ConnStr = _ConnStr;
        }

        /// <summary>
        /// 取資料庫資料
        /// </summary>
        /// <param name="strSql">查詢語法</param>
        /// <param name="Parameters">查詢參數</param>
        /// <returns></returns>
        public static DBExecResult GetDbData(string strSql, List<DBParameter> Parameters)
        {
            DBExecResult result = new DBExecResult() { Successed = true, ErrorCode = 0, Message = "", ResultDt = new System.Data.DataTable() };
            SqlConnection Conn = new SqlConnection(ConnStr);
            try
            {

                Conn.Open();

                var Cmd = Conn.CreateCommand();
                Cmd.CommandText = strSql;
                if (Parameters != null)
                {
                    if (Parameters.Count > 0)
                    {
                        foreach (DBParameter parameter in Parameters)
                        {
                            Cmd.Parameters.AddWithValue(parameter.ParameterName, (object)parameter.Value ?? DBNull.Value);
                        }
                    }
                }

                SqlDataAdapter dap = new SqlDataAdapter(Cmd);
                dap.Fill(result.ResultDt);

                dap.Dispose();
                Cmd.Dispose();

                

            }
            catch (SqlException ex)
            {
                result.Successed = false;
                result.Message = ex.Message;
                result.ErrorCode = ex.ErrorCode;
            }
            finally
            {
                if (Conn.State == System.Data.ConnectionState.Open)
                    Conn.Close();

                Conn.Dispose();
                
            }

            return result;
        }

        public static Boolean Insert_WMS_USER_OPR_HIST(SqlCommand Cmd, string strRemark, string strProg, ref string strErrorMsg)
        {

            #region 變數宣告

            string strSQL = string.Empty;
            string strUserId = string.Empty;
            Boolean blResult;

            #endregion

            #region 變數賦值

            strUserId = Program.wmsUser.UserNo;        //操作人員
            blResult = false;

            #endregion

            #region 組SQL字串

            strSQL = "insert into WMS_USER_OPR_HIST (ACT_PROG, ACT_REMARK, CREATE_BY, CREATE_DATE) " +
                     "                        values(@VACT_PROG, @VACT_REMARK, @VCREATE_BY, getdate())";

            #endregion

            #region 執行SQL

            
            
            try
            {
                Cmd.CommandText = strSQL;
                Cmd.Parameters.Clear();
                Cmd.Parameters.AddWithValue("VACT_PROG", strProg);
                Cmd.Parameters.AddWithValue("VACT_REMARK", strRemark);
                Cmd.Parameters.AddWithValue("VCREATE_BY", strUserId);
                int rtn = Cmd.ExecuteNonQuery();

                blResult=true;
            }
            catch(SqlException ex)
            {
                return false;
            }
            return blResult;

            #endregion

        }

        public static FormPriv GetFormPriv(string FormName)
        {
            FormPriv result = new FormPriv() { FormName = FormName };

            if (Program.wmsUser.SuperAdmin == true)
            {
                result.View = true;
                result.Add = true;
                result.Edit = true;
                result.Delete = true;
                result.Exec = true;

                return result;
            }

            var FormRolePriv = Program.wmsUser.RolePrivs.Where(o => o.FORM_NAME == FormName).FirstOrDefault();
            if (FormRolePriv == null)
                return result;
            else
            {
                if (Program.wmsUser.SuperAdmin == false)
                {
                    result.View = FormRolePriv.PRIV_SELECT == "Y" ? true : false;
                    result.Add = FormRolePriv.PRIV_INSERT == "Y" ? true : false;
                    result.Edit = FormRolePriv.PRIV_UPDATE == "Y" ? true : false;
                    result.Delete = FormRolePriv.PRIV_DELETE == "Y" ? true : false;
                    result.Exec = FormRolePriv.PRIV_EXEC == "Y" ? true : false;

                    return result;
                }
                else
                {
                    result.View = true;
                    result.Add = true;
                    result.Edit = true;
                    result.Delete = true;
                    result.Exec = true;

                    return result;
                }
            }
        }

        /// <summary>
        /// 恢復layout樣式
        /// </summary>
        /// <param name="View"></param>
        /// <param name="FormName"></param>
        public static void RestoreViewLayoutByStream(DevExpress.XtraGrid.Views.Grid.GridView View, string FormName, int ViewType, bool SaveDefaultView)
        {
            if (SaveDefaultView)
                SaveDefaultViewLayoutByStream(View, FormName);

            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>() 
            { 
                new vPublic.DBParameter(){ ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) },
                new vPublic.DBParameter(){ ParameterName = "VIEW_TYPE", Value = ViewType },
                new vPublic.DBParameter(){ ParameterName = "USER_NO", Value = Program.wmsUser.UserNo },
                new vPublic.DBParameter(){ ParameterName = "FORM_NAME", Value = FormName }
            };
            var QueryResult = vPublic.GetDbData("select * from SYS_COLUMNS_SET where LANG_ID = @LANG_ID and VIEW_TYPE = @VIEW_TYPE and USER_NO = @USER_NO and FORM_NAME = @FORM_NAME ", parameters);

            if (QueryResult.Successed == false)
                return;

            if (QueryResult.ResultDt.Rows.Count > 0)
            {
                System.IO.Stream ViewStream = new System.IO.MemoryStream();

                ViewStream = BytesToStream((byte[])QueryResult.ResultDt.Rows[0]["VIEW_FILE"]);
                View.RestoreLayoutFromStream(ViewStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                ViewStream.Seek(0, System.IO.SeekOrigin.Begin);
            }


        }

        /// <summary>
        /// 儲存預設Layout
        /// </summary>
        /// <param name="View"></param>
        /// <param name="FormName"></param>
        public static void SaveDefaultViewLayoutByStream(DevExpress.XtraGrid.Views.Grid.GridView View, string FormName)
        {
            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);

            try
            {
                Conn = new SqlConnection(vPublic.ConnStr);
                Conn.Open();
            }
            catch (SqlException ex)
            {
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
                return;
            }

            try
            {
                System.IO.Stream ViewStream = new System.IO.MemoryStream();
                View.SaveLayoutToStream(ViewStream, DevExpress.Utils.OptionsLayoutBase.FullLayout);
                ViewStream.Seek(0, System.IO.SeekOrigin.Begin);

                var Cmd = Conn.CreateCommand();

                Cmd.CommandText = @"delete from SYS_COLUMNS_SET 
                                    where FORM_NAME = @FORM_NAME 
                                    and VIEW_TYPE = @VIEW_TYPE
                                    and LANG_ID = @LANG_ID
                                    and USER_NO = @USER_NO ";
                Cmd.Parameters.AddWithValue("FORM_NAME", FormName);
                Cmd.Parameters.AddWithValue("VIEW_TYPE", 0);
                Cmd.Parameters.AddWithValue("LANG_ID", (int)Program.LangID);
                Cmd.Parameters.AddWithValue("USER_NO", Program.wmsUser.UserNo);
                Cmd.ExecuteNonQuery();

                Cmd.Parameters.Clear();
                Cmd.CommandText = @"insert into SYS_COLUMNS_SET (FORM_NAME, VIEW_TYPE, LANG_ID, USER_NO, VIEW_FILE) values (@FORM_NAME,@VIEW_TYPE,@LANG_ID,@USER_NO,@VIEW_FILE) ";
                Cmd.Parameters.AddWithValue("FORM_NAME", FormName);
                Cmd.Parameters.AddWithValue("VIEW_TYPE", 0);
                Cmd.Parameters.AddWithValue("LANG_ID", (int)Program.LangID);
                Cmd.Parameters.AddWithValue("USER_NO", Program.wmsUser.UserNo);
                Cmd.Parameters.AddWithValue("VIEW_FILE", new System.Data.SqlTypes.SqlBytes(ViewStream));
                ViewStream.Seek(0, System.IO.SeekOrigin.Begin);
                Cmd.ExecuteNonQuery();

                if (Conn.State ==  System.Data.ConnectionState.Open)
                    Conn.Close();

                Conn.Dispose();
                Cmd.Dispose();
            }
            catch (SqlException ex)
            {
                if (Conn.State == System.Data.ConnectionState.Open)
                    Conn.Close();

                Conn.Dispose();
                vPublic.ShowAlert(Fm_Alert.AlertType.Error, ex.Message);
                return;
            }
        }

        public static System.IO.Stream BytesToStream(byte[] bytes)
        {
            System.IO.Stream stream = new System.IO.MemoryStream(bytes);

            return stream;
        }

        public static void ShowAlert(Fm_Alert.AlertType type, string Msg)
        {
            Fm_Alert frm = new Fm_Alert();
            frm.ShowAlert(Msg, type);
        }

        public static string GetSystemCultureName(SystemLanguage Language)
        {
            string result = "";
            switch (Language)
            {
                case SystemLanguage.zh_TW:
                    result = "";
                    break;
                case SystemLanguage.zh_CN:
                    result = "zh-CN";
                    break;
                case SystemLanguage.en_US:
                    result = "en-US";
                    break;
                default:
                    break;
            }

            return result;
        }

        /// <summary>
        /// 設定吊車選項下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetCrnItems(DevExpress.XtraEditors.LookUpEdit Cmb)
        {
            List<CrnItems> Items = new List<CrnItems>();

            for (int i = 1; i <= 10; i++)
            {
                Items.Add(new CrnItems()
                {
                    AsrsID = AsrsDefine.ASRS_ID,
                    CrnID = i,
                    Desc = string.Format(RM.GetString("CrnItems"), i)
                });
            }

            Items.Insert(0, new CrnItems() { AsrsID = 0, CrnID = 0, Desc = "" });

            Cmb.Properties.DropDownRows = 11;
            Cmb.Properties.DisplayMember = "Desc";
            Cmb.Properties.ValueMember = "CrnID";
            Cmb.Properties.DataSource = Items;
        }

        /// <summary>
        /// 設定倉庫代號下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetAsrsIDItems(DevExpress.XtraEditors.LookUpEdit Cmb)
        {
            List<AsrsIDItems> Items = new List<AsrsIDItems>();

            for (int i = 1; i <= 1; i++)
            {
                Items.Add(new AsrsIDItems()
                {
                    AsrsID = AsrsDefine.ASRS_ID,
                    Desc = string.Format(RM.GetString("AsrsIDItems"), i)
                });
            }

            Cmb.Properties.DropDownRows = 1;
            Cmb.Properties.DisplayMember = "Desc";
            Cmb.Properties.ValueMember = "AsrsID";
            Cmb.Properties.DataSource = Items;
            Cmb.EditValue = AsrsDefine.ASRS_ID;
        }

        /// <summary>
        /// 設定單據狀態下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetListStatusCtrItems(DevExpress.XtraEditors.LookUpEdit Cmb)
        {
            List<StatusCtrItems> Items = new List<StatusCtrItems>();

            Items.Add(new StatusCtrItems()
            {
                ListStatusCtr = StatusCtr.接單,
                Desc = RMPublic.GetString("StatusCtr0")
            });

            Items.Add(new StatusCtrItems()
            {
                ListStatusCtr = StatusCtr.收料中,
                Desc = RMPublic.GetString("StatusCtr8")
            });

            Items.Add(new StatusCtrItems()
            {
                ListStatusCtr = StatusCtr.出庫中,
                Desc = RMPublic.GetString("StatusCtr33")
            });

            Items.Add(new StatusCtrItems()
            {
                ListStatusCtr = StatusCtr.完成,
                Desc = RMPublic.GetString("StatusCtr90")
            });

            Items.Add(new StatusCtrItems()
            {
                ListStatusCtr = StatusCtr.強制結單,
                Desc = RMPublic.GetString("StatusCtr98")
            });

            Items.Add(new StatusCtrItems()
            {
                ListStatusCtr = StatusCtr.手動觸發強制結單,
                Desc = RMPublic.GetString("StatusCtr99")
            });

            Cmb.Properties.DropDownRows = 6;
            Cmb.Properties.DisplayMember = "Desc";
            Cmb.Properties.ValueMember = "ListStatusCtr";
            Cmb.Properties.DataSource = Items;
        }

        /// <summary>
        /// 設定單據類型下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetListCtrItems(DevExpress.XtraEditors.LookUpEdit Cmb)
        {
            List<ListCtrItems> Items = new List<ListCtrItems>();
            
            Items.Add(new ListCtrItems()
            {
                Value = ListCtr.入庫單據,
                Desc = RMPublic.GetString("ListCtr1")
            });

            Items.Add(new ListCtrItems()
            {
                Value = ListCtr.出庫單據,
                Desc = RMPublic.GetString("ListCtr2")
            });
            
            Cmb.Properties.DropDownRows = 2;
            Cmb.Properties.DisplayMember = "Desc";
            Cmb.Properties.ValueMember = "Value";
            Cmb.Properties.DataSource = Items;
        }

        /// <summary>
        /// 設定出庫策略下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetShippingStraegyItems(DevExpress.XtraEditors.LookUpEdit Cmb)
        {
            List<ShippingStrategyItems> Items = new List<ShippingStrategyItems>();

            Items.Add(new ShippingStrategyItems()
            {
                 Strategy = WMS.Model.WcsTrk.StoreOutStrategy.先進先出,
                 Desc = RMPublic.GetString("ShippingStrategy1")
            });

            Items.Add(new ShippingStrategyItems()
            {
                Strategy = WMS.Model.WcsTrk.StoreOutStrategy.最少板數,
                Desc = RMPublic.GetString("ShippingStrategy2")
            });

            Cmb.Properties.DropDownRows = 2;
            Cmb.Properties.DisplayMember = "Desc";
            Cmb.Properties.ValueMember = "Strategy";
            Cmb.Properties.DataSource = Items;
            Cmb.EditValue = WMS.Model.WcsTrk.StoreOutStrategy.先進先出;
        }

        /// <summary>
        /// 設定出庫站台下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetStoreOutDevNoItems(ComboBox Cmb)
        {
            List<DevNoItems> Items = new List<DevNoItems>();

            Items.Add(new DevNoItems()
            {
                DevNo = "",
                Desc = "",
                StnType = 0
            });

            Items.Add(new DevNoItems()
            {
                DevNo = "1001",
                Desc = "1001",
                StnType = 2
            });

            Items.Add(new DevNoItems()
            {
                DevNo = "1007",
                Desc = "1007",
                StnType = 2
            });

            Cmb.DisplayMember = "Desc";
            Cmb.ValueMember = "DevNo";
            Cmb.DataSource = Items;
            Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb.SelectedIndex = 0;
        }

        /// <summary>
        /// 設定盤點出庫站台下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetCheckOutDevNoItems(ComboBox Cmb)
        {
            List<DevNoItems> Items = new List<DevNoItems>();

            Items.Add(new DevNoItems()
            {
                DevNo = "1009",
                Desc = "1009",
                StnType = 2
            });

            Cmb.DisplayMember = "Desc";
            Cmb.ValueMember = "DevNo";
            Cmb.DataSource = Items;
            Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb.SelectedIndex = 0;
        }

        /// <summary>
        /// 設定入庫站台下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetStoreInDevNoItems(ComboBox Cmb)
        {
            List<DevNoItems> Items = new List<DevNoItems>();

            Items.Add(new DevNoItems()
            {
                DevNo = "",
                Desc = "",
                StnType = 0
            });

            Items.Add(new DevNoItems()
            {
                DevNo = "1106",
                Desc = "1106",
                StnType = 1
            });

            Items.Add(new DevNoItems()
            {
                DevNo = "1108",
                Desc = "1108",
                StnType = 1
            });

            Items.Add(new DevNoItems()
            {
                DevNo = "1109",
                Desc = "1109",
                StnType = 1
            });

            Cmb.DisplayMember = "Desc";
            Cmb.ValueMember = "DevNo";
            Cmb.DataSource = Items;
            Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb.SelectedIndex = 3;
        }

        /// <summary>
        /// 設定棧板補充站台下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetPalletSupplyDevNoItems(ComboBox Cmb)
        {
            List<DevNoItems> Items = new List<DevNoItems>();

            Items.Add(new DevNoItems()
            {
                DevNo = "1107",
                Desc = "1107",
                StnType = 2
            });

            
            Cmb.DisplayMember = "Desc";
            Cmb.ValueMember = "DevNo";
            Cmb.DataSource = Items;
            Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            Cmb.Enabled = false;
            Cmb.SelectedIndex = 0;
        }

        /// <summary>
        /// 設定料號下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetWmsProdItems(DevExpress.XtraEditors.LookUpEdit Cmb, string ProdNo)
        {
            string strSql = "select PROD_NO, PROD_NAME, UN, PROD_TYPE from WMS_PROD where 1 = 1 {0} order by PROD_NO";
            string strSqlWhere = "";
            List<DBParameter> parameters = new List<DBParameter>();
            if (!string.IsNullOrEmpty(ProdNo))
            {
                strSqlWhere += "and PROD_NO like @PROD_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_NO", Value = "%" + ProdNo + "%" });
            }
            var result = GetDbData(string.Format(strSql, strSqlWhere), parameters);

            Cmb.Properties.Columns.Clear();
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdNo"), FieldName = "PROD_NO", Width = 20 });
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdName"), FieldName = "PROD_NAME", Width = 20 });
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdType"), FieldName = "PROD_TYPE", Width = 20 });


            Cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Cmb.Properties.DropDownRows = 15;
            Cmb.Properties.DisplayMember = "PROD_NAME";
            Cmb.Properties.ValueMember = "PROD_NO";
            Cmb.Properties.DataSource = result.ResultDt;
        }

        /// <summary>
        /// 設定料號下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetWmsProdItems(List<DevExpress.XtraEditors.LookUpEdit> Cmbs, string ProdNo)
        {
            string strSql = "select PROD_NO, PROD_NAME, UN, PROD_TYPE from WMS_PROD where 1 = 1 {0} order by PROD_NO";
            string strSqlWhere = "";
            List<DBParameter> parameters = new List<DBParameter>();
            if (!string.IsNullOrEmpty(ProdNo))
            {
                strSqlWhere += "and PROD_NO like @PROD_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_NO", Value = "%" + ProdNo + "%" });
            }
            var result = GetDbData(string.Format(strSql, strSqlWhere), parameters);

            foreach (var Cmb in Cmbs)
            {
                Cmb.Properties.Columns.Clear();
                Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdNo"), FieldName = "PROD_NO", Width = 20 });
                Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdName"), FieldName = "PROD_NAME", Width = 20 });
                Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdType"), FieldName = "PROD_TYPE", Width = 20 });


                Cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                Cmb.Properties.DropDownRows = 15;
                Cmb.Properties.DisplayMember = "PROD_NAME";
                Cmb.Properties.ValueMember = "PROD_NO";
                Cmb.Properties.DataSource = result.ResultDt;
            }
        }

        /// <summary>
        /// 設定料號下拉選單(是否顯示單位)
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetWmsProdItems(DevExpress.XtraEditors.LookUpEdit Cmb, string ProdNo, Boolean ShowUnits)
        {
            GetWmsProdItems(Cmb, ProdNo);

            Cmb.Properties.Columns.Clear();
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdNo"), FieldName = "PROD_NO", Width = 20 });
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdName"), FieldName = "PROD_NAME", Width = 20 });
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdType"), FieldName = "PROD_TYPE", Width = 20 });

            if (ShowUnits)
            {
                Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colUnits"), FieldName = "UN", Width = 20 });
            }
        }

        /// <summary>
        /// 設定料號下拉選單(是否顯示單位)
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetWmsProdItems(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Cmb, string ProdNo, Boolean ShowUnits)
        {
            if (Cmb == null) return;
            string strSql = "select PROD_NO, PROD_NAME, UN, PROD_TYPE from WMS_PROD where 1 = 1 {0} order by PROD_NO";
            string strSqlWhere = "";
            List<DBParameter> parameters = new List<DBParameter>();
            if (!string.IsNullOrEmpty(ProdNo))
            {
                strSqlWhere += "and PROD_NO like @PROD_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "PROD_NO", Value = "%" + ProdNo + "%" });
            }
            var result = GetDbData(string.Format(strSql, strSqlWhere), parameters);

            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdNo"), FieldName = "PROD_NO", Width = 20 });
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdName"), FieldName = "PROD_NAME", Width = 20 });
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdType"), FieldName = "PROD_TYPE", Width = 20 });

            if (ShowUnits)
            {
                Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colUnits"), FieldName = "UN", Width = 20 });
            }
            Cmb.NullText = RMPublic.GetString("ProdNoNullText");
            Cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Cmb.Properties.DropDownRows = 15;
            Cmb.Properties.DisplayMember = "PROD_NO";
            Cmb.Properties.ValueMember = "PROD_NO";
            Cmb.Properties.DataSource = result.ResultDt;
        }

        /// <summary>
        /// 設定客戶代號下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetWmsOrgItems(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Cmb, string OrgNo)
        {
            if (Cmb == null) return;
            string strSql = "select ORG_NO, SNAME from WMS_ORG where 1 = 1 {0} order by ORG_NO";
            string strSqlWhere = "";
            List<DBParameter> parameters = new List<DBParameter>();
            if (!string.IsNullOrEmpty(OrgNo))
            {
                strSqlWhere += "and ORG_NO like @ORG_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "ORG_NO", Value = "%" + OrgNo + "%" });
            }
            var result = GetDbData(string.Format(strSql, strSqlWhere), parameters);

            Cmb.Columns.Clear();
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colOrgNo"), FieldName = "ORG_NO", Width = 20 });
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colSname"), FieldName = "SNAME", Width = 20 });

           
            Cmb.NullText = RMPublic.GetString("OrgNoNullText");
            Cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Cmb.Properties.DropDownRows = 15;
            Cmb.Properties.DisplayMember = "ORG_NO";
            Cmb.Properties.ValueMember = "ORG_NO";
            Cmb.Properties.DataSource = result.ResultDt;
        }

        /// <summary>
        /// 設定物料類型下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetWmsPordTypeItems(DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit Cmb)
        {
            if (Cmb == null) return;
            

            Cmb.Columns.Clear();
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colProdTypeDesc"), FieldName = "PROD_TYPE_DESC", Width = 20 });

            List<ProdTypeItems> Items = new List<ProdTypeItems>()
            {
                new ProdTypeItems() { PROD_TYPE= WMS.Model.WmsStk.ProdType.成品_原物料, PROD_TYPE_DESC = RMPublic.GetString("PROD_TYPE_0")},
                new ProdTypeItems() { PROD_TYPE= WMS.Model.WmsStk.ProdType.載具, PROD_TYPE_DESC = RMPublic.GetString("PROD_TYPE_1")},
                new ProdTypeItems() { PROD_TYPE= WMS.Model.WmsStk.ProdType.先入品, PROD_TYPE_DESC = RMPublic.GetString("PROD_TYPE_2")}
            };

            Cmb.NullText = "";
            Cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Cmb.Properties.DropDownRows = 3;
            Cmb.Properties.DisplayMember = "PROD_TYPE_DESC";
            Cmb.Properties.ValueMember = "PROD_TYPE";
            Cmb.Properties.DataSource = Items;
        }

        /// <summary>
        /// 設定客戶代號下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetWmsOrgItems(DevExpress.XtraEditors.LookUpEdit Cmb, string OrgNo)
        {
            if (Cmb == null) return;
            string strSql = "select ORG_NO, SNAME from WMS_ORG where 1 = 1 {0} order by ORG_NO";
            string strSqlWhere = "";
            List<DBParameter> parameters = new List<DBParameter>();
            if (!string.IsNullOrEmpty(OrgNo))
            {
                strSqlWhere += "and ORG_NO like @ORG_NO ";
                parameters.Add(new vPublic.DBParameter() { ParameterName = "ORG_NO", Value = "%" + OrgNo + "%" });
            }
            var result = GetDbData(string.Format(strSql, strSqlWhere), parameters);

            Cmb.Properties.Columns.Clear();
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colOrgNo"), FieldName = "ORG_NO", Width = 20 });
            Cmb.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo() { Caption = RMPublic.GetString("colSname"), FieldName = "SNAME", Width = 20 });


            Cmb.Properties.NullText = RMPublic.GetString("OrgNoNullText");
            Cmb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            Cmb.Properties.DropDownRows = 15;
            Cmb.Properties.DisplayMember = "ORG_NO";
            Cmb.Properties.ValueMember = "ORG_NO";
            Cmb.Properties.DataSource = result.ResultDt;
        }

        /// <summary>
        /// 設定倉庫代號下拉選單
        /// </summary>
        /// <param name="Cmb"></param>
        public static void GetEmergeItems(DevExpress.XtraEditors.LookUpEdit Cmb)
        {
            List<EmergeItems> Items = new List<EmergeItems>();

            Items.Add(new EmergeItems()
            {
                Emerge = Model.WcsTrk.TrkEmerge.Normal,
                Desc = RMPublic.GetString("Emerge1")
            });

            Items.Add(new EmergeItems()
            {
                Emerge = Model.WcsTrk.TrkEmerge.Low,
                Desc = RMPublic.GetString("Emerge2")
            });

            Items.Add(new EmergeItems()
            {
                Emerge = Model.WcsTrk.TrkEmerge.Warnning,
                Desc = RMPublic.GetString("Emerge3")
            });

            Items.Add(new EmergeItems()
            {
                Emerge = Model.WcsTrk.TrkEmerge.Danger,
                Desc = RMPublic.GetString("Emerge4")
            });

            Cmb.Properties.DropDownRows = 4;
            Cmb.Properties.DisplayMember = "Desc";
            Cmb.Properties.ValueMember = "Emerge";
            Cmb.Properties.DataSource = Items;
            Cmb.EditValue = Model.WcsTrk.TrkEmerge.Normal;
        }

        #region 帳號加解密
        public static string EnCodePasswd(string _sPasswd)
        {
            ENCRYPTION objEncryp = new ENCRYPTION();

            string lsEnCode_String = string.Empty;

            try
            {
                lsEnCode_String = objEncryp.GetEncrypt(_sPasswd, CryptFormat.RB64);
            }
            catch (Exception)
            {
                lsEnCode_String = string.Empty;
            }


            return lsEnCode_String;
        }

        public static string DeCodePasswd(string _sPasswd)
        {
            ENCRYPTION objEncryp = new ENCRYPTION();

            string lsDeCode_String = string.Empty;

            try
            {
                lsDeCode_String = objEncryp.GetDecrypt(_sPasswd, CryptFormat.RB64);
            }
            catch (Exception)
            {
                lsDeCode_String = string.Empty;
            }

            return lsDeCode_String;
        }

        #endregion
    }
}
