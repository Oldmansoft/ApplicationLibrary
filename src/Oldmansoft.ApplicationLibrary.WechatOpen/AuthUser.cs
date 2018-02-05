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
    /// 授权用户
    /// </summary>
    public class AuthUser
    {
        private IAuth Auth { get; set; }

        private string OpenId { get; set; }

        /// <summary>
        /// 用户 Token 存储器
        /// </summary>
        private IUserTokenStore UserTokenStore { get; set; }

        /// <summary>
        /// 创建授权用户
        /// </summary>
        /// <param name="auth"></param>
        private AuthUser(IAuth auth)
        {
            if (auth == null) throw new ArgumentNullException("auth");
            Auth = auth;
            UserTokenStore = new Provider.InProcess.UserTokenStore();
        }

        internal static AuthUser CreateLogin(IAuth auth, string code)
        {
            var result = new AuthUser(auth);
            var token = result.Auth.GetUserToken(code);
            result.OpenId = token.openid;
            result.UserTokenStore.Set(result.OpenId, token);
            return result;
        }

        internal static AuthUser CreateFromCache(IAuth auth, string openId)
        {
            var result = new AuthUser(auth);
            result.OpenId = openId;
            return result;
        }
        
        /// <summary>
        /// 获取用户 Token
        /// </summary>
        /// <returns></returns>
        private UserTokenResponse GetUserToken()
        {
            var token = UserTokenStore.Get(OpenId);
            if (token == null) throw new WechatException("请用户授权后再操作");
            if (token.IsRefreshTokenExpired()) throw new WechatException("请用户授权后再操作");

            if (token.IsExpired())
            {
                var access_token = Auth.RefreshUserToken(token.refresh_token);
                token.SetAccessToken(access_token);
            }
            return token;
        }
        
        /// <summary>
        /// 是否授权
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorization()
        {
            var token = UserTokenStore.Get(OpenId);
            if (token == null) return false;
            if (token.IsRefreshTokenWillExpired()) return false;
            return true;
        }

        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <returns></returns>
        public AuthUserResponse GetUserInfo()
        {
            var token = GetUserToken();
            return Auth.GetUserInfo(token.access_token, token.openid);
        }
    }
}
