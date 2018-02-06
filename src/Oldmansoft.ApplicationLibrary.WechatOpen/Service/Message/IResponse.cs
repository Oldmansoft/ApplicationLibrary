using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Dealers;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message
{
    /// <summary>
    /// 消息响应接口
    /// </summary>
    public interface IResponse
    {
        IPlatform Platform { get; }

        /// <summary>
        /// 位置存储器
        /// </summary>
        Provider.IPositionStore PositionStore { get; }

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

        XmlDocument Deal(XmlDocument input);
    }
}
