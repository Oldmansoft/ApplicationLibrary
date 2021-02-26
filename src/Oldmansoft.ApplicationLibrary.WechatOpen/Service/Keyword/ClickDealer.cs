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
