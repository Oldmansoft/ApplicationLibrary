using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Keyword
{
    class ClickDealer : InputDealer
    {
        public ClickDealer(Server server)
            : base(server)
        { }

        protected override MessageType Type
        {
            get
            {
                return MessageType.Click;
            }
        }
    }
}
