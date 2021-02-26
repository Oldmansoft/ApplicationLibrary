namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 查询企业付款返回
    /// </summary>
    public class GetTransferInfoResponse : Response
    {
        /// <summary>
        /// 商户单号
        /// </summary>
        public string partner_trade_no { get; set; }

        /// <summary>
        /// Appid
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 付款单号
        /// </summary>
        public string detail_id { get; set; }

        /// <summary>
        /// 转账状态
        /// SUCCESS:转账成功
        /// FAILED:转账失败
        /// PROCESSING:处理中
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string reason { get; set; }

        /// <summary>
        /// 收款用户openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        public string transfer_name { get; set; }

        /// <summary>
        /// 付款金额
        /// </summary>
        public int payment_amount { get; set; }

        /// <summary>
        /// 转账时间
        /// </summary>
        public string transfer_time { get; set; }

        /// <summary>
        /// 付款成功时间
        /// </summary>
        public string payment_time { get; set; }

        /// <summary>
        /// 企业付款备注
        /// </summary>
        public string desc { get; set; }
    }
}
