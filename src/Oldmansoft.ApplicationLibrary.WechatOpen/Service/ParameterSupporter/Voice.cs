﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    class Voice : MessageParameterSupporter
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
            var result = new VoiceParameter();
            result.Format = element.GetText("Format");
            result.MediaId = element.GetText("MediaId");
            result.Recognition = element.GetText("Recognition");
            return Result(result);
        }
    }
}
