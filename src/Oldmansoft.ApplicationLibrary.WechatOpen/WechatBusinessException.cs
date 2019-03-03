using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 微信业务异常
    /// </summary>
    public class WechatBusinessException : WechatException
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public string Code { get; private set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public WechatBusinessException(string code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}
