using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    class Video : ParameterSupporter
    {
        override internal MessageType DealType
        {
            get
            {
                return MessageType.Video;
            }
        }

        internal override DealParameter Init(XmlElement element)
        {
            var result = new VideoParameter
            {
                MediaId = element.GetText("MediaId"),
                ThumbMediaId = element.GetText("ThumbMediaId")
            };
            return Result(result);
        }
    }
}
