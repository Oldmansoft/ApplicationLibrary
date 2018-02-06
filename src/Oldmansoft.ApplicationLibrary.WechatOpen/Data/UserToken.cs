using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Data
{
    /// <summary>
    /// 用户 Token 结果
    /// </summary>
    public class UserToken : AccessToken
    {
        /// <summary>
        /// Refresh Token
        /// </summary>
        public string refresh_token { get; set; }

        /// <summary>
        /// Open Id
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// Scope
        /// </summary>
        public string scope { get; set; }

        /// <summary>
        /// 刷新码创建时间
        /// </summary>
        public DateTime RefreshTokenCreateTime { get; set; }

        /// <summary>
        /// 是否刷新码到期
        /// 30 天到期
        /// </summary>
        /// <returns></returns>
        public bool IsRefreshTokenExpired()
        {
            return DateTime.Now.Subtract(RefreshTokenCreateTime).TotalHours > 30 * 24;
        }

        /// <summary>
        /// 是否刷新码将要到期
        /// </summary>
        /// <returns></returns>
        public bool IsRefreshTokenWillExpired()
        {
            return DateTime.Now.Subtract(RefreshTokenCreateTime).TotalHours > 29 * 24;
        }
    }
}
