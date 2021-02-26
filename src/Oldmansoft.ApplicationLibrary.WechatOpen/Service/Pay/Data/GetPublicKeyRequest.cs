namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 获取公钥请求
    /// </summary>
    public class GetPublicKeyRequest : Request
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }
        
        /// <summary>
        /// 签名类型
        /// </summary>
        public string sign_type { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        public GetPublicKeyRequest()
        {
            sign_type = "MD5";
        }
    }
}
