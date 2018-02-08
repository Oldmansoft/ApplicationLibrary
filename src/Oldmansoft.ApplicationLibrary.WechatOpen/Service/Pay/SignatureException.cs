using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
