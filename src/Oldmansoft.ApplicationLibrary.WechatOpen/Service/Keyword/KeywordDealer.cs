using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Keyword
{
    /// <summary>
    /// 消息处理
    /// </summary>
    public abstract class KeywordDealer : Message.Dealer
    {
        /// <summary>
        /// 获取消息关键字
        /// </summary>
        /// <returns></returns>
        internal string[] GetKeywords()
        {
            return Keywords;
        }
        
        /// <summary>
        /// 消息关键字
        /// </summary>
        protected abstract string[] Keywords { get; }

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="head"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        protected abstract ReplyMessage Deal(InputHead head, string keyword);

        /// <summary>
        /// 处理消息
        /// </summary>
        /// <param name="head"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        internal ReplyMessage DealMessage(InputHead head, string keyword)
        {
            return Deal(head, keyword);
        }
    }
}
