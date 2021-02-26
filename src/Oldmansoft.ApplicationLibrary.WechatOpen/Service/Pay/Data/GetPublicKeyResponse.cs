namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 获取公钥返回
    /// </summary>
    public class GetPublicKeyResponse : Response
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        public string pub_key { get; set; }
    }
}
