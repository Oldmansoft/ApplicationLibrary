namespace Oldmansoft.ApplicationLibrary.WechatOpen.Util
{
    /// <summary>
    /// 日志提供者
    /// </summary>
    public interface ILoggerProvider
    {
        /// <summary>
        /// 致命的
        /// </summary>
        /// <param name="message"></param>
        void Fatal(string message);

        /// <summary>
        /// 错误的
        /// </summary>
        /// <param name="message"></param>
        void Error(string message);

        /// <summary>
        /// 警告的
        /// </summary>
        /// <param name="message"></param>
        void Warn(string message);

        /// <summary>
        /// 提示的
        /// </summary>
        /// <param name="message"></param>
        void Info(string message);

        /// <summary>
        /// 调试的
        /// </summary>
        /// <param name="message"></param>
        void Debug(string message);
    }
}
