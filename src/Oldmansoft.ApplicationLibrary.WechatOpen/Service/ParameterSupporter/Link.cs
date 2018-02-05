using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    class Link : MessageParameterSupporter
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
            var result = new LinkParameter();
            result.Title = element.GetText("Title");
            result.Description = element.GetText("Description");
            result.Url = element.GetText("Url");
            return Result(result);
        }
    }
}
