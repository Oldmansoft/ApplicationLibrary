using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Data;
using Oldmansoft.ApplicationLibrary.WechatOpen.Provider;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service
{
    public class JsSdk
    {
        private static object RefreshTicket_Locker = new object();

        private IPlatform Platform { get; set; }
        
        public ITicketStore TicketStore { get; set; }

        public JsSdk(IPlatform platform)
        {
            if (platform == null) throw new ArgumentNullException();
            Platform = platform;
            TicketStore = new Provider.InProcess.TicketStore();
        }

        private TicketResponse RequestTicket()
        {
            var result = Visitor.Get<TicketResponse>(
                string.Format(
                    "https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi",
                    Platform.GetPlatformTokenString()
                )
            );
            result.RefreshTime = DateTime.Now;
            return result;
        }

        public TicketResponse GetTicket()
        {
            var result = TicketStore.Get(Platform.Config.AppId);
            if (result == null || result.IsExpire())
            {
                lock (RefreshTicket_Locker)
                {
                    result = TicketStore.Get(Platform.Config.AppId);
                    if (result == null || result.IsExpire())
                    {
                        result = RequestTicket();
                        TicketStore.Set(Platform.Config.AppId, result);
                    }
                }
            }
            return result;
        }

        public string GetTicketString()
        {
            return GetTicket().ticket;
        }

        /// <summary>
        /// 签名
        /// 注意事项
        /// 1.签名用的noncestr和timestamp必须与wx.config中的nonceStr和timestamp相同。
        /// 2.签名用的url必须是调用JS接口页面的完整URL。
        /// </summary>
        /// <param name="noncestr">随机串</param>
        /// <param name="timestamp">时间戳</param>
        /// <param name="url">当前网页的URL（不包含#及其后面部分）</param>
        /// <returns></returns>
        public string Signature(string noncestr, long timestamp, string url)
        {
            var input = new SignatureRequest();
            input.noncestr = noncestr;
            input.timestamp = timestamp;
            input.url = url;
            input.jsapi_ticket = GetTicketString();
            return input.ToString().GetSHA1Hash();
        }
    }
}
