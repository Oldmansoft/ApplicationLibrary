﻿using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Dealers;
using System.Reflection;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message
{
    /// <summary>
    /// 消息响应接口
    /// </summary>
    public interface IResponse
    {
        /// <summary>
        /// 平台
        /// </summary>
        IPlatform Platform { get; }
        
        /// <summary>
        /// 注册消息处理对象
        /// </summary>
        /// <param name="dealer"></param>
        void AddMessageDealer(MessageDealer dealer);

        /// <summary>
        /// 从程序集中注册所有的 MessageDealer 对象
        /// </summary>
        /// <param name="assembly"></param>
        void AddMessageDealerFromAssembly(Assembly assembly);

        /// <summary>
        /// 处理
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        XmlDocument Deal(XmlDocument input);
    }
}
