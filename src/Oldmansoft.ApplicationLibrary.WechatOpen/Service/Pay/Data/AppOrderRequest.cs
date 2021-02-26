namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// App 下单请求
    /// </summary>
    public class AppOrderRequest
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string partnerid { get; set; }

        /// <summary>
        /// 预支付交易话ID
        /// </summary>
        public string prepayid { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        public string package { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string noncestr { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
    }
}
