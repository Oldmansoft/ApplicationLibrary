using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 平台配置
    /// </summary>
    public class Config : IConfig
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string AppId { get; private set; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        public string AppSecret { get; private set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecret"></param>
        public Config(string appId, string appSecret)
        {
            if (string.IsNullOrWhiteSpace(appId)) throw new ArgumentNullException("appId");
            if (string.IsNullOrWhiteSpace(appSecret)) throw new ArgumentNullException("appSecret");
            AppId = appId;
            AppSecret = appSecret;
        }
    }
}
