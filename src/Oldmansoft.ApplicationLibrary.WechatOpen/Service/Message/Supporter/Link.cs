using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    class Link : ParameterSupporter
    {
        override internal MessageType DealType
        {
            get
            {
                return MessageType.Link;
            }
        }

        internal override DealParameter Init(XmlElement element)
        {
            var result = new LinkParameter
            {
                Title = element.GetText("Title"),
                Description = element.GetText("Description"),
                Url = element.GetText("Url")
            };
            return Result(result);
        }
    }
}
