using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Data;
using Oldmansoft.ApplicationLibrary.WechatOpen.Provider;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    public class Platform : IPlatform
    {
        private static object RefreshAccessToken_Locker = new object();

        public IConfig Config { get; private set; }

        public IAccessTokenStore AccessTokenStore { get; set; }

        public Platform(IConfig config)
        {
            if (config == null) throw new ArgumentNullException();
            Config = config;
            AccessTokenStore = new Provider.InProcess.AccessTokenStore();
        }

        private AccessTokenResponse RequestAccessToken()
        {
            var result = Visitor.Get<AccessTokenResponse>(
                string.Format(
                    "https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}",
                    Config.AppId,
                    Config.AppSecret
                )
            );
            result.AccessTokenCreateTime = DateTime.Now;
            return result;
        }

        public AccessTokenResponse GetPlatformToken()
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

        public string GetPlatformTokenString()
        {
            return GetPlatformToken().access_token;
        }
        
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public AccessUserResponse GetUserInfo(string openid)
        {
            return Visitor.Get<AccessUserResponse>(
                string.Format(
                    "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN",
                    GetPlatformTokenString(),
                    openid
                )
            );
        }
    }
}
