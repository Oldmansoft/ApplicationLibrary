using System;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 微信服务异常
    /// </summary>
    public class WechatException : Exception
    {
        /// <summary>
        /// 创建微信服务异常
        /// </summary>
        /// <param name="message"></param>
        public WechatException(string message)
            : base(message)
        {
        }
    }
}
