namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 开放平台
    /// </summary>
    public interface IPlatform
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        IConfig Config { get; }

        /// <summary>
        /// 获取位置存储
        /// </summary>
        Provider.IPositionStore PositionStore { get; }

        /// <summary>
        /// 获取 Token
        /// </summary>
        /// <returns></returns>
        Data.AccessToken GetPlatformToken();

        /// <summary>
        /// 获取 Token
        /// </summary>
        /// <returns></returns>
        string GetPlatformTokenString();
    }
}
