﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    class ShortVideo : MessageParameterSupporter
    {
        override internal MessageType DealType
        {
            get
            {
                return MessageType.ShortVideo;
            }
        }

        internal override DealParameter Init(XmlElement element)
        {
            var result = new VideoParameter();
            result.MediaId = element.GetText("MediaId");
            result.ThumbMediaId = element.GetText("ThumbMediaId");
            return Result(result);
        }
    }
}
