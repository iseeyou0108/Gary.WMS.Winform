using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WMS.Model
{
    public class WmsCycd
    {
        public enum CycdFlag
        {
            修改前 = 0,
            修改後 = 1
        }
        public enum ReplyFlag
        {
            未回報 = 0,
            已回報 = 1
        }

        /// <summary>
        /// 選取
        /// </summary>
        public bool CHK { get; set; }
        /// <summary>
        /// 盤點單號
        /// </summary>
        public string CHECK_NO { get; set; }
        /// <summary>
        /// 回報ERP旗標
        /// </summary>
        public ReplyFlag REPLY_FLG { get; set; }
        public string REPLY_FLG_DESC { get; set; }
        /// <summary>
        /// 庫存唯一值
        /// </summary>
        public string FIFO_NO { get; set; }
        /// <summary>
        /// 工廠代號
        /// </summary>
        public string AREA_NO { get; set; }
        /// <summary>
        /// 儲區
        /// </summary>
        public string WH_NO { get; set; }
        /// <summary>
        /// 倉庫代號
        /// </summary>
        public decimal ASRS_ID { get; set; }
        /// <summary>
        /// 庫位
        /// </summary>
        public string BIN_NO { get; set; }
        public string SD { get; set; }
        /// <summary>
        /// 盤點旗標
        /// 0:修改前, 1:修改後
        /// </summary>
        public CycdFlag CYCD_FLAG { get; set; }
        public string CYCD_FLAG_DESC { get; set; }
        /// <summary>
        /// 單號
        /// </summary>
        public string LIST_NO { get; set; }
        /// <summary>
        /// 單據項次
        /// </summary>
        public decimal? LINE_ID { get; set; }
        /// <summary>
        /// 托盤條碼
        /// </summary>
        public string PALLET_NO { get; set; }
        /// <summary>
        /// 料號
        /// </summary>
        public string PROD_NO { get; set; }
        /// <summary>
        /// 物料描述
        /// </summary>
        public string PROD_NAME { get; set; }
        /// <summary>
        /// 批號
        /// </summary>
        public string LOT_NO { get; set; }
        /// <summary>
        /// 客戶代號
        /// </summary>
        public string ORG_NO { get; set; }
        /// <summary>
        /// 客戶簡稱
        /// </summary>
        public string ORG_SNAME { get; set; }
        /// <summary>
        /// 數量
        /// </summary>
        public decimal QTY { get; set; }
        /// <summary>
        /// 單位
        /// </summary>
        public string UN { get; set; }
        /// <summary>
        /// 入庫日期
        /// </summary>
        public DateTime? STOREIN_DATE { get; set; }
        /// <summary>
        /// 生產/包裝日期
        /// </summary>
        public DateTime? PRODUCTION_DATE { get; set; }
        /// <summary>
        /// 質檢結果
        /// </summary>
        public Model.WmsStk.QCResult QC_RESULT { get; set; }
        public string QC_RESULT_DESC { get; set; }            
        /// <summary>
        /// 盤點日期
        /// </summary>
        public DateTime? CHECK_DATE { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string REMARK { get; set; }
        /// <summary>
        /// 建檔日期
        /// </summary>
        public DateTime? CREATE_DATE { get; set; }
        /// <summary>
        /// 建檔人員
        /// </summary>
        public string CREATE_BY { get; set; }
        /// <summary>
        /// 建檔人員姓名
        /// </summary>
        public string CREATE_NAME { get; set; }
    }
}
