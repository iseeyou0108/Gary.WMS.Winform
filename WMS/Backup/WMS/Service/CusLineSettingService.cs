using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace WMS.Service
{
    public class CusLineSettingService
    {
        static System.Resources.ResourceManager RMPublic = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_Public", ""), System.Reflection.Assembly.GetExecutingAssembly());

        public vPublic.DBExecResult GetData()
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };
            result = vPublic.GetDbData("select * from CUS_LINE_SETTING order by LINE_ID ", new List<vPublic.DBParameter>());
            if (result.Successed == false)
                return result;

            result.Data = result.ResultDt
                .AsEnumerable()
                .Select(o => new Model.CusLineSetting()
                {
                    LINE_ID = o.Field<decimal>("LINE_ID"),
                    LINE_DESC = o.Field<string>("LINE_DESC"),
                    PROD_NO = o.Field<string>("PROD_NO"),
                }).ToList();

            return result;
        }

        public vPublic.DBExecResult Edit(List<Model.CusLineSetting> Datas)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RMPublic.GetString("SubmitOK") };

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
                    int rtn = 0;
                    string strSql = string.Empty;

                    foreach (var Item in Datas)
                    {
                        strSql = "update CUS_LINE_SETTING set LINE_DESC = @LINE_DESC, PROD_NO = @PROD_NO where LINE_ID = @LINE_ID ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("LINE_DESC", (object)Item.LINE_DESC ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PROD_NO", (object)Item.PROD_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("LINE_ID", (object)Item.LINE_ID ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    result.Successed = false;
                    result.Message = ex.Message;
                    //return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
                }
                finally
                {
                    if (Conn.State == ConnectionState.Open)
                        Conn.Close();
                    Conn.Dispose();
                }
            }
            return result;
        }
    }
}
