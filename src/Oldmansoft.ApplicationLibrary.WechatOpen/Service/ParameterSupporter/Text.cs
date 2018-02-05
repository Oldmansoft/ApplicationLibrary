using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    /// <summary>
    /// 文本消息
    /// </summary>
    class Text : MessageParameterSupporter
    {
        override internal MessageType DealType
        {
            get
            {
                return MessageType.Text;
            }
        }

        internal override DealParameter Init(XmlElement element)
        {
            return Result(MessageType.Text, element.SelectSingleNode("Content").GetText());
        }
    }
}
