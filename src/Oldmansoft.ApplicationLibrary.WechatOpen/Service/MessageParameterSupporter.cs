﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service
{
    /// <summary>
    /// 消息参数提供者
    /// </summary>
    abstract class MessageParameterSupporter
    {
        /// <summary>
        /// 处理的消息类型
        /// </summary>
        internal abstract MessageType DealType { get; }

        protected DealParameter Result(MessageType dealType, object parameter)
        {
            var result = new DealParameter();
            result.DealType = dealType;
            result.Paramenter = parameter;
            return result;
        }

        protected DealParameter Result(object parameter)
        {
            return Result(DealType, parameter);
        }

        internal abstract DealParameter Init(System.Xml.XmlElement element);
    }
}
