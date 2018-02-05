using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.MessageDealers
{
    /// <summary>
    /// 文本消息处理
    /// </summary>
    public abstract class TextMessageDealer : MessageDealer
    {
        /// <summary>
        /// 消息类型
        /// </summary>
        protected override MessageType Type
        {
            get
            {
                return MessageType.Text;
            }
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected override ReplyMessage Deal(DealParameter parameter)
        {
            return Deal(parameter.Head, parameter.Paramenter as string);
        }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="head"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        protected abstract ReplyMessage Deal(InputHead head, string text);
    }
}
