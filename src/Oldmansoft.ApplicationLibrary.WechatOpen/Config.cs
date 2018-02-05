using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    public class Config : IConfig
    {
        public string AppId { get; private set; }

        public string AppSecret { get; private set; }

        public Config(string appId, string appSecret)
        {
            if (string.IsNullOrWhiteSpace(appId)) throw new ArgumentNullException("appId");
            if (string.IsNullOrWhiteSpace(appSecret)) throw new ArgumentNullException("appSecret");
            AppId = appId;
            AppSecret = appSecret;
        }
    }
}
