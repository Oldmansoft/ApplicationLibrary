namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// 商户配置
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        string AppId { get; }

        /// <summary>
        /// 商户号
        /// </summary>
        string MchId { get; }

        /// <summary>
        /// 商户密钥
        /// </summary>
        string MchKey { get; }

        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        string Signature<T>(T input) where T : class;
    }
}
