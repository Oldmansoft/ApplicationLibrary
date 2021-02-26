using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    class Voice : ParameterSupporter
    {
        override internal MessageType DealType
        {
            get
            {
                return MessageType.Voice;
            }
        }

        internal override DealParameter Init(XmlElement element)
        {
            var result = new VoiceParameter
            {
                Format = element.GetText("Format"),
                MediaId = element.GetText("MediaId"),
                Recognition = element.GetText("Recognition")
            };
            return Result(result);
        }
    }
}
