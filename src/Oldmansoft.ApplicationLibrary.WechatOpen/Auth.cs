using Oldmansoft.ApplicationLibrary.WechatOpen.Data;
using Oldmansoft.ApplicationLibrary.WechatOpen.Provider;
using System;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 网页授权
    /// </summary>
    public class Auth : IAuth
    {
        private IConfig Config { get; set; }

        /// <summary>
        /// 用户 Token 存储器
        /// </summary>
        public IUserTokenStore UserTokenStore { get; set; }
        
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="config"></param>
        public Auth(IConfig config)
        {
            Config = config;
            UserTokenStore = new Provider.InProcess.UserTokenStore();
        }

        AuthUserInfo IAuth.GetUserInfo(string userToken, string openid)
        {
            return Visitor.Get<AuthUserInfo>(
                string.Format(
                    "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN",
                    Uri.EscapeDataString(userToken),
                    Uri.EscapeDataString(openid)
                )
            );
        }

        UserToken IAuth.GetUserToken(string code)
        {
            var result = Visitor.Get<UserToken>(
                string.Format(
                    "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",
                    Config.AppId,
                    Config.AppSecret,
                    Uri.EscapeDataString(code)
                )
            );
            result.AccessTokenCreateTime = DateTime.Now;
            result.RefreshTokenCreateTime = DateTime.Now;
            return result;
        }

        string IAuth.RefreshUserToken(string refreshToken)
        {
            return Visitor.Get<UserToken>(
                string.Format(
                    "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}",
                    Config.AppId,
                    Uri.EscapeDataString(refreshToken)
                )
            ).access_token;
        }

        /// <summary>
        /// 从缓存中得到授权用户
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public virtual AuthUser FromCache(string openId)
        {
            return AuthUser.CreateFromCache(this, UserTokenStore, openId);
        }

        /// <summary>
        /// 从授码码得到授权用户
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public virtual AuthUser FromCode(string code)
        {
            return AuthUser.Create(this, UserTokenStore, code);
        }
    }
}
