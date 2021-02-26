using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    class Location : ParameterSupporter
    {
        override internal MessageType DealType
        {
            get
            {
                return MessageType.Location;
            }
        }

        internal override DealParameter Init(XmlElement element)
        {
            var result = new LocationParameter
            {
                X = double.Parse(element.GetText("Location_X")),
                Y = double.Parse(element.GetText("Location_Y")),
                Scale = int.Parse(element.GetText("Scale")),
                Label = element.GetText("Label")
            };
            return Result(result);
        }
    }
}
