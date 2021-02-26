namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 配置
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        string AppId { get; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        string AppSecret { get; }
    }
}
