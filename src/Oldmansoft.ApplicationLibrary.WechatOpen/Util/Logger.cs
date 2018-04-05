using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Util
{
    /// <summary>
    /// 日志
    /// </summary>
    public static class Logger
    {
        private static ILoggerProvider Provider { get; set; }

        static Logger()
        {
            Provider = new LoggerProvider();
        }

        /// <summary>
        /// 设置日志提供者
        /// </summary>
        /// <param name="provider"></param>
        public static void SetProvider(ILoggerProvider provider)
        {
            if (provider == null) throw new ArgumentNullException();
            Provider = provider;
        }

        /// <summary>
        /// 致命的
        /// </summary>
        /// <param name="message"></param>
        public static void Fatal(string message)
        {
            Provider.Fatal(message);
        }

        /// <summary>
        /// 错误的
        /// </summary>
        /// <param name="message"></param>
        public static void Error(string message)
        {
            Provider.Error(message);
        }

        /// <summary>
        /// 警告的
        /// </summary>
        /// <param name="message"></param>
        public static void Warn(string message)
        {
            Provider.Warn(message);
        }

        /// <summary>
        /// 提示的
        /// </summary>
        /// <param name="message"></param>
        public static void Info(string message)
        {
            Provider.Info(message);
        }

        /// <summary>
        /// 调试的
        /// </summary>
        /// <param name="message"></param>
        public static void Debug(string message)
        {
            Provider.Debug(message);
        }
    }
}
