using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Dealers
{
    /// <summary>
    /// 消息处理者
    /// </summary>
    public abstract class MessageDealer : Dealer
    {
        /// <summary>
        /// 获利消息类型
        /// </summary>
        internal MessageType GetMessageType()
        {
            return Type;
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        protected abstract MessageType Type { get; }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected abstract ReplyMessage Deal(DealParameter parameter);

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        internal ReplyMessage DealMessage(DealParameter parameter)
        {
            return Deal(parameter);
        }
    }
}
