using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.MessageDealers;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service
{
    /// <summary>
    /// 消息服务接口
    /// </summary>
    public interface IMessageResponse
    {
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
    }
}
