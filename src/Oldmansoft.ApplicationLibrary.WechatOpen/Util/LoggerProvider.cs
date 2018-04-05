using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Util
{
    class LoggerProvider : ILoggerProvider
    {
        /// <summary>
        /// 致命的
        /// </summary>
        /// <param name="message"></param>
        public void Fatal(string message) { }

        /// <summary>
        /// 错误的
        /// </summary>
        /// <param name="message"></param>
        public void Error(string message) { }

        /// <summary>
        /// 警告的
        /// </summary>
        /// <param name="message"></param>
        public void Warn(string message) { }

        /// <summary>
        /// 提示的
        /// </summary>
        /// <param name="message"></param>
        public void Info(string message) { }

        /// <summary>
        /// 调试的
        /// </summary>
        /// <param name="message"></param>
        public void Debug(string message) { }
    }
}
