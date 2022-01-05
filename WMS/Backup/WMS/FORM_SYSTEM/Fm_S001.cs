using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMS
{
    public partial class Fm_S001 : Form
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}.Resource_Fm_S001", "FORM_BASIC"), System.Reflection.Assembly.GetExecutingAssembly());

        public class HrsUser
        {
            public string USER_NO { get; set; }
            public string USER_NAME { get; set; }
            public string USER_ROLE_NO { get; set; }
            public string ROLE_NO { get; set; }
            public string ROLE_NAME { get; set; }
            public string PASSWORD { get; set; }
            public string UNIT_NO { get; set; }
            public string UNIT_NAME { get; set; }
            public bool SUPER_ADMIN_FLG { get; set; }
            public string CAN_EDIT { get; set; }
            public string CAN_DELETE { get; set; }

            public static List<HrsUser> GetHrsUsers()
            {
                List<HrsUser> result = new List<HrsUser>();

                string strSql = "select a.*, b.UNIT_NO, b.UNIT_NAME " +
                                "from HRS_USER a left join HRS_UNIT b on a.UNIT_NO = b.UNIT_NO "+
                                "where 1 = 1 " +
                                " " +
                                "order by a.USER_NO ";
                List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>();

                var ExecResult = vPublic.GetDbData(strSql, parameters);

                if (ExecResult.Successed)
                {
                    if (ExecResult.ResultDt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in ExecResult.ResultDt.Rows)
                        {

                            result.Add(new HrsUser()
                            {
                                USER_NO = dr["USER_NO"].ToString(),
                                USER_NAME = dr["USER_NAME"].ToString(),
                                USER_ROLE_NO = dr["USER_NO"].ToString(),
                                SUPER_ADMIN_FLG = dr["SUPER_ADMIN_FLG"].ToString() == "1" ? true : false,
                                UNIT_NO = dr["UNIT_NO"].ToString(),
                                UNIT_NAME = dr["UNIT_NAME"].ToString(),
                                PASSWORD = dr["PASSWORD"].ToString(),
                                CAN_DELETE = "Y",
                                CAN_EDIT = "Y"
                            });

                            var UserRoles = HrsUser.GetUserRole(dr["USER_NO"].ToString());
                            
                            foreach (KeyValuePair<string, string> item in UserRoles)
                            {
                                result.Add(new HrsUser()
                                {
                                    USER_NO = string.Format("{0}-{1}", dr["USER_NO"].ToString(), item.Key),
                                    USER_NAME = dr["USER_NAME"].ToString(),
                                    USER_ROLE_NO = dr["USER_NO"].ToString(),
                                    SUPER_ADMIN_FLG = dr["SUPER_ADMIN_FLG"].ToString() == "1" ? true : false,
                                    UNIT_NO = dr["UNIT_NO"].ToString(),
                                    UNIT_NAME = dr["UNIT_NAME"].ToString(),
                                    PASSWORD = "",
                                    ROLE_NO = item.Key,
                                    ROLE_NAME = item.Value,
                                    CAN_EDIT = "",
                                    CAN_DELETE = ""
                                });
                            }

                        }

                    }
                }

                return result;
            }

            public static Dictionary<string, string> GetUserRole(string UserNo)
            {
                Dictionary<string, string> result = new Dictionary<string, string>();

                string strSql = "select a.*, b.ROLE_NAME " +
                                "from HRS_USER_ROLE a left join HRS_ROLE b on a.ROLE_NO = b.ROLE_NO where 1 = 1 and a.USER_NO = @USER_NO " +
                                "order by a.USER_NO, a.ROLE_NO ";
                List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>() { 
                    new vPublic.DBParameter() { ParameterName = "USER_NO", Value = UserNo }
                };

                var ExecResult = vPublic.GetDbData(strSql, parameters);
                if (ExecResult.Successed)
                {
                    foreach (DataRow dr in ExecResult.ResultDt.Rows)
                        result.Add(dr["ROLE_NO"].ToString(), dr["ROLE_NAME"].ToString());
                }
                return result;
            }
        }

        public class HrsUnit
        {
            public string UNIT_NO { get; set; }
            public string UNIT_NAME { get; set; }
            public string USER_UNIT_NO { get; set; }
            public string USER_NO { get; set; }
            public string USER_NAME { get; set; }
            public string CAN_EDIT { get; set; }
            public string CAN_DELETE { get; set; }

            public static List<HrsUnit> GetHrsUnits()
            {
                List<HrsUnit> result = new List<HrsUnit>();

                string strSql = "select a.*, b.USER_NO, b.USER_NAME, B.UNIT_NO as USER_UNIT_NO " +
                                "from HRS_UNIT a left outer join HRS_USER b on a.UNIT_NO = b.UNIT_NO and b.DISABLE_FLG = @DISABLE_FLG where 1 = 1  " +
                                " "+
                                "order by a.UNIT_NO ";
                List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>() { 
                        new vPublic.DBParameter(){ ParameterName = "DISABLE_FLG", Value = 0 }
                    };

                var ExecResult = vPublic.GetDbData(strSql, parameters);

                if (ExecResult.Successed)
                {
                    if (ExecResult.ResultDt.Rows.Count > 0)
                    {

                        var GroupRole = from t in ExecResult.ResultDt.AsEnumerable()
                                        group t by new { t1 = t.Field<string>("UNIT_NO"), t2 = t.Field<string>("UNIT_NAME") } into m
                                        select new
                                        {
                                            UNIT_NO = m.Key.t1,
                                            UNIT_NAME = m.Key.t2
                                        };

                        if (GroupRole.ToList().Count > 0)
                        {
                            foreach (var Item in GroupRole)
                            {
                                result.Add(new HrsUnit()
                                {
                                    UNIT_NO = Item.UNIT_NO,
                                    UNIT_NAME = Item.UNIT_NAME,
                                    USER_UNIT_NO = Item.UNIT_NO,
                                    CAN_DELETE = "Y",
                                    CAN_EDIT = "Y"
                                });

                                var query = ExecResult.ResultDt.AsEnumerable().Where(o => o.Field<string>("USER_UNIT_NO") == Item.UNIT_NO);
                                if (query != null)
                                {
                                    if (query.Count() > 0)
                                    {
                                        foreach (var Detail in query)
                                        {
                                            result.Add(new HrsUnit()
                                            {
                                                UNIT_NO = string.Format("{0}-{1}", Detail.Field<string>("UNIT_NO"), Detail.Field<string>("USER_NO")),
                                                UNIT_NAME = Detail.Field<string>("UNIT_NAME"),
                                                USER_UNIT_NO = Detail.Field<string>("UNIT_NO"),
                                                USER_NO = Detail.Field<string>("USER_NO"),
                                                USER_NAME = Detail.Field<string>("USER_NAME"),
                                                CAN_DELETE = "",
                                                CAN_EDIT = ""
                                            });
                                        }
                                    }
                                }
                            }
                        }

                    }
                }

                return result;
            }
        }

        public class RolePriv
        {
            public string ROLE_NO { get; set; }
            public string ROLE_NAME { get; set; }
            public string PRIV_ROLE_NO { get; set; }
            public string FORM_NAME { get; set; }
            public string FORM_TEXT { get; set; }
            public bool HAVE_PRIV { get; set; }
            public bool PRIV_SELECT { get; set; }
            public bool PRIV_INSERT { get; set; }
            public bool PRIV_UPDATE { get; set; }
            public bool PRIV_DELETE { get; set; }
            public bool PRIV_EXEC { get; set; }
            public bool CHK_ALL { get; set; }
            public string CAN_EDIT { get; set; }
            public string CAN_DELETE { get; set; }

            public static List<RolePriv> GetRolePriv()
            {
                List<RolePriv> result = new List<RolePriv>();

                string strSql = "select a.*, (select FORM_TEXT from HRS_MENU_VW where FORM_NAME = a.FORM_NAME and LANG_ID = @LANG_ID) FORM_TEXT, "+
                                "            (select ROLE_NAME from HRS_ROLE where ROLE_NO = a.ROLE_NO) ROLE_NAME "+
                                "from HRS_ROLE_PRIV a where 1 = 1 order by a.FORM_NAME ";
                List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>() { 
                        new vPublic.DBParameter(){ ParameterName = "LANG_ID", Value = Convert.ToInt16(Program.LangID) }
                    };

                var ExecResult = vPublic.GetDbData(strSql, parameters);

                if (ExecResult.Successed)
                {
                    if (ExecResult.ResultDt.Rows.Count > 0)
                    {

                        var GroupRole = from t in ExecResult.ResultDt.AsEnumerable()
                                        group t by new { t1 = t.Field<string>("ROLE_NO"), t2 = t.Field<string>("ROLE_NAME") } into m
                                        select new
                                        {
                                            ROLE_NO = m.Key.t1,
                                            ROLE_NAME = m.Key.t2
                                        };

                        if (GroupRole.ToList().Count > 0)
                        {
                            foreach (var Item in GroupRole)
                            {
                                result.Add(new RolePriv()
                                {
                                    ROLE_NO = Item.ROLE_NO,
                                    ROLE_NAME = Item.ROLE_NAME,
                                    PRIV_ROLE_NO = Item.ROLE_NO,
                                    CAN_DELETE = "Y",
                                    CAN_EDIT = "Y"
                                });

                                var query = ExecResult.ResultDt.AsEnumerable().Where(o => o.Field<string>("ROLE_NO") == Item.ROLE_NO);
                                if (query != null)
                                {
                                    if (query.Count() > 0)
                                    {
                                        foreach (var Detail in query)
                                        {
                                            result.Add(new RolePriv()
                                            {
                                                ROLE_NO = string.Format("{0}-{1}", Detail.Field<string>("ROLE_NO"), Detail.Field<string>("FORM_NAME")),
                                                FORM_NAME = Detail.Field<string>("FORM_NAME"),
                                                FORM_TEXT = Detail.Field<string>("FORM_TEXT"),
                                                PRIV_ROLE_NO = Detail.Field<string>("ROLE_NO"),
                                                ROLE_NAME = Detail.Field<string>("ROLE_NAME"),
                                                PRIV_SELECT = Detail.Field<string>("PRIV_SELECT") == "Y" ? true : false,
                                                PRIV_INSERT = Detail.Field<string>("PRIV_INSERT") == "Y" ? true : false,
                                                PRIV_UPDATE = Detail.Field<string>("PRIV_UPDATE") == "Y" ? true : false,
                                                PRIV_DELETE = Detail.Field<string>("PRIV_DELETE") == "Y" ? true : false,
                                                PRIV_EXEC = Detail.Field<string>("PRIV_EXEC") == "Y" ? true : false,
                                                HAVE_PRIV = true,
                                                CHK_ALL = false,
                                                CAN_DELETE = "",
                                                CAN_EDIT = ""
                                            });
                                        }
                                    }
                                }
                            }
                        }
                        
                    }
                }

                return result;
            }
        }

        public List<RolePriv> RolePrivList { get; set; }
        public List<HrsUnit> HrsUnitList { get; set; }
        public List<HrsUser> HrsUserList { get; set; }

        public Fm_S001()
        {
            InitializeComponent();
        }

        private void RefreshPrivData(string SearchText)
        {
            RolePrivList = RolePriv.GetRolePriv();

            if (!string.IsNullOrEmpty(SearchText))
                RolePrivList = RolePrivList
                    .Where(o => o.ROLE_NO.Contains(SearchText)
                             || o.ROLE_NAME.Contains(SearchText)).ToList();

            treeList_Role.DataSource = RolePrivList;
            treeList_Role.ExpandAll();
            treeList_Role.BestFitColumns();
        }

        private void RefreshUnitData(string SearchText)
        {
            HrsUnitList = HrsUnit.GetHrsUnits();

            if (!string.IsNullOrEmpty(SearchText))
                HrsUnitList = HrsUnitList
                    .Where(o => o.UNIT_NO.Contains(SearchText)
                             || o.UNIT_NAME.Contains(SearchText)).ToList();

            treeList_Unit.DataSource = HrsUnitList;
            treeList_Unit.ExpandAll();
            treeList_Unit.BestFitColumns();
        }

        private void RefreshUserData(string SearchText)
        {
            HrsUserList = HrsUser.GetHrsUsers();

            if (!string.IsNullOrEmpty(SearchText))
                HrsUserList = HrsUserList
                    .Where(o => o.USER_NO.Contains(SearchText)
                             || o.USER_NAME.Contains(SearchText)
                             ).ToList();

            treeList_HrsUser.DataSource = HrsUserList;
            treeList_HrsUser.ExpandAll();
            treeList_HrsUser.BestFitColumns();
        }

        private void Fm_S001_Load(object sender, EventArgs e)
        {
            RefreshPrivData("");
            RefreshUnitData("");
            RefreshUserData("");
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Node = treeList_Role.FocusedNode;

            if (Node != null)
            {
                DevExpress.XtraTreeList.Columns.TreeListColumn columnBudget = treeList_Role.Columns["ROLE_NO"];
                string RoleNo = Node.GetValue(columnBudget).ToString();

                var EditList = RolePrivList.Where(o => o.PRIV_ROLE_NO == RoleNo && o.FORM_NAME!=null).ToList();

                if (EditList != null)
                {
                    if (EditList.Count > 0)
                    {
                        Fm_EditRolePriv objForm = new Fm_EditRolePriv(EditList);
                        objForm.SetEditMode(vPublic.EditMode.Update);
                        objForm.SetText(RM.GetString("EditDialogTitle2"));   //修改角色權限設定
                        objForm.ShowDialog();
                        RefreshPrivData(txtFileter2.Text.Trim());
                    }
                }
            }
        }

        private void txtFileter2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshPrivData(txtFileter2.Text.Trim());
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            RefreshPrivData(txtFileter2.Text.Trim());
        }

        private void btn_Insert2_Click(object sender, EventArgs e)
        {
            Fm_EditRolePriv objForm = new Fm_EditRolePriv(new List<RolePriv>());
            objForm.SetEditMode(vPublic.EditMode.Add);
            objForm.SetText(RM.GetString("AddDialogTitle2"));   //新增角色權限設定
            objForm.ShowDialog();
            RefreshPrivData(txtFileter2.Text.Trim());
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage_User)
            {
                RefreshUserData(txtFilter.Text.Trim());
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Unit)
            {
                RefreshUnitData(txtFileter1.Text.Trim());
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage_Role)
            {
                RefreshPrivData(txtFileter2.Text.Trim());
            }
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshUserData(txtFilter.Text.Trim());
        }

        private void txtFileter1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                RefreshUnitData(txtFileter1.Text.Trim());
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            RefreshUserData(txtFilter.Text.Trim());
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            RefreshUnitData(txtFileter1.Text.Trim());
        }

        private void btn_Insert1_Click(object sender, EventArgs e)
        {
            Fm_HrsUnit objForm = new Fm_HrsUnit();
            objForm.SetEditMode(vPublic.EditMode.Add);
            objForm.SetText(RM.GetString("AddDialogTitle1"));   //新增部門/單位設定
            objForm.ShowDialog();
            RefreshUnitData(txtFileter1.Text.Trim());
        }

        private void repositoryItemButtonEdit_Edit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Node = treeList_Unit.FocusedNode;

            if (Node != null)
            {
                DevExpress.XtraTreeList.Columns.TreeListColumn colUnitNo = treeList_Unit.Columns["UNIT_NO"];
                string UnitNo = Node.GetValue(colUnitNo).ToString();

                DevExpress.XtraTreeList.Columns.TreeListColumn colUnitName = treeList_Unit.Columns["UNIT_NAME"];
                string UnitName = Node.GetValue(colUnitName).ToString();

                Fm_HrsUnit objForm = new Fm_HrsUnit();
                objForm.SetEditMode(vPublic.EditMode.Update);
                objForm.SetText(RM.GetString("EditDialogTitle1"));   //修改部門/單位設定
                objForm.SetEditModel(UnitNo, UnitName);
                objForm.ShowDialog();
                RefreshUnitData(txtFileter1.Text.Trim());

            }
        }

        private void repositoryItemButtonEdit_Delete1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Node = treeList_Unit.FocusedNode;

            if (Node != null)
            {
                DevExpress.XtraTreeList.Columns.TreeListColumn colUnitNo = treeList_Unit.Columns["UNIT_NO"];
                string UnitNo = Node.GetValue(colUnitNo).ToString();
                var KeyModel = HrsUnitList.Where(o => o.UNIT_NO == UnitNo).FirstOrDefault();
                if (KeyModel == null)
                {
                    return;
                }
                else
                {
                    var result = DeleteHrsUnit(KeyModel.USER_UNIT_NO);
                    vPublic.ShowAlert(result.Successed ? Fm_Alert.AlertType.Successful : Fm_Alert.AlertType.Error, result.Message);
                    RefreshUnitData(txtFileter1.Text.Trim());
                }
            }
        }

        private void repositoryItemButtonEdit_Delete2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Node = treeList_Role.FocusedNode;

            if (Node != null)
            {
                DevExpress.XtraTreeList.Columns.TreeListColumn colRoleNo = treeList_Role.Columns["ROLE_NO"];
                string RoleNo = Node.GetValue(colRoleNo).ToString();

                var KeyModel = RolePrivList.Where(o => o.ROLE_NO == RoleNo).FirstOrDefault();
                if (KeyModel == null)
                {
                    return;
                }
                else
                {
                    var result = DeleteHrsRole(KeyModel.PRIV_ROLE_NO);
                    vPublic.ShowAlert(result.Successed ? Fm_Alert.AlertType.Successful : Fm_Alert.AlertType.Error, result.Message);
                    RefreshPrivData(txtFileter2.Text.Trim());
                }

                
            }
        }

        /// <summary>
        /// 刪除角色資料
        /// </summary>
        /// <returns></returns>
        private vPublic.DBExecResult DeleteHrsRole(string RoleNo)
        {
            //刪除角色:{0}資料成功
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = string.Format(RM.GetString("DeleteRoleOk"), RoleNo) };

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
            }

            using (SqlTransaction trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var Cmd = Conn.CreateCommand();
                    Cmd.Transaction = trans;

                    string strSql = string.Empty;

                    strSql = "delete HRS_ROLE where ROLE_NO = @ROLE_NO ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("ROLE_NO", RoleNo);

                    int rtn = Cmd.ExecuteNonQuery();



                    strSql = "delete HRS_ROLE_PRIV where ROLE_NO = @ROLE_NO ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("ROLE_NO", RoleNo);

                    rtn = Cmd.ExecuteNonQuery();

                    strSql = "delete HRS_USER_ROLE where ROLE_NO = @ROLE_NO ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("ROLE_NO", RoleNo);

                    rtn = Cmd.ExecuteNonQuery();

                    string ErrorMessage = string.Empty;
                    //刪除角色:{0}資料
                    bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(RM.GetString("DeleteRoleLog"), RoleNo), "Fm_S001", ref ErrorMessage);
                    if (!LogResult)
                        throw new Exception(ErrorMessage);


                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        /// <summary>
        /// 刪除部門/單位資料
        /// </summary>
        /// <returns></returns>
        private vPublic.DBExecResult DeleteHrsUnit(string UnitNo)
        {
            //刪除部門/單位:{0}資料成功
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = string.Format(RM.GetString("DeleteUnitOk"), UnitNo) };

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
            }

            using (SqlTransaction trans = Conn.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var Cmd = Conn.CreateCommand();
                    Cmd.Transaction = trans;

                    string strSql = string.Empty;

                    strSql = "delete HRS_UNIT where UNIT_NO = @UNIT_NO ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("UNIT_NO", UnitNo);

                    int rtn = Cmd.ExecuteNonQuery();



                    strSql = "update HRS_USER set UNIT_NO = '' where UNIT_NO = @UNIT_NO ";
                    Cmd.CommandText = strSql;
                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("UNIT_NO", UnitNo);

                    rtn = Cmd.ExecuteNonQuery();

                   

                    string ErrorMessage = string.Empty;
                    //刪除部門/單位:{0}資料
                    bool LogResult = vPublic.Insert_WMS_USER_OPR_HIST(Cmd, string.Format(RM.GetString("DeleteUnitLog"), UnitNo), "Fm_S001", ref ErrorMessage);
                    if (!LogResult)
                        throw new Exception(ErrorMessage);


                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
            }
            return result;
        }

        private void treeList_HrsUser_CustomNodeCellEditForEditing(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            
        }

        private void treeList_HrsUser_CustomDrawNodeCell(object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            
        }

        private void treeList_HrsUser_CustomNodeCellEdit(object sender, DevExpress.XtraTreeList.GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column.FieldName == "CAN_EDIT" || e.Column.FieldName == "CAN_DELETE")
            {
                DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit objRep = e.RepositoryItem as DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit;
                if (objRep != null)
                {
                    DevExpress.XtraEditors.Repository.RepositoryItemTextEdit edit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
                    edit.ReadOnly = true;
                    object obj = e.Node.GetValue(0);
                    if (obj != null && obj.ToString() == "")
                    {
                        e.RepositoryItem = edit;
                    }
                }
            }  
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            Fm_HrsUser objForm = new Fm_HrsUser();
            objForm.SetEditMode(vPublic.EditMode.Add);
            objForm.BindHrsUnit(HrsUnit.GetHrsUnits());
            objForm.ShowDialog();
        }

        private void repositoryItemButtonEdit_Edit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Node = treeList_HrsUser.FocusedNode;

            if (Node != null)
            {
                DevExpress.XtraTreeList.Columns.TreeListColumn colUserNo = treeList_HrsUser.Columns["USER_NO"];
                string UserNo = Node.GetValue(colUserNo).ToString();

                var EditModel = HrsUserList.Where(o => o.USER_NO == UserNo).FirstOrDefault();

                if (EditModel != null)
                {
                    Fm_HrsUser objForm = new Fm_HrsUser();
                    objForm.SetEditMode(vPublic.EditMode.Update);
                    objForm.SetEditModel(EditModel);
                    objForm.BindHrsUnit(HrsUnit.GetHrsUnits());
                    objForm.ShowDialog();

                    RefreshUserData(txtFilter.Text);
                }
            }
        }
    }
}
