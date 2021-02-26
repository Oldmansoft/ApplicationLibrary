namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 订单查询请求
    /// </summary>
    public class OrderQueryRequest
    {
        /// <summary>
        /// 微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 微信支付分配的商户号 
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 微信的订单号，优先使用,当没提供out_trade_no时需要传这个。 
        /// </summary>
        public string transaction_id { get; set; }

        /// <summary>
        /// 商户系统内部的订单号，当没提供transaction_id时需要传这个。 
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名，（根据key 库内部生成）
        /// 详见签名生成算法
        /// </summary>
        public string sign { get; set; }
    }
}
