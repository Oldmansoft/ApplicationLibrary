using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    /// <summary>
    /// 图片消息
    /// </summary>
    class Image : MessageParameterSupporter
    {
        override internal MessageType DealType
        {
            get
            {
                return MessageType.Image;
            }
        }

        internal override DealParameter Init(System.Xml.XmlElement element)
        {
            var result = new ImageParameter();
            result.PicUrl = element.GetText("PicUrl");
            result.MediaId = element.GetText("MediaId");
            return Result(result);
        }
    }
}
