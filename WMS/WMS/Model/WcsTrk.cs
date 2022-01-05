using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;

namespace WMS.Model
{
    public class WcsTrk
    {
        System.Resources.ResourceManager RM = new System.Resources.ResourceManager(string.Format("WMS.Language.{0}Resource_WCS_TRK", ""), System.Reflection.Assembly.GetExecutingAssembly());

        List<string> DevNos = new List<string>() { "1001", "1007" };

        public enum StoreOutStrategy
        {
            最少板數 = 0,
            先進先出 = 1
        }

        public enum StoreInCreateType
        {
            單板入庫 = 0,
            批次入庫 = 1
        }

        /// <summary>
        /// 工作檔OPN定義
        /// </summary>
        public enum TrkOPN
        {
            [Description("吊車移動")]
            OPN2 = 2,

            [Description("吊車取物")]
            OPN3 = 3,

            [Description("吊車置物")]
            OPN4 = 4,

            [Description("庫間移載")]
            OPN5 = 5,

            [Description("站間移載")]
            OPN6 = 6,

            [Description("入庫作業")]
            OPN101 = 101,

            [Description("空托盤入庫作業")]
            OPN102 = 102,

            [Description("出庫作業")]
            OPN201 = 201,

            [Description("空托盤出庫作業")]
            OPN202 = 202,

            [Description("先入品出庫作業")]
            OPN203 = 203,

            [Description("盤點作業")]
            OPN301 = 301
        }

        /// <summary>
        /// 工作檔作業步驟定義
        /// </summary>
        public enum TrkStep
        {
            [Description("未啟動")]
            Step0 = 0,

            [Description("置物完成")]
            Step30 = 30,

            [Description("取物中先入品")]
            Step78 = 78,

            [Description("吊車異常")]
            Step80 =80,

            [Description("空出庫異常")]
            Step81 = 81,

            [Description("先入品異常")]
            Step82 = 82,

            [Description("異常續行派令中")]
            Step83 = 83,

            [Description("正常完成")]
            Step90 = 90,

            [Description("強制完成")]
            Step91 = 91,

            [Description("到站待處理")]
            Step92 = 92,

            [Description("強制取消")]
            Step99 = 99,

            [Description("緊急程度調整")]
            Step999 = 999
        }

        /// <summary>
        /// 緊急程度
        /// </summary>
        public enum TrkEmerge
        {
            Normal = 0,
            Low = 10,
            Warnning = 50,
            Danger = 80
        }

        /// <summary>
        /// IO定義(入庫)
        /// </summary>
        public static string IO_I { get { return "I"; } }
        /// <summary>
        /// IO定義(出庫)
        /// </summary>
        public static string IO_O { get { return "O"; } }
        /// <summary>
        /// IO定義(庫間移載)
        /// </summary>
        public static string IO_C { get { return "C"; } }
        /// <summary>
        /// IO定義(吊車動作)
        /// </summary>
        public static string IO_M { get { return "M"; } }

        public int SER_NO { get; set; }
        public string AREA_NO { get; set; }
        public string WH_NO { get; set; }
        public int ASRS_ID { get; set; }
        public string BIN_NO { get; set; }
        public string SD { get; set; }
        public string SHF_NO { get; set; }
        public string SHF_SD { get; set; }
        public string DEV_NO { get; set; }
        public string CUR_DEV_NO { get; set; }
        public string NEXT_DEV_NO { get; set; }
        public string TRANS_DEV_NO { get; set; }
        public string IO { get; set; }
        public TrkStep STEP { get; set; }
        public int STATUS { get; set; }
        public TrkOPN OPN { get; set; }
        public string OPN_DESC { get; set; }
        public int USE_CRN_ID { get; set; }
        public TrkEmerge EMERGE { get; set; }
        public decimal WEIGHT { get; set; }
        public int SIZE_CHK { get; set; }
        public string BIN_TYPE { get; set; }
        public string KIND { get; set; }
        public DateTime? START_TIME { get; set; }
        public DateTime? STEP_TIME { get; set; }
        public DateTime? END_TIME { get; set; }
        public string PALLET_NO { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string CREATE_BY { get; set; }

        public List<WcsTrkDet> Details { get; set; }

        /// <summary>
        /// 產生工作檔序號
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult GenSerNo(ref int SerNo)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
            }

            try
            {
                var Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 600;
                Cmd.CommandText = "ASRS_TRK_SER_SP";
                SqlCommandBuilder.DeriveParameters(Cmd);
                Cmd.Parameters["@O_SER_NO"].Value = 0;
                Cmd.Parameters["@O_SER_NO"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.Parameters["@O_ERR_CODE"].Value = 0;
                Cmd.Parameters["@O_ERR_CODE"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.Parameters["@O_ERR_DESC"].Value = "";
                Cmd.Parameters["@O_ERR_DESC"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.ExecuteNonQuery();

                if (Cmd.Parameters["@O_ERR_CODE"].Value.ToString() != "0")
                    throw new Exception(Cmd.Parameters["@O_ERR_DESC"].Value.ToString());

                SerNo = Convert.ToInt16(Cmd.Parameters["@O_SER_NO"].Value);

                Cmd.Dispose();
            }
            catch (SqlException ex)
            {
                result.Successed = false;
                result.Message = ex.Message;
                result.ErrorCode = ex.ErrorCode;
            }

            if (Conn.State == System.Data.ConnectionState.Open)
                Conn.Close();
            Conn.Dispose();

            return result;
        }

        /// <summary>
        /// 取空庫位
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult GenEmptyBinNo(int AsrsID, int CrnID, string Kind, ref string BinNo, ref string SD)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
            }

            try
            {
                var Cmd = Conn.CreateCommand();
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandTimeout = 600;
                Cmd.CommandText = "ASRS_GETBIN_BYKIND_SP";

                SqlCommandBuilder.DeriveParameters(Cmd);
                Cmd.Parameters["@I_ASRS_ID"].Value = AsrsID;
                Cmd.Parameters["@I_ASRS_ID"].Direction = System.Data.ParameterDirection.Input;

                Cmd.Parameters["@I_CRN_ID"].Value = CrnID;
                Cmd.Parameters["@I_CRN_ID"].Direction = System.Data.ParameterDirection.Input;

                Cmd.Parameters["@I_KIND"].Value = Kind;
                Cmd.Parameters["@I_KIND"].Direction = System.Data.ParameterDirection.Input;

                Cmd.Parameters["@O_BIN_NO"].Value = "";
                Cmd.Parameters["@O_BIN_NO"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.Parameters["@O_SD"].Value = "";
                Cmd.Parameters["@O_SD"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.Parameters["@O_ERR_CODE"].Value = 0;
                Cmd.Parameters["@O_ERR_CODE"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.Parameters["@O_ERR_DESC"].Value = "";
                Cmd.Parameters["@O_ERR_DESC"].Direction = System.Data.ParameterDirection.InputOutput;

                Cmd.ExecuteNonQuery();

                if (Cmd.Parameters["@O_ERR_CODE"].Value.ToString() != "0")
                    throw new Exception(Cmd.Parameters["@O_ERR_DESC"].Value.ToString());

                BinNo = Cmd.Parameters["@O_BIN_NO"].Value.ToString();
                SD = Cmd.Parameters["@O_SD"].Value.ToString();

                Cmd.Dispose();
            }
            catch (SqlException ex)
            {
                result.Successed = false;
                result.Message = ex.Message;
                result.ErrorCode = ex.ErrorCode;
            }

            if (Conn.State == ConnectionState.Open)
                Conn.Close();
            Conn.Dispose();

            return result;
        }

        /// <summary>
        /// 工作檔維護(強制完成/強制取消/空出庫/先入品/吊車續行/緊急程度調整/置物完成)
        /// </summary>
        /// <returns></returns>
        public vPublic.DBExecResult TrkProcess(List<WcsTrk> Trks, TrkStep ProcessAction)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            SqlConnection Conn = new SqlConnection(vPublic.ConnStr);
            try
            {
                Conn.Open();
            }
            catch (SqlException ex)
            {
                return new vPublic.DBExecResult() { Successed = false, Message = ex.Message };
            }

            try
            {
                var Cmd = Conn.CreateCommand();
                Cmd.CommandTimeout = 600;
                switch (ProcessAction)
                {
                    case TrkStep.Step0:     //強制取消
                    case TrkStep.Step99:    //強制取消
                    case TrkStep.Step91:    //強制完成
                    case TrkStep.Step81:    //空出庫
                    case TrkStep.Step82:    //先入品
                        Cmd.CommandType = CommandType.StoredProcedure;
                        foreach (var Trk in Trks)
                        {
                            string SPName = string.Empty;
                            if (ProcessAction == TrkStep.Step0) SPName = "ASRS_CANCEL_SP";
                            else if (ProcessAction == TrkStep.Step81) SPName = "ASRS_NONELOAD_SP";
                            else if (ProcessAction == TrkStep.Step82) SPName = "ASRS_PRELOAD_SP";
                            else if (ProcessAction == TrkStep.Step91) SPName = "ASRS_COMPLETE_SP";
                            else if (ProcessAction == TrkStep.Step99) SPName = "ASRS_CANCEL_SP";

                            Cmd.CommandText = SPName;

                            SqlCommandBuilder.DeriveParameters(Cmd);
                            Cmd.Parameters["@I_SER_NO"].Value = Trk.SER_NO;
                            Cmd.Parameters["@I_SER_NO"].Direction = ParameterDirection.Input;

                            Cmd.Parameters["@I_CREATE_DATE"].Value = Trk.CREATE_DATE.Value.ToString("yyyy/MM/dd HH:mm:ss");
                            Cmd.Parameters["@I_CREATE_DATE"].Direction = ParameterDirection.Input;

                            Cmd.Parameters["@I_USER_NO"].Value = Program.wmsUser.UserNo;
                            Cmd.Parameters["@I_USER_NO"].Direction = ParameterDirection.Input;

                            Cmd.Parameters["@O_ERR_CODE"].Value = 0;
                            Cmd.Parameters["@O_ERR_CODE"].Direction = ParameterDirection.InputOutput;

                            Cmd.Parameters["@O_ERR_DESC"].Value = "";
                            Cmd.Parameters["@O_ERR_DESC"].Direction = ParameterDirection.InputOutput;

                            Cmd.ExecuteNonQuery();

                            if (Cmd.Parameters["@O_ERR_CODE"].Value.ToString() != "0")
                                throw new Exception(Cmd.Parameters["@O_ERR_DESC"].Value.ToString());
                        }
                        break;
                    case TrkStep.Step80:
                        break;
                    case TrkStep.Step30:    //置物完成
                    case TrkStep.Step83:    //吊車續行
                        foreach (var Trk in Trks)
                        {
                            Cmd.CommandText = "update WCS_TRK set STEP = @STEP where SER_NO = @SER_NO and CREATE_DATE = @CREATE_DATE";
                            Cmd.Parameters.Clear();
                            Cmd.Parameters.AddWithValue("STEP", Convert.ToInt16(ProcessAction));
                            Cmd.Parameters.AddWithValue("SER_NO", Trk.SER_NO);
                            Cmd.Parameters.AddWithValue("CREATE_DATE", Trk.CREATE_DATE.Value.ToString("yyyy/MM/dd HH:mm:ss"));
                            int rtn = Cmd.ExecuteNonQuery();
                            if (rtn != 1)
                                throw new Exception(string.Format(RM.GetString("EffectRowsError"), rtn));   //資料庫異動筆數錯誤，異動筆數:{0}
                        }
                        
                        break;
                    case TrkStep.Step999:
                        foreach (var Trk in Trks)
                        {
                            Cmd.CommandText = "update WCS_TRK set EMERGE = @EMERGE where SER_NO = @SER_NO and CREATE_DATE = @CREATE_DATE";
                            Cmd.Parameters.Clear();
                            Cmd.Parameters.AddWithValue("EMERGE", Convert.ToInt16(Trk.EMERGE));
                            Cmd.Parameters.AddWithValue("SER_NO", Trk.SER_NO);
                            Cmd.Parameters.AddWithValue("CREATE_DATE", Trk.CREATE_DATE.Value.ToString("yyyy/MM/dd HH:mm:ss"));
                            int rtn = Cmd.ExecuteNonQuery();
                            if (rtn != 1)
                                throw new Exception(string.Format(RM.GetString("EffectRowsError"), rtn));   //資料庫異動筆數錯誤，異動筆數:{0}
                        }
                        break;
                    default:
                        break;
                }

                Cmd.Dispose();
            }
            catch (SqlException ex)
            {
                result.Successed = false;
                result.Message = ex.Message;
                result.ErrorCode = ex.ErrorCode;
            }

            if (Conn.State == ConnectionState.Open)
                Conn.Close();
            Conn.Dispose();

            return result;
        }

        /// <summary>
        /// 產生空棧板出庫作業
        /// </summary>
        /// <param name="Stks">要出庫的庫存資料集</param>
        /// <param name="DevNo">出庫站台編號</param>
        /// <returns></returns>
        public vPublic.DBExecResult CreatePalletOut(List<Model.WmsStk> Stks, string DevNo)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            if (Stks == null)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0004") }; //參數Stks不可為null

            if(Stks.Count<=0)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0005") }; //參數Stks筆數為0, 不需出庫


            if (string.IsNullOrEmpty(DevNo))
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0006") }; //參數出庫站台編號(DevNo) 為空值，不可出庫。

            #region 庫位檢查(檢查是否允許出庫)

            //取當前庫存資料
            Model.WmsStk StkLib = new WmsStk();
            List<Model.WmsStk> CurStks = new List<WmsStk>();
            var StkResult = StkLib.GetAllWmsStk(Convert.ToInt16(Stks.First().ASRS_ID), ref CurStks);
            if (!StkResult.Successed)
                return StkResult;

            foreach (var Stk in Stks)
            {
                var CurStk = CurStks
                    .Where(o => o.FIFO_NO == Stk.FIFO_NO).FirstOrDefault();

                if (CurStk == null)
                    return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0007") }; //選取的庫存資料已被異動，請重新查詢確認

                if (CurStk.STUS_CTR != Convert.ToDecimal(WmsStk.StusCtr.可用庫存))
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RM.GetString("Msg0008"), CurStk.BIN_NO, CurStk.STUS_CTR_DESC) }; //庫位:{0}, 庫存狀態:{1}, 非在庫庫存, 請重新查詢確認
            }

            #endregion

            List<WcsTrk> Trks = new List<WcsTrk>();

            for (int i = 0; i < Stks.Count; i++)
            {
                WcsTrk Trk = new WcsTrk();

                Trk.AREA_NO = vPublic.AsrsDefine.AREA_NO;
                Trk.WH_NO = vPublic.AsrsDefine.WH_NO;
                Trk.ASRS_ID = Convert.ToInt16(Stks[i].ASRS_ID);

                Boolean SameBinNo = false;
                SameBinNo = Trks.Select(o => o.AREA_NO == Stks[i].AREA_NO &&
                    o.WH_NO == Stks[i].WH_NO &&
                    o.ASRS_ID == Convert.ToInt16(Stks[i].ASRS_ID) &&
                    o.BIN_NO == Stks[i].BIN_NO
                    ).FirstOrDefault();

                if (SameBinNo) continue;

                #region 取序號、作業時間
                int SerNo = 0;
                var SerNoResult = GenSerNo(ref SerNo);
                if (SerNoResult.Successed == false)
                {
                    result = SerNoResult;
                    break;
                }

                Trk.SER_NO = SerNo;

                var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
                if (CreateDateResult.Successed == false)
                {
                    result = CreateDateResult;
                    break;
                }

                Trk.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

                #endregion

                Trk.USE_CRN_ID = Stks[i].CRN_ID;//吊車
                Trk.BIN_NO = Stks[i].BIN_NO;    //庫位
                Trk.SD = Stks[i].SD;            //庫位深淺
                Trk.DEV_NO = DevNo;             //站台編號
                Trk.IO = IO_O;                  //IO
                Trk.OPN = TrkOPN.OPN202;        //作業別
                Trk.STEP = TrkStep.Step0;       //作業步驟
                Trk.STATUS = 0;                 //作業狀態
                Trk.EMERGE = TrkEmerge.Normal;  //緊急程度(一般)

                #region 工作檔明細資料
                Trk.Details = new List<WcsTrkDet>();
                Trk.Details.Add(new WcsTrkDet(Trk.SER_NO, Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.CREATE_DATE, Trk.CREATE_BY)
                {
                    TRK_COUNT = 1,
                    PROD_NO = Stks[i].PROD_NO,
                    QTY = Stks[i].QTY,
                    UN = Stks[i].UN,
                    OUT_QTY = Stks[i].QTY,
                    FIFO_NO = Stks[i].FIFO_NO,
                    STOREIN_DATE = Convert.ToDateTime(Stks[i].SDATE)
                });
                #endregion

                Trks.Add(Trk);
            }

            //產生工作檔
            result = SubmitCreateWcsTrk(Trks);
            return result;
        }

        /// <summary>
        /// 產生先入品出庫工作檔
        /// </summary>
        /// <param name="BinStas">先入品庫格資料集</param>
        /// <param name="DevNo">出庫站台編號</param>
        /// <returns></returns>
        public vPublic.DBExecResult CreateUnknownStkOut(List<Model.WmsBinSta> BinStas, string DevNo)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            if (BinStas == null)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0013") }; //參數BinStas不可為null

            if (BinStas.Count <= 0)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0014") }; //參數BinStas筆數為0, 不需出庫

            
            #region 庫位檢查(檢查是否允許出庫)

            //取當前庫存資料
            Service.WmsBinstaService BinstaService = new WMS.Service.WmsBinstaService();
            
            List<Model.WmsBinSta> CurBinStas = new List<WmsBinSta>();
            var BinStaResult = BinstaService.GetAllWmsBinstaList("", "", null, ref CurBinStas);
            if (!BinStaResult.Successed)
                return BinStaResult;

            foreach (var Binsta in BinStas)
            {
                var CurBinSta = CurBinStas
                    .Where(o => o.AREA_NO == Binsta.AREA_NO &&
                        o.WH_NO == Binsta.WH_NO &&
                        o.ASRS_ID == Binsta.ASRS_ID &&
                        o.BIN_NO == Binsta.BIN_NO &&
                        o.SD == Binsta.SD
                    ).FirstOrDefault();

                if (CurBinSta == null)
                    return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0007") }; //選取的庫存資料已被異動，請重新查詢確認

                if (CurBinSta.BIN_STA != "P")
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RM.GetString("Msg0015"), CurBinSta.BIN_NO, CurBinSta.BIN_STA_DESC) }; //庫位:{0}, 庫存狀態:{1}, 非先入品庫存, 請重新查詢確認
            }

            #endregion

            List<WcsTrk> Trks = new List<WcsTrk>();

            for (int i = 0; i < BinStas.Count; i++)
            {
                WcsTrk Trk = new WcsTrk();

                Trk.AREA_NO = vPublic.AsrsDefine.AREA_NO;
                Trk.WH_NO = vPublic.AsrsDefine.WH_NO;
                Trk.ASRS_ID = Convert.ToInt16(BinStas[i].ASRS_ID);

                Boolean SameBinNo = false;
                SameBinNo = Trks.Select(o => o.AREA_NO == BinStas[i].AREA_NO &&
                    o.WH_NO == BinStas[i].WH_NO &&
                    o.ASRS_ID == Convert.ToInt16(BinStas[i].ASRS_ID) &&
                    o.BIN_NO == BinStas[i].BIN_NO
                    ).FirstOrDefault();

                if (SameBinNo) continue;

                #region 取序號、作業時間
                int SerNo = 0;
                var SerNoResult = GenSerNo(ref SerNo);
                if (SerNoResult.Successed == false)
                {
                    result = SerNoResult;
                    break;
                }

                Trk.SER_NO = SerNo;

                var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
                if (CreateDateResult.Successed == false)
                {
                    result = CreateDateResult;
                    break;
                }

                Trk.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

                #endregion

                Trk.USE_CRN_ID = BinStas[i].CRN_ID;//吊車
                Trk.BIN_NO = BinStas[i].BIN_NO;    //庫位
                Trk.SD = BinStas[i].SD;            //庫位深淺
                Trk.DEV_NO = DevNo;             //站台編號
                Trk.IO = IO_O;                  //IO
                Trk.OPN = TrkOPN.OPN203;        //作業別
                Trk.STEP = TrkStep.Step0;       //作業步驟
                Trk.STATUS = 0;                 //作業狀態
                Trk.EMERGE = TrkEmerge.Normal;  //緊急程度(一般)

                #region 工作檔明細資料
                Trk.Details = new List<WcsTrkDet>();
                Trk.Details.Add(new WcsTrkDet(Trk.SER_NO, Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.CREATE_DATE, Trk.CREATE_BY)
                {
                    TRK_COUNT = 1,
                    PROD_NO = "Unknown",
                    QTY = 1,
                    UN = "PCS",
                    OUT_QTY = 1,
                    FIFO_NO = "",
                    STOREIN_DATE = null
                });
                #endregion

                Trks.Add(Trk);
            }

            //產生工作檔
            result = SubmitCreateWcsTrk(Trks);
            return result;
        }

        /// <summary>
        /// 產生庫存出庫作業
        /// </summary>
        /// <param name="Stks">要出庫的庫存資料集</param>
        /// <param name="DevNo">出庫站台編號</param>
        /// <returns></returns>
        public vPublic.DBExecResult CreateStkOut(List<Model.WmsStk> Stks, string DevNo)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            if (Stks == null)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0004") }; //參數Stks不可為null

            if (Stks.Count <= 0)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0005") }; //參數Stks筆數為0, 不需出庫


            //if (string.IsNullOrEmpty(DevNo))
            //    return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0006") }; //參數出庫站台編號(DevNo) 為空值，不可出庫。

            #region 庫位檢查(檢查是否允許出庫)

            //取當前庫存資料
            Model.WmsStk StkLib = new WmsStk();
            List<Model.WmsStk> CurStks = new List<WmsStk>();
            var StkResult = StkLib.GetAllWmsStk(Convert.ToInt16(Stks.First().ASRS_ID), ref CurStks);
            if (!StkResult.Successed)
                return StkResult;

            foreach (var Stk in Stks)
            {
                var CurStk = CurStks
                    .Where(o => o.FIFO_NO == Stk.FIFO_NO).FirstOrDefault();

                if (CurStk == null)
                    return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0007") }; //選取的庫存資料已被異動，請重新查詢確認

                if (CurStk.STUS_CTR != Convert.ToDecimal(WmsStk.StusCtr.可用庫存))
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RM.GetString("Msg0008"), CurStk.BIN_NO, CurStk.STUS_CTR_DESC) }; //庫位:{0}, 庫存狀態:{1}, 非在庫庫存, 請重新查詢確認
            }

            #endregion

            List<WcsTrk> Trks = new List<WcsTrk>();

            //List<string> DevNos = new List<string>() { "1001", "1007" };
            int DevIdx = 0;
            for (int i = 0; i < Stks.Count; i++)
            {
                WcsTrk Trk = new WcsTrk();

                Trk.AREA_NO = vPublic.AsrsDefine.AREA_NO;
                Trk.WH_NO = vPublic.AsrsDefine.WH_NO;
                Trk.ASRS_ID = Convert.ToInt16(Stks[i].ASRS_ID);

                Boolean SameBinNo = false;
                SameBinNo = Trks.Select(o => o.AREA_NO == Stks[i].AREA_NO &&
                    o.WH_NO == Stks[i].WH_NO &&
                    o.ASRS_ID == Convert.ToInt16(Stks[i].ASRS_ID) &&
                    o.BIN_NO == Stks[i].BIN_NO
                    ).FirstOrDefault();

                if (SameBinNo) continue;

                #region 取序號、作業時間
                int SerNo = 0;
                var SerNoResult = GenSerNo(ref SerNo);
                if (SerNoResult.Successed == false)
                {
                    result = SerNoResult;
                    break;
                }

                Trk.SER_NO = SerNo;

                var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
                if (CreateDateResult.Successed == false)
                {
                    result = CreateDateResult;
                    break;
                }

                Trk.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

                #endregion

                Trk.USE_CRN_ID = Stks[i].CRN_ID;//吊車
                Trk.BIN_NO = Stks[i].BIN_NO;    //庫位
                Trk.SD = Stks[i].SD;            //庫位深淺

                //出庫站台編號
                if (!string.IsNullOrEmpty(DevNo))
                    Trk.DEV_NO = DevNo;       
                else
                {
                    Trk.DEV_NO = DevNos[DevIdx];
                    DevIdx++;
                    if (DevIdx > 1)
                        DevIdx = 0;
                }
                Trk.IO = IO_O;                  //IO
                Trk.OPN = TrkOPN.OPN201;        //作業別(出庫作業)
                Trk.STEP = TrkStep.Step0;       //作業步驟
                Trk.STATUS = 0;                 //作業狀態
                Trk.EMERGE = TrkEmerge.Normal;  //緊急程度(一般)

                #region 工作檔明細資料
                Trk.Details = new List<WcsTrkDet>();
                var BinNoStks = CurStks.Where(o => o.AREA_NO == Trk.AREA_NO && o.WH_NO == Trk.WH_NO && o.ASRS_ID == Trk.ASRS_ID && o.BIN_NO == Trk.BIN_NO).ToList();
                int BinCount = 0;
                foreach (var BinNoStk in BinNoStks)
                {
                    BinCount++;
                    //User勾選要出庫的庫存資料
                    var UserSelectedStk = Stks.Where(o => o.FIFO_NO == BinNoStk.FIFO_NO).FirstOrDefault();

                    Trk.Details.Add(new WcsTrkDet(Trk.SER_NO, Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.CREATE_DATE, Trk.CREATE_BY)
                    {
                        TRK_COUNT = BinCount,
                        PROD_NO = BinNoStk.PROD_NO,
                        QTY = BinNoStk.QTY,
                        UN = BinNoStk.UN,
                        ORG_NO = BinNoStk.ORG_NO,
                        LIST_NO = BinNoStk.LIST_NO,
                        LOT_NO = BinNoStk.LOT_NO,
                        REMARK = BinNoStk.REMARK,
                        OUT_QTY = UserSelectedStk == null ? BinNoStk.QTY : UserSelectedStk.RES_QTY,
                        FIFO_NO = BinNoStk.FIFO_NO,
                        QC_RESULT = BinNoStk.QC_RESULT,
                        STOREIN_DATE = Convert.ToDateTime(BinNoStk.SDATE),
                        PRODUCTION_DATE = Convert.ToDateTime(BinNoStk.PDATE)
                    });
                }

                #endregion

                Trks.Add(Trk);
            }

            //產生工作檔
            result = SubmitCreateWcsTrk(Trks);
            return result;
        }

        /// <summary>
        /// 產生盤點出庫作業
        /// </summary>
        /// <param name="Stks">要出庫的庫存資料集</param>
        /// <param name="DevNo">出庫站台編號</param>
        /// <returns></returns>
        public vPublic.DBExecResult CreateStkCheckOut(List<Model.WmsStk> Stks, string DevNo)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            if (Stks == null)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0004") }; //參數Stks不可為null

            if (Stks.Count <= 0)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0005") }; //參數Stks筆數為0, 不需出庫


            //if (string.IsNullOrEmpty(DevNo))
            //    return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0006") }; //參數出庫站台編號(DevNo) 為空值，不可出庫。

            #region 庫位檢查(檢查是否允許出庫)

            //取當前庫存資料
            Model.WmsStk StkLib = new WmsStk();
            List<Model.WmsStk> CurStks = new List<WmsStk>();
            var StkResult = StkLib.GetAllWmsStk(Convert.ToInt16(Stks.First().ASRS_ID), ref CurStks);
            if (!StkResult.Successed)
                return StkResult;

            foreach (var Stk in Stks)
            {
                var CurStk = CurStks
                    .Where(o => o.FIFO_NO == Stk.FIFO_NO).FirstOrDefault();

                if (CurStk == null)
                    return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0007") }; //選取的庫存資料已被異動，請重新查詢確認

                if (CurStk.STUS_CTR != Convert.ToDecimal(WmsStk.StusCtr.可用庫存))
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RM.GetString("Msg0008"), CurStk.BIN_NO, CurStk.STUS_CTR_DESC) }; //庫位:{0}, 庫存狀態:{1}, 非在庫庫存, 請重新查詢確認
            }

            #endregion

            List<WcsTrk> Trks = new List<WcsTrk>();

            int DevIdx = 0;
            for (int i = 0; i < Stks.Count; i++)
            {
                WcsTrk Trk = new WcsTrk();

                Trk.AREA_NO = vPublic.AsrsDefine.AREA_NO;
                Trk.WH_NO = vPublic.AsrsDefine.WH_NO;
                Trk.ASRS_ID = Convert.ToInt16(Stks[i].ASRS_ID);

                Boolean SameBinNo = false;
                SameBinNo = Trks.Select(o => o.AREA_NO == Stks[i].AREA_NO &&
                    o.WH_NO == Stks[i].WH_NO &&
                    o.ASRS_ID == Convert.ToInt16(Stks[i].ASRS_ID) &&
                    o.BIN_NO == Stks[i].BIN_NO
                    ).FirstOrDefault();

                if (SameBinNo) continue;

                #region 取序號、作業時間
                int SerNo = 0;
                var SerNoResult = GenSerNo(ref SerNo);
                if (SerNoResult.Successed == false)
                {
                    result = SerNoResult;
                    break;
                }

                Trk.SER_NO = SerNo;

                var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
                if (CreateDateResult.Successed == false)
                {
                    result = CreateDateResult;
                    break;
                }

                Trk.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

                #endregion

                Trk.USE_CRN_ID = Stks[i].CRN_ID;//吊車
                Trk.BIN_NO = Stks[i].BIN_NO;    //庫位
                Trk.SD = Stks[i].SD;            //庫位深淺

                //出庫站台編號
                if (!string.IsNullOrEmpty(DevNo))
                    Trk.DEV_NO = DevNo;
                else
                {
                    Trk.DEV_NO = DevNos[DevIdx];
                    DevIdx++;
                    if (DevIdx > 1)
                        DevIdx = 0;
                }
                Trk.IO = IO_O;                  //IO
                Trk.OPN = TrkOPN.OPN301;        //作業別(盤點作業)
                Trk.STEP = TrkStep.Step0;       //作業步驟
                Trk.STATUS = 0;                 //作業狀態
                Trk.EMERGE = TrkEmerge.Normal;  //緊急程度(一般)

                #region 工作檔明細資料
                Trk.Details = new List<WcsTrkDet>();
                var BinNoStks = CurStks.Where(o => o.AREA_NO == Trk.AREA_NO && o.WH_NO == Trk.WH_NO && o.ASRS_ID == Trk.ASRS_ID && o.BIN_NO == Trk.BIN_NO).ToList();
                int BinCount = 0;
                foreach (var BinNoStk in BinNoStks)
                {
                    BinCount++;
                    
                    Trk.Details.Add(new WcsTrkDet(Trk.SER_NO, Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.CREATE_DATE, Trk.CREATE_BY)
                    {
                        TRK_COUNT = BinCount,
                        PROD_NO = BinNoStk.PROD_NO,
                        QTY = BinNoStk.QTY,
                        UN = BinNoStk.UN,
                        ORG_NO = BinNoStk.ORG_NO,
                        LIST_NO = BinNoStk.LIST_NO,
                        LOT_NO = BinNoStk.LOT_NO,
                        REMARK = BinNoStk.REMARK,
                        OUT_QTY = BinNoStk.QTY,
                        FIFO_NO = BinNoStk.FIFO_NO,
                        QC_RESULT = BinNoStk.QC_RESULT,
                        STOREIN_DATE = Convert.ToDateTime(BinNoStk.SDATE),
                        PRODUCTION_DATE = Convert.ToDateTime(BinNoStk.PDATE)
                    });
                }

                #endregion

                Trks.Add(Trk);
            }

            //產生工作檔
            result = SubmitCreateWcsTrk(Trks);
            return result;
        }

        /// <summary>
        /// 產生單據出庫工作檔
        /// </summary>
        /// <param name="OutLines"></param>
        /// <param name="DevNo"></param>
        /// <returns></returns>
        public vPublic.DBExecResult CreateWmsListOut(List<Model.WmsOutLine> OutLines, string DevNo, StoreOutStrategy _Strategy, TrkEmerge _Emerge)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };
            WmsStk StkLib = new WmsStk();
            Service.WmsListService ListService = new WMS.Service.WmsListService();
            List<WmsStk> Stks = new List<WmsStk>();
            List<WcsTrk> Trks = new List<WcsTrk>();
            int DevIdx = 0;

            #region 防呆
            if (OutLines == null)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0009") }; //參數OutLines不可為null

            if (OutLines.Count <= 0)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0010") }; //參數OutLines筆數為0, 不需出庫

            foreach (var Item in OutLines)
            {
                if (Item.OUT_QTY <= 0)
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RM.GetString("Msg0011"), Item.LIST_NO, Item.LINE_ID) }; //選取的單號:{0}, 項次:{1}, 本次出庫量不可<=0

                Item.STK_QTY = ListService.GetStkQty(Item.PROD_NO, Item.LOT_NO, Item.PRODUCTION_DATE, Item.ORG_NO);

                if (Item.OUT_QTY > Item.STK_QTY)
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RM.GetString("Msg0012"), Item.LIST_NO, Item.LINE_ID) }; //選取的單號:{0}, 項次:{1}, 可用庫存不足
                
            }

            #endregion

            //取庫存
            result = StkLib.GetAllWmsStk(vPublic.AsrsDefine.ASRS_ID, ref Stks);
            if(result.Successed==false)
                return result;

            Stks = Stks.Where(o => o.PROD_TYPE == WmsStk.ProdType.成品_原物料 && o.STUS_CTR == Convert.ToDecimal(WmsStk.StusCtr.可用庫存)).ToList();

            //result = GenWmsListOutTrks(StoreOutStrategy.先進先出, Stks, OutLines, DEV_NO, TrkEmerge.Normal);

            return GenWmsListOutTrks(_Strategy, Stks, OutLines, DEV_NO, _Emerge);
        }

        /// <summary>
        /// 產生單據入庫工作檔
        /// </summary>
        /// <param name="OutLines"></param>
        /// <param name="DevNo"></param>
        /// <returns></returns>
        public vPublic.DBExecResult CreateWmsListIn(int? ASRS_ID, List<Model.WmsInLine> InLines, string DevNo, StoreInCreateType _Strategy, TrkEmerge _Emerge)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };
            WmsStk StkLib = new WmsStk();
            Service.WmsListService ListService = new WMS.Service.WmsListService();
            Service.WmsBinstaService BinStaService = new WMS.Service.WmsBinstaService();
            List<WmsStk> Stks = new List<WmsStk>();
            WcsTrk Trk = new WcsTrk();
            List<WcsTrk> Trks = new List<WcsTrk>();
            int DevIdx = 0;

            #region 防呆
            if (InLines == null)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0016") }; //參數InLines不可為null

            if (InLines.Count <= 0)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0017") }; //參數InLines筆數為0, 不需入庫

            if (string.IsNullOrEmpty(DevNo))
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0003") }; //參數DevNo(站台編號)不可為空值

            foreach (var Item in InLines)
            {
                if (Item.IN_QTY <= 0)
                    return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RM.GetString("Msg0018"), Item.LIST_NO, Item.LINE_ID) }; //選取的單號:{0}, 項次:{1}, 入庫量不可<=0                
            }

            #endregion
            
            #region 依據入庫派令類型產生入庫工作檔

            switch (_Strategy)
            {
                case StoreInCreateType.單板入庫:
                    Trk = new WcsTrk();
                    Trk.AREA_NO = vPublic.AsrsDefine.AREA_NO;
                    Trk.WH_NO = vPublic.AsrsDefine.WH_NO;
                    Trk.ASRS_ID = ASRS_ID.Value;
                    Trk.CREATE_BY = Program.wmsUser.UserNo;

                    #region 取序號、作業時間
                    int SerNo = 0;
                    var SerNoResult = GenSerNo(ref SerNo);
                    if (SerNoResult.Successed == false)
                    {
                        result = SerNoResult;
                        return result;
                    }

                    Trk.SER_NO = SerNo;

                    var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
                    if (CreateDateResult.Successed == false)
                    {
                        result = CreateDateResult;
                        return result;
                    }

                    Trk.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

                    #endregion

                    #region 取空庫位
                    string BinNo = string.Empty, SD = string.Empty;
                    var GenEmptyBinResult = GenEmptyBinNo(Trk.ASRS_ID, 0, "", ref BinNo, ref SD);
                    if (GenEmptyBinResult.Successed == false)
                    {
                        result = GenEmptyBinResult;
                        return result;
                    }
                    Trk.BIN_NO = BinNo;
                    Trk.SD = SD;
                    result = BinStaService.GetBinDataByBinNo(Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.BIN_NO);
                    if (result.Successed == false)
                    {
                        return result;
                    }

                    Trk.USE_CRN_ID = ((List<Model.WmsBinSta>)result.Data).First().CRN_ID;
                    
                    #endregion

                    Trk.DEV_NO = DevNo;             //站台編號
                    Trk.IO = IO_I;                  //IO
                    Trk.OPN = TrkOPN.OPN101;        //作業別
                    Trk.STEP = TrkStep.Step0;       //作業步驟
                    Trk.STATUS = 0;                 //作業狀態
                    Trk.EMERGE = _Emerge;           //緊急程度(User前端輸入)

                    #region 工作檔明細資料

                    Trk.Details = new List<WcsTrkDet>();
                    Trk.Details = InLines.Select(o => new WcsTrkDet(Trk.SER_NO, Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.CREATE_DATE, Trk.CREATE_BY)
                    {
                        TRK_COUNT = InLines.IndexOf(o) + 1,
                        PROD_NO = o.PROD_NO,
                        PRODUCTION_DATE = o.PRODUCTION_DATE,
                        LOT_NO = o.LOT_NO,
                        ORG_NO = o.ORG_NO,
                        LIST_NO = o.LIST_NO,
                        LINE_ID = o.LINE_ID,
                        QTY = o.IN_QTY,
                        OUT_QTY = 0,
                        QC_RESULT = Model.WmsStk.QCResult.未檢,
                        REMARK = o.REMARK,
                        UN = o.UN
                    }).ToList();

                    #endregion

                    Trks.Add(Trk);

                    break;
                case StoreInCreateType.批次入庫:
                    
                    //產生批次入庫工作檔物件
                    Trks = GetStoreInTrkByWmsInLine(InLines, ASRS_ID, DevNo, _Strategy, _Emerge);
                    break;
                default:
                    break;
            }

            #endregion

            return SubmitCreateWcsTrk(Trks);
        }

        public List<WcsTrk> GetStoreInTrkByWmsInLine(List<Model.WmsInLine> Data, int? ASRS_ID, string DevNo , StoreInCreateType _Strategy, TrkEmerge _Emerge)
        {
            List<WcsTrk> Trks = new List<WcsTrk>();
            Service.WmsBinstaService BinStaService = new WMS.Service.WmsBinstaService();

            CurCreateTrk:
            WcsTrk result = new WcsTrk();
            result.AREA_NO = vPublic.AsrsDefine.AREA_NO;
            result.WH_NO = vPublic.AsrsDefine.WH_NO;
            result.ASRS_ID = ASRS_ID.Value;
            result.CREATE_BY = Program.wmsUser.UserNo;

            #region 取序號、作業時間
            int SerNo = 0;
            var SerNoResult = GenSerNo(ref SerNo);
            if (SerNoResult.Successed == false)
            {
                goto CurCreateTrk;
            }

            result.SER_NO = SerNo;

            var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
            if (CreateDateResult.Successed == false)
            {
                goto CurCreateTrk;
            }

            result.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

            #endregion

            #region 取空庫位
            string BinNo = string.Empty, SD = string.Empty;
            var GenEmptyBinResult = GenEmptyBinNo(result.ASRS_ID, 0, "", ref BinNo, ref SD);
            if (GenEmptyBinResult.Successed == false)
            {
                goto CurCreateTrk;
            }
            result.BIN_NO = BinNo;
            result.SD = SD;
            var GetBinDataResult = BinStaService.GetBinDataByBinNo(result.AREA_NO, result.WH_NO, result.ASRS_ID, result.BIN_NO);
            if (GetBinDataResult.Successed == false)
            {
                goto CurCreateTrk;
            }

            result.USE_CRN_ID = ((List<Model.WmsBinSta>)GetBinDataResult.Data).First().CRN_ID;

            #endregion

            result.DEV_NO = DevNo;             //站台編號
            result.IO = IO_I;                  //IO
            result.OPN = TrkOPN.OPN101;        //作業別
            result.STEP = TrkStep.Step0;       //作業步驟
            result.STATUS = 0;                 //作業狀態
            result.EMERGE = _Emerge;           //緊急程度(User前端輸入)

            #region 工作檔明細資料

            result.Details = new List<WcsTrkDet>();
            result.Details = Data
                            .Where(o => o.QTY - o.TMP_QTY > 0)
                            .Select(o => new WcsTrkDet(result.SER_NO, result.AREA_NO, result.WH_NO, result.ASRS_ID, result.CREATE_DATE, result.CREATE_BY)
            {
                TRK_COUNT = Data.IndexOf(o) + 1,
                PROD_NO = o.PROD_NO,
                PRODUCTION_DATE = o.PRODUCTION_DATE,
                LOT_NO = o.LOT_NO,
                ORG_NO = o.ORG_NO,
                LIST_NO = o.LIST_NO,
                LINE_ID = o.LINE_ID,
                QTY = o.IN_QTY,
                OUT_QTY = 0,
                QC_RESULT = Model.WmsStk.QCResult.未檢,
                REMARK = o.REMARK,
                UN = o.UN
            }).ToList();

            #endregion

            Trks.Add(result);

            //累加作業中數量、重新計算入庫量
            Data = Data.Select(o => { o.TMP_QTY = o.TMP_QTY + o.IN_QTY; return o; }).ToList();
            Data = Data.Select(o => { o.IN_QTY = o.QTY - o.TMP_QTY > o.IN_QTY ? o.IN_QTY : o.QTY - o.TMP_QTY; return o; }).ToList();

            var SumTmpQty = Data.Sum(o => o.TMP_QTY);
            var SumQty = Data.Sum(o => o.QTY);

            if (SumQty - SumTmpQty > 0)
                goto CurCreateTrk;

            return Trks;
        }

        /// <summary>
        /// 依據選取的出庫策略產生工作檔物件
        /// </summary>
        /// <param name="_Strategy"></param>
        /// <returns></returns>
        private vPublic.DBExecResult GenWmsListOutTrks(StoreOutStrategy _Strategy, List<Model.WmsStk> Stks, List<Model.WmsOutLine> OutLines, string DevNo, TrkEmerge Emerge)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };
            List<WcsTrk> Trks = new List<WcsTrk>();
            int DevIdx = 0;

            switch (_Strategy)
            {
                case StoreOutStrategy.最少板數:

                    List<WmsStkOrder> StkOrder = new List<WmsStkOrder>();

                    foreach (var Item in OutLines)
                    {
                        var AvailableStk = Stks.Where(o => o.PROD_TYPE == WmsStk.ProdType.成品_原物料
                                                      && o.PROD_NO == Item.PROD_NO
                                                      && (o.LOT_NO ?? string.Empty) == (Item.LOT_NO ?? string.Empty)
                                                      && (o.PRODUCTION_DATE ?? null) == (Item.PRODUCTION_DATE ?? null)
                                                      && o.QTY - o.RES_QTY > 0
                                                      )
                                                      .OrderBy(o => o.PRODUCTION_DATE)
                                                      .ThenBy(o => o.STOREIN_DATE)
                                                      .ToList();

                        foreach (var Stk in AvailableStk)
                        {
                            //預約數量
                            if (Stk.QTY > Item.OUT_QTY)
                            {
                                Stk.RES_QTY = Item.OUT_QTY;
                                Item.OUT_QTY = Item.OUT_QTY - Stk.RES_QTY;
                            }
                            else if (Stk.QTY <= Item.OUT_QTY)
                            {
                                Stk.RES_QTY = Stk.QTY;
                                Item.OUT_QTY = Item.OUT_QTY - Stk.RES_QTY;
                            }

                            //預約單據、項次(寫入StkOrder)
                            StkOrder.Add(new WmsStkOrder()
                            {
                                AREA_NO = Stk.AREA_NO,
                                WH_NO = Stk.WH_NO,
                                ASRS_ID = Stk.ASRS_ID,
                                BIN_NO = Stk.BIN_NO,
                                SD = Stk.SD,
                                LIST_NO = Item.LIST_NO,
                                LINE_ID = Item.LINE_ID,
                                FIFO_NO = Stk.FIFO_NO,
                                PROD_NO = Stk.PROD_NO,
                                LOT_NO = Stk.LOT_NO,
                                ORG_NO = Stk.ORG_NO,
                                PROD_TYPE = Stk.PROD_TYPE,
                                STUS_CTR = (WmsStk.StusCtr)Enum.ToObject(typeof(WmsStk.StusCtr), Convert.ToInt16(Stk.STUS_CTR)),
                                QC_RESULT = (WmsStk.QCResult)Enum.ToObject(typeof(WmsStk.QCResult), Convert.ToInt16(Stk.QC_RESULT)),
                                QTY = Stk.RES_QTY,
                                RES_QTY = Stk.RES_QTY,
                                STOREIN_DATE = Stk.STOREIN_DATE,
                                PRODUCTION_DATE = Stk.PRODUCTION_DATE,
                                UN = Stk.UN,
                                REMARK = Stk.REMARK
                            });

                            if (Item.OUT_QTY <= 0)
                                break;
                        }

                        //單據出庫數量>0
                        if (Item.OUT_QTY > 0)
                            return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RM.GetString("Msg0012"), Item.LIST_NO, Item.LINE_ID) }; //選取的單號:{0}, 項次:{1}, 可用庫存不足
                    }

                    foreach (var Stk in Stks)
                    {
                        var TotalResQty = StkOrder
                            .Where(o => o.FIFO_NO == Stk.FIFO_NO && Stk.RES_QTY > 0)
                            .Sum(o => o.RES_QTY);

                        if (TotalResQty <= 0) continue;
                        //寫入餘料StkOrder
                        if (TotalResQty < Stk.QTY)
                        {
                            StkOrder.Add(new WmsStkOrder()
                            {
                                AREA_NO = Stk.AREA_NO,
                                WH_NO = Stk.WH_NO,
                                ASRS_ID = Stk.ASRS_ID,
                                BIN_NO = Stk.BIN_NO,
                                SD = Stk.SD,
                                LIST_NO = "",
                                LINE_ID = 0,
                                FIFO_NO = Stk.FIFO_NO,
                                PROD_NO = Stk.PROD_NO,
                                LOT_NO = Stk.LOT_NO,
                                ORG_NO = Stk.ORG_NO,
                                PROD_TYPE = Stk.PROD_TYPE,
                                STUS_CTR = (WmsStk.StusCtr)Enum.ToObject(typeof(WmsStk.StusCtr), Convert.ToInt16(Stk.STUS_CTR)),
                                QC_RESULT = (WmsStk.QCResult)Enum.ToObject(typeof(WmsStk.QCResult), Convert.ToInt16(Stk.QC_RESULT)),
                                QTY = Stk.QTY - TotalResQty,
                                RES_QTY = 0,
                                STOREIN_DATE = Stk.STOREIN_DATE,
                                PRODUCTION_DATE = Stk.PRODUCTION_DATE,
                                UN = Stk.UN,
                                REMARK = Stk.REMARK
                            });
                        }
                    }

                    var StkOrders = StkOrder
                        .GroupBy(o => new
                        {
                            WhNo = o.WH_NO,
                            AreaNo = o.AREA_NO,
                            AsrsID = o.ASRS_ID,
                            BinNo = o.BIN_NO,
                            SD = o.SD,
                            CrnID = o.CRN_ID
                        })
                        .Select(o => new
                        {
                            WhNo = o.Key.WhNo,
                            AreaNo = o.Key.AreaNo,
                            AsrsID = o.Key.AsrsID,
                            BinNo = o.Key.BinNo.ToString(),
                            SD = o.Key.SD,
                            CrnID = o.Key.CrnID
                        })
                        .ToList();

                    foreach (var BinNo in StkOrders)
                    {
                        WcsTrk Trk = new WcsTrk();

                        Trk.AREA_NO = BinNo.AreaNo;
                        Trk.WH_NO = BinNo.WhNo;
                        Trk.ASRS_ID = Convert.ToInt16(BinNo.AsrsID);

                        #region 取序號、作業時間
                        int SerNo = 0;
                        var SerNoResult = GenSerNo(ref SerNo);
                        if (SerNoResult.Successed == false)
                        {
                            result = SerNoResult;
                            break;
                        }

                        Trk.SER_NO = SerNo;

                        var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
                        if (CreateDateResult.Successed == false)
                        {
                            result = CreateDateResult;
                            break;
                        }

                        Trk.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

                        #endregion

                        Trk.USE_CRN_ID = BinNo.CrnID;
                        Trk.BIN_NO = BinNo.BinNo;
                        Trk.SD = BinNo.SD;
                        //出庫站台編號
                        if (!string.IsNullOrEmpty(DevNo))
                            Trk.DEV_NO = DevNo;
                        else
                        {
                            Trk.DEV_NO = DevNos[DevIdx];
                            DevIdx++;
                            if (DevIdx > 1)
                                DevIdx = 0;
                        }

                        Trk.IO = IO_O;
                        Trk.OPN = TrkOPN.OPN201;
                        Trk.STEP = TrkStep.Step0;
                        Trk.STATUS = 0;
                        Trk.EMERGE = Emerge;

                        #region 工作檔明細資料
                        Trk.Details = new List<WcsTrkDet>();
                        var BinNoStks = StkOrder.Where(o => o.AREA_NO == Trk.AREA_NO && o.WH_NO == Trk.WH_NO && o.ASRS_ID == Trk.ASRS_ID && o.BIN_NO == Trk.BIN_NO).ToList();
                        int BinCount = 0;
                        foreach (var BinNoStk in BinNoStks)
                        {
                            BinCount++;

                            Trk.Details.Add(new WcsTrkDet(Trk.SER_NO, Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.CREATE_DATE, Trk.CREATE_BY)
                            {
                                TRK_COUNT = BinCount,
                                PROD_NO = BinNoStk.PROD_NO,
                                QTY = BinNoStk.QTY,
                                UN = BinNoStk.UN,
                                ORG_NO = BinNoStk.ORG_NO,
                                LIST_NO = BinNoStk.LIST_NO,
                                LINE_ID = BinNoStk.LINE_ID,
                                LOT_NO = BinNoStk.LOT_NO,
                                REMARK = BinNoStk.REMARK,
                                OUT_QTY = BinNoStk.RES_QTY,
                                FIFO_NO = BinNoStk.FIFO_NO,
                                STOREIN_DATE = BinNoStk.STOREIN_DATE,
                                PRODUCTION_DATE = BinNoStk.PRODUCTION_DATE,
                                QC_RESULT = BinNoStk.QC_RESULT
                            });
                        }

                        #endregion

                        Trks.Add(Trk);
                    }

                    break;
                case StoreOutStrategy.先進先出:
                    
                    foreach (var Item in OutLines)
                    {
                        var AvailableStk = Stks.Where(o => o.PROD_TYPE == WmsStk.ProdType.成品_原物料
                                                      && o.PROD_NO == Item.PROD_NO
                                                      && (o.LOT_NO ?? string.Empty) == (Item.LOT_NO ?? string.Empty)
                                                      && (o.PRODUCTION_DATE ?? null) == (Item.PRODUCTION_DATE ?? null)
                                                      && o.RES_QTY == 0
                                                      )
                                                      .OrderBy(o => o.PRODUCTION_DATE)
                                                      .ThenBy(o => o.STOREIN_DATE)
                                                      .ToList();

                        foreach (var Stk in AvailableStk)
                        {
                            //預約數量
                            if (Stk.QTY > Item.OUT_QTY)
                            {
                                Stk.RES_QTY = Item.OUT_QTY;
                                Item.OUT_QTY = Item.OUT_QTY - Stk.RES_QTY;
                            }
                            else if(Stk.QTY<= Item.OUT_QTY)
                            {
                                Stk.RES_QTY = Stk.QTY;
                                Item.OUT_QTY = Item.OUT_QTY - Stk.RES_QTY;
                            }

                            //預約單據、項次
                            Stk.LIST_NO = Item.LIST_NO;
                            Stk.LINE_ID = Item.LINE_ID;

                            if (Item.OUT_QTY <= 0)
                                break;
                        }
                        
                        //單據出庫數量>0
                        if (Item.OUT_QTY > 0)
                            return new vPublic.DBExecResult() { Successed = false, Message = string.Format(RM.GetString("Msg0012"), Item.LIST_NO, Item.LINE_ID) }; //選取的單號:{0}, 項次:{1}, 可用庫存不足
                    }

                    var OrderBinNos = Stks
                        .Where(o => o.RES_QTY > 0 && !string.IsNullOrEmpty(o.LIST_NO))
                        .GroupBy(o => new
                        {
                            WhNo = o.WH_NO,
                            AreaNo = o.AREA_NO,
                            AsrsID = o.ASRS_ID,
                            BinNo = o.BIN_NO,
                            SD = o.SD,
                            CrnID = o.CRN_ID
                        })
                        .Select(o => new
                        {
                            WhNo = o.Key.WhNo,
                            AreaNo = o.Key.AreaNo,
                            AsrsID = o.Key.AsrsID,
                            BinNo = o.Key.BinNo.ToString(),
                            SD = o.Key.SD,
                            CrnID = o.Key.CrnID
                        })
                        .ToList();

                    foreach (var BinNo in OrderBinNos)
                    {
                        WcsTrk Trk = new WcsTrk();

                        Trk.AREA_NO = BinNo.AreaNo;
                        Trk.WH_NO = BinNo.WhNo;
                        Trk.ASRS_ID = Convert.ToInt16(BinNo.AsrsID);

                        #region 取序號、作業時間
                        int SerNo = 0;
                        var SerNoResult = GenSerNo(ref SerNo);
                        if (SerNoResult.Successed == false)
                        {
                            result = SerNoResult;
                            break;
                        }

                        Trk.SER_NO = SerNo;

                        var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
                        if (CreateDateResult.Successed == false)
                        {
                            result = CreateDateResult;
                            break;
                        }

                        Trk.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

                        #endregion

                        Trk.USE_CRN_ID = BinNo.CrnID;
                        Trk.BIN_NO = BinNo.BinNo;
                        Trk.SD = BinNo.SD;
                        //出庫站台編號
                        if (!string.IsNullOrEmpty(DevNo))
                            Trk.DEV_NO = DevNo;
                        else
                        {
                            Trk.DEV_NO = DevNos[DevIdx];
                            DevIdx++;
                            if (DevIdx > 1)
                                DevIdx = 0;
                        }

                        Trk.IO = IO_O;
                        Trk.OPN = TrkOPN.OPN201;
                        Trk.STEP = TrkStep.Step0;
                        Trk.STATUS = 0;
                        Trk.EMERGE = Emerge;

                        #region 工作檔明細資料
                        Trk.Details = new List<WcsTrkDet>();
                        var BinNoStks = Stks.Where(o => o.AREA_NO == Trk.AREA_NO && o.WH_NO == Trk.WH_NO && o.ASRS_ID == Trk.ASRS_ID && o.BIN_NO == Trk.BIN_NO).ToList();
                        int BinCount = 0;
                        foreach (var BinNoStk in BinNoStks)
                        {
                            BinCount++;

                            Trk.Details.Add(new WcsTrkDet(Trk.SER_NO, Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.CREATE_DATE, Trk.CREATE_BY)
                            {
                                TRK_COUNT = BinCount,
                                PROD_NO = BinNoStk.PROD_NO,
                                QTY = BinNoStk.QTY,
                                UN = BinNoStk.UN,
                                ORG_NO = BinNoStk.ORG_NO,
                                LIST_NO = BinNoStk.LIST_NO,
                                LINE_ID = BinNoStk.LINE_ID,
                                LOT_NO = BinNoStk.LOT_NO,
                                REMARK = BinNoStk.REMARK,
                                OUT_QTY = BinNoStk.RES_QTY,
                                FIFO_NO = BinNoStk.FIFO_NO,
                                STOREIN_DATE = Convert.ToDateTime(BinNoStk.SDATE),
                                PRODUCTION_DATE = Convert.ToDateTime(BinNoStk.PDATE),
                                QC_RESULT = BinNoStk.QC_RESULT
                            });
                        }

                        #endregion

                        Trks.Add(Trk);
                    }
                    break;
                default:
                    break;
            }

            return SubmitCreateWcsTrk(Trks);
        }

        /// <summary>
        /// 產生空棧板入庫工作檔
        /// </summary>
        /// <param name="CrnID">吊車編號, 不傳的話自動取吊車編號</param>
        /// <param name="Count">派令板數</param>
        /// <param name="PalletQty">棧板堆疊數量</param>
        /// <returns></returns>
        public vPublic.DBExecResult CreateEmptyPalletIn(int AsrsID, string DevNo, int? CrnID, decimal? Count, decimal PalletQty)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = "" };

            if (AsrsID <= 0)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0001") }; //參數AsrsID為不合法的ASRS_ID(需>0)

            if (Count == null)
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0002") }; //入庫板數不可為空值

            if (string.IsNullOrEmpty(DevNo))
                return new vPublic.DBExecResult() { Successed = false, Message = RM.GetString("Msg0003") }; //參數DevNo(站台編號)不可為空值

            List<WcsTrk> Trks = new List<WcsTrk>();

            for (int i = 1; i <= Count; i++)
            {
                WcsTrk Trk = new WcsTrk();

                Trk.AREA_NO = vPublic.AsrsDefine.AREA_NO;
                Trk.WH_NO = vPublic.AsrsDefine.WH_NO;
                Trk.ASRS_ID = AsrsID;

                #region 取序號、作業時間
                int SerNo = 0;
                var SerNoResult = GenSerNo(ref SerNo);
                if (SerNoResult.Successed == false)
                {
                    result = SerNoResult;
                    break;
                }

                Trk.SER_NO = SerNo;

                var CreateDateResult = vPublic.GetDbData("select getdate() ", new List<vPublic.DBParameter>());
                if (CreateDateResult.Successed == false)
                {
                    result = CreateDateResult;
                    break;
                }

                Trk.CREATE_DATE = Convert.ToDateTime(CreateDateResult.ResultDt.Rows[0][0].ToString());

                #endregion

                #region 取吊車
                if (CrnID == null)
                {
                    //山東信發案 空棧板只入1~3號車
                    Trk.USE_CRN_ID = i % 3 == 0 ? 3 : i % 3;
                }
                else
                    Trk.USE_CRN_ID = CrnID.Value;
                #endregion

                #region 取空庫位
                string BinNo = string.Empty, SD = string.Empty;
                var GenEmptyBinResult = GenEmptyBinNo(Trk.ASRS_ID, Trk.USE_CRN_ID, "", ref BinNo, ref SD);
                if (GenEmptyBinResult.Successed == false)
                {
                    result = GenEmptyBinResult;
                    break;
                }
                Trk.BIN_NO = BinNo;
                Trk.SD = SD;
                #endregion

                Trk.DEV_NO = DevNo;             //站台編號
                Trk.IO = IO_I;                  //IO
                Trk.OPN = TrkOPN.OPN102;        //作業別
                Trk.STEP = TrkStep.Step0;       //作業步驟
                Trk.STATUS = 0;                 //作業狀態
                Trk.EMERGE = TrkEmerge.Normal;  //緊急程度(一般)

                #region 工作檔明細資料
                Trk.Details = new List<WcsTrkDet>();
                Trk.Details.Add(new WcsTrkDet(Trk.SER_NO, Trk.AREA_NO, Trk.WH_NO, Trk.ASRS_ID, Trk.CREATE_DATE, Trk.CREATE_BY)
                {
                    TRK_COUNT = 1,
                    PROD_NO = vPublic.SystemProdNo.EmptyPallet,
                    QTY = PalletQty,
                    UN = "PCS",
                    OUT_QTY = 0,
                    STOREIN_DATE = Trk.CREATE_DATE
                });
                #endregion

                Trks.Add(Trk);
            }

            //產生工作檔
            result = SubmitCreateWcsTrk(Trks);
            return result;
        }

        /// <summary>
        /// 產生工作檔
        /// </summary>
        /// <returns></returns>
        private vPublic.DBExecResult SubmitCreateWcsTrk(List<WcsTrk> Trks)
        {
            vPublic.DBExecResult result = new vPublic.DBExecResult() { Successed = true, Message = RM.GetString("SubmitOK") };

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

                    foreach (var Trk in Trks)
                    {
                        string BIN_STA = string.Empty;
                        //儲位主檔更新為預約入或出
                        if (Trk.IO == IO_I)
                            BIN_STA = "I";
                        else if (Trk.IO == IO_O)
                            BIN_STA = "O";

                        strSql = "update WMS_BINSTA set BIN_STA = @BIN_STA "+
                                 "where AREA_NO = @AREA_NO "+
                                 "and WH_NO = @WH_NO "+
                                 "and ASRS_ID = @ASRS_ID " +
                                 "and BIN_NO = @BIN_NO " +
                                 "and SD = @SD " +
                                 "";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("BIN_STA", BIN_STA);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Trk.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Trk.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Trk.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Trk.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SD", (object)Trk.SD ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        strSql = "insert into WCS_TRK ( SER_NO, AREA_NO, WH_NO, ASRS_ID, BIN_NO, SD, SHF_NO, SHF_SD, DEV_NO, CUR_DEV_NO, "+ "\r\n" +
                                 "                      NEXT_DEV_NO, TRANS_DEV_NO, IO, STEP, STATUS, OPN, USE_CRN_ID, EMERGE, WEIGHT, SIZE_CHK, " + "\r\n" +
                                 "                      BIN_TYPE, KIND, START_TIME, END_TIME, PALLET_NO, CREATE_DATE, CREATE_BY ) " + "\r\n" +
                                 "              values(@SER_NO,@AREA_NO,@WH_NO,@ASRS_ID,@BIN_NO,@SD,@SHF_NO,@SHF_SD,@DEV_NO,@CUR_DEV_NO, " + "\r\n" +
                                 "                     @NEXT_DEV_NO,@TRANS_DEV_NO,@IO,@STEP,@STATUS,@OPN,@USE_CRN_ID,@EMERGE,@WEIGHT,@SIZE_CHK, " + "\r\n" +
                                 "                     @BIN_TYPE,@KIND,@START_TIME,@END_TIME,@PALLET_NO,@CREATE_DATE,@CREATE_BY) ";

                        Cmd.CommandText = strSql;
                        Cmd.Parameters.Clear();

                        Cmd.Parameters.AddWithValue("SER_NO", (object)Trk.SER_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("AREA_NO", (object)Trk.AREA_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("WH_NO", (object)Trk.WH_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("ASRS_ID", (object)Trk.ASRS_ID ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_NO", (object)Trk.BIN_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SD", (object)Trk.SD ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SHF_NO", (object)Trk.SHF_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SHF_SD", (object)Trk.SHF_SD ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("DEV_NO", (object)Trk.DEV_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CUR_DEV_NO", (object)Trk.CUR_DEV_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("NEXT_DEV_NO", (object)Trk.NEXT_DEV_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("TRANS_DEV_NO", (object)Trk.TRANS_DEV_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("IO", (object)Trk.IO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("STEP", Convert.ToInt16(Trk.STEP));
                        Cmd.Parameters.AddWithValue("STATUS", (object)Trk.STATUS ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("OPN", Convert.ToInt16(Trk.OPN));
                        Cmd.Parameters.AddWithValue("USE_CRN_ID", (object)Trk.USE_CRN_ID ?? 0);
                        Cmd.Parameters.AddWithValue("EMERGE", Convert.ToInt16(Trk.EMERGE));
                        Cmd.Parameters.AddWithValue("WEIGHT", (object)Trk.WEIGHT ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("SIZE_CHK", (object)Trk.SIZE_CHK ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("BIN_TYPE", (object)Trk.BIN_TYPE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("KIND", (object)Trk.KIND ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("START_TIME", (object)Trk.START_TIME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("END_TIME", (object)Trk.END_TIME ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("PALLET_NO", (object)Trk.PALLET_NO ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Trk.CREATE_DATE ?? DBNull.Value);
                        Cmd.Parameters.AddWithValue("CREATE_BY", (object)Trk.CREATE_BY ?? DBNull.Value);
                        rtn = Cmd.ExecuteNonQuery();

                        foreach (var Detail in Trk.Details)
                        {
                            strSql = "insert into WCS_TRK_DET ( SER_NO, AREA_NO, WH_NO, ASRS_ID, TRK_COUNT, LIST_NO, LINE_ID, PALLET_NO, PROD_NO, LOT_NO, " + "\r\n" +
                                     "                          QTY, OUT_QTY, UN, STOREIN_DATE, PRODUCTION_DATE, REMARK, CREATE_DATE, CREATE_BY, FIFO_NO, ORG_NO, QC_RESULT ) " + "\r\n" +
                                     "                  values(@SER_NO,@AREA_NO,@WH_NO,@ASRS_ID,@TRK_COUNT,@LIST_NO,@LINE_ID,@PALLET_NO,@PROD_NO,@LOT_NO, " + "\r\n" +
                                     "                         @QTY,@OUT_QTY,@UN,@STOREIN_DATE,@PRODUCTION_DATE,@REMARK,@CREATE_DATE,@CREATE_BY,@FIFO_NO,@ORG_NO,@QC_RESULT) ";

                            Cmd.CommandText = strSql;
                            Cmd.Parameters.Clear();

                            Cmd.Parameters.AddWithValue("SER_NO", (object)Detail.SER_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("AREA_NO", (object)Detail.AREA_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("WH_NO", (object)Detail.WH_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ASRS_ID", (object)Detail.ASRS_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("TRK_COUNT", (object)Detail.TRK_COUNT ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LIST_NO", (object)Detail.LIST_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LINE_ID", (object)Detail.LINE_ID ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("PALLET_NO", (object)Detail.PALLET_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("PROD_NO", (object)Detail.PROD_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("LOT_NO", (object)Detail.LOT_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("QTY", (object)Detail.QTY ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("OUT_QTY", (object)Detail.OUT_QTY ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("UN", (object)Detail.UN ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("STOREIN_DATE", (object)Detail.STOREIN_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("PRODUCTION_DATE", (object)Detail.PRODUCTION_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("REMARK", (object)Detail.REMARK ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CREATE_DATE", (object)Detail.CREATE_DATE ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("CREATE_BY", (object)Detail.CREATE_BY ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("FIFO_NO", (object)Detail.FIFO_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("ORG_NO", (object)Detail.ORG_NO ?? DBNull.Value);
                            Cmd.Parameters.AddWithValue("QC_RESULT", (object)Detail.QC_RESULT ?? DBNull.Value);
                            rtn = Cmd.ExecuteNonQuery();

                            //庫存預約出庫
                            if (BIN_STA == IO_O)
                            {
                                strSql = "update WMS_STK set STUS_CTR = @STUS_CTR, RES_QTY = RES_QTY + @RES_QTY " +
                                         "where FIFO_NO = @FIFO_NO " +
                                         "";

                                Cmd.CommandText = strSql;
                                Cmd.Parameters.Clear();

                                Cmd.Parameters.AddWithValue("STUS_CTR", Convert.ToInt16(WmsStk.StusCtr.出庫預約));
                                Cmd.Parameters.AddWithValue("RES_QTY", (object)Detail.OUT_QTY ?? 0);
                                Cmd.Parameters.AddWithValue("FIFO_NO", (object)Detail.FIFO_NO ?? DBNull.Value);
                                
                                rtn = Cmd.ExecuteNonQuery();
                            }

                            //出庫作業 更新單據數量
                            if (Trk.OPN == TrkOPN.OPN201)
                            {
                                strSql = "update WMS_OUT_LINE set TMP_QTY = TMP_QTY + @RES_QTY, STATUS_CTR = @STATUS_CTR33 " +
                                                                        "where LIST_NO = @LIST_NO " +
                                                                        "  and LINE_ID = @LINE_ID ";

                                Cmd.CommandText = strSql;
                                Cmd.Parameters.Clear();

                                Cmd.Parameters.AddWithValue("STATUS_CTR33", Convert.ToInt16(vPublic.StatusCtr.出庫中));
                                Cmd.Parameters.AddWithValue("RES_QTY", (object)Detail.OUT_QTY ?? 0);
                                Cmd.Parameters.AddWithValue("LIST_NO", (object)Detail.LIST_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("LINE_ID", (object)Detail.LINE_ID ?? DBNull.Value);

                                rtn = Cmd.ExecuteNonQuery();
                            }

                            //入庫作業 更新單據數量
                            if (Trk.OPN == TrkOPN.OPN101)
                            {
                                strSql = "update WMS_IN_LINE set TMP_QTY = TMP_QTY + @RES_QTY, STATUS_CTR = @STATUS_CTR8 " +
                                                                "where LIST_NO = @LIST_NO " +
                                                                "  and LINE_ID = @LINE_ID ";

                                Cmd.CommandText = strSql;
                                Cmd.Parameters.Clear();

                                Cmd.Parameters.AddWithValue("STATUS_CTR8", Convert.ToInt16(vPublic.StatusCtr.收料中));
                                Cmd.Parameters.AddWithValue("RES_QTY", (object)Detail.QTY ?? 0);
                                Cmd.Parameters.AddWithValue("LIST_NO", (object)Detail.LIST_NO ?? DBNull.Value);
                                Cmd.Parameters.AddWithValue("LINE_ID", (object)Detail.LINE_ID ?? DBNull.Value);

                                rtn = Cmd.ExecuteNonQuery();
                            }
                        }
                    }

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
    }

    public class WcsTrkDet
    {
        public int SER_NO { get; set; }
        public string AREA_NO { get; set; }
        public string WH_NO { get; set; }
        public int ASRS_ID { get; set; }
        public int TRK_COUNT { get; set; }
        public string LIST_NO { get; set; }
        public int LINE_ID { get; set; }
        public string PALLET_NO { get; set; }
        public string PROD_NO { get; set; }
        public string LOT_NO { get; set; }
        public decimal QTY { get; set; }
        public decimal OUT_QTY { get; set; }
        public string UN { get; set; }
        public DateTime? STOREIN_DATE { get; set; }
        public DateTime? PRODUCTION_DATE { get; set; }
        public string REMARK { get; set; }
        public DateTime? CREATE_DATE { get; set; }
        public string CREATE_BY { get; set; }
        public string FIFO_NO { get; set; }
        public string ORG_NO { get; set; }
        public string SRC_BIN_NO { get; set; }
        public Model.WmsStk.QCResult? QC_RESULT { get; set; }

        public WcsTrkDet(int SerNo, string AreaNo, string WhNo, int AsrsID, DateTime? CreateDate, string CreateBy)
        {
            SER_NO = SerNo;
            AREA_NO = AreaNo;
            WH_NO = WhNo;
            ASRS_ID = AsrsID;
            CREATE_DATE = CreateDate;
            CREATE_BY = CreateBy;
        }
    }
}
