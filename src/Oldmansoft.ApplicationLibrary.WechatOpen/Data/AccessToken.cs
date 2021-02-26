using System;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Data
{
    /// <summary>
    /// AccessToken 结果
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// Token
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// 过期秒数
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 刷新时间
        /// </summary>
        public DateTime AccessTokenCreateTime { get; set; }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        public bool IsExpired()
        {
            return DateTime.Now.Subtract(AccessTokenCreateTime).TotalSeconds > (expires_in - 60 * 5);
        }

        /// <summary>
        /// 设置用户 Token
        /// </summary>
        /// <param name="accessToken"></param>
        internal void SetAccessToken(string accessToken)
        {
            access_token = accessToken;
            AccessTokenCreateTime = DateTime.Now;
        }
    }
}
