using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 网页授权
    /// </summary>
    class Auth : IAuth
    {
        private IConfig Config { get; set; }

        public Auth(IConfig config)
        {
            Config = config;
        }

        AuthUserResponse IAuth.GetUserInfo(string userToken, string openid)
        {
            return Visitor.Get<AuthUserResponse>(
                string.Format(
                    "https://api.weixin.qq.com/sns/userinfo?access_token={0}&openid={1}&lang=zh_CN",
                    Uri.EscapeDataString(userToken),
                    Uri.EscapeDataString(openid)
                )
            );
        }

        UserTokenResponse IAuth.GetUserToken(string code)
        {
            var result = Visitor.Get<UserTokenResponse>(
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
            return Visitor.Get<UserTokenResponse>(
                string.Format(
                    "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid={0}&grant_type=refresh_token&refresh_token={1}",
                    Config.AppId,
                    Uri.EscapeDataString(refreshToken)
                )
            ).access_token;
        }

        public AuthUser FromCache(string openId)
        {
            return AuthUser.CreateFromCache(this, openId);
        }

        public AuthUser Login(string code)
        {
            return AuthUser.CreateLogin(this, code);
        }
    }
}
