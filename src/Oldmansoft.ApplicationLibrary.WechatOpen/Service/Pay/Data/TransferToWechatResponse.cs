namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 企业付款到零钱返回
    /// </summary>
    public class TransferToWechatResponse : Response
    {
        /// <summary>
        /// 商户appid
        /// </summary>
        public string mch_appid { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string mchid { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public string device_info { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string partner_trade_no { get; set; }

        /// <summary>
        /// 微信付款单号
        /// </summary>
        public string payment_no { get; set; }

        /// <summary>
        /// 付款成功时间
        /// </summary>
        public string payment_time { get; set; }
    }
}
