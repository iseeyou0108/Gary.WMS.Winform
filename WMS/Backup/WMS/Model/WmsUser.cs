using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class WmsUser
    {
        public string UserNo { get; set; }
        public string UserName { get; set; }
        public bool SuperAdmin { get; set; }
        public List<RolePriv> RolePrivs { get; set; }

        public WmsUser()
        {
            RolePrivs = new List<RolePriv>();
        }

        public void GetRolePriv()
        {
            RolePrivs = new List<RolePriv>();
            string strSql = "select a.*,isnull((select ROLE_NAME from HRS_ROLE where ROLE_NO = a.ROLE_NO),a.ROLE_NO) ROLE_NAME from HRS_ROLE_PRIV a where a.ROLE_NO in (select ROLE_NO from HRS_USER_ROLE where USER_NO = @USER_NO ) order by a.FORM_NAME ";
            List<vPublic.DBParameter> parameters = new List<vPublic.DBParameter>()
            {
                new vPublic.DBParameter(){ ParameterName = "USER_NO", Value = this.UserNo}
            };

            var ExecResult = vPublic.GetDbData(strSql, parameters);

            if (ExecResult.Successed)
            {
                if (ExecResult.ResultDt.Rows.Count > 0)
                {
                    foreach (System.Data.DataRow dr in ExecResult.ResultDt.Rows)
                    {
                        RolePrivs.Add(new RolePriv() { 
                            ROLE_NO = dr["ROLE_NO"].ToString(),
                            ROLE_NAME = dr["ROLE_NAME"].ToString(),
                            FORM_NAME = dr["FORM_NAME"].ToString(),
                            PRIV_SELECT = dr["PRIV_SELECT"].ToString(),
                            PRIV_INSERT = dr["PRIV_INSERT"].ToString(),
                            PRIV_UPDATE = dr["PRIV_UPDATE"].ToString(),
                            PRIV_DELETE = dr["PRIV_DELETE"].ToString(),
                            PRIV_EXEC = dr["PRIV_EXEC"].ToString(),
                            PRIV_PRINT = dr["PRIV_PRINT"].ToString(),
                            PRIV_TRANS = dr["PRIV_TRANS"].ToString(),
                            PRIV_EMAIL = dr["PRIV_EMAIL"].ToString(),
                            PRIV_AUDIT = dr["PRIV_AUDIT"].ToString(),
                            PRIV_FILE = dr["PRIV_FILE"].ToString()
                        });
                    }
                }
            }
        }
    }
}
