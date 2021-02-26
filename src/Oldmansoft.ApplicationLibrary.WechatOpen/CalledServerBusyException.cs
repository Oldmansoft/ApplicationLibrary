namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 微信系统繁忙
    /// </summary>
    public class CalledServerBusyException : CallException
    {
        internal CalledServerBusyException(string message)
            : base(-1, message)
        { }
    }
}
