using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;

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
            var result = new LocationParameter();
            result.X = double.Parse(element.GetText("Location_X"));
            result.Y = double.Parse(element.GetText("Location_Y"));
            result.Scale = int.Parse(element.GetText("Scale"));
            result.Label = element.GetText("Label");
            return Result(result);
        }
    }
}
