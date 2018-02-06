using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data
{
    class ReplyNull : ReplyText
    {
        public ReplyNull()
            : base("不支持此消息")
        { }
    }
}
