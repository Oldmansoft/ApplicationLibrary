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
    public interface IAuth
    {
        /// <summary>
        /// 获取用户 Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        UserTokenResponse GetUserToken(string code);

        /// <summary>
        /// 刷新用户 Token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        string RefreshUserToken(string refreshToken);

        /// <summary>
        /// 拉取用户信息(需scope为 snsapi_userinfo)
        /// </summary>
        /// <param name="userToken"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        AuthUserResponse GetUserInfo(string userToken, string openid);
    }
}
