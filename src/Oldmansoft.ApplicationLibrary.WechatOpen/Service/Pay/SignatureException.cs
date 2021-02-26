namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// 签名异常
    /// </summary>
    public class SignatureException : WechatException
    {
        /// <summary>
        /// 创建异常
        /// </summary>
        /// <param name="message"></param>
        public SignatureException(string message)
            : base(message)
        {
        }
    }
}
