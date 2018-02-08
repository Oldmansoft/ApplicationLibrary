using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Data;
using Oldmansoft.ApplicationLibrary.WechatOpen.Provider;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 开放平台
    /// </summary>
    public class Platform : IPlatform
    {
        private static object RefreshAccessToken_Locker = new object();

        /// <summary>
        /// 获取配置
        /// </summary>
        public IConfig Config { get; private set; }

        /// <summary>
        /// 获取和设置 Token 存储
        /// </summary>
        public IAccessTokenStore AccessTokenStore { get; set; }

        /// <summary>
        /// 获取和设置位置存储
        /// 消息回调服务使用
        /// </summary>
        public IPositionStore PositionStore { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="config"></param>
        public Platform(IConfig config)
        {
            if (config == null) throw new ArgumentNullException();
            Config = config;
            AccessTokenStore = new Provider.InProcess.AccessTokenStore();
            PositionStore = new Provider.InProcess.PositionStore();
        }

        private AccessToken RequestAccessToken()
        {
            var result = Visitor.Get<AccessToken>(
                string.Format(
                    "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}",
                    Config.AppId,
                    Config.AppSecret
                )
            );
            result.AccessTokenCreateTime = DateTime.Now;
            return result;
        }

        /// <summary>
        /// 获取 Token
        /// </summary>
        /// <returns></returns>
        public AccessToken GetPlatformToken()
        {
            var result = AccessTokenStore.Get(Config.AppId);
            if (result == null || result.IsExpired())
            {
                lock (RefreshAccessToken_Locker)
                {
                    result = AccessTokenStore.Get(Config.AppId);
                    if (result == null || result.IsExpired())
                    {
                        result = RequestAccessToken();
                        AccessTokenStore.Set(Config.AppId, result);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 获取 Token
        /// </summary>
        /// <returns></returns>
        public string GetPlatformTokenString()
        {
            return GetPlatformToken().access_token;
        }
        
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public AccessUserInfo GetUserInfo(string openid)
        {
            return Visitor.Get<AccessUserInfo>(
                string.Format(
                    "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN",
                    GetPlatformTokenString(),
                    openid
                )
            );
        }
    }
}
