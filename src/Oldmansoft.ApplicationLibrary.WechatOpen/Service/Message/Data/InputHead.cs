using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data
{
    /// <summary>
    /// 输入头信息
    /// </summary>
    public class InputHead
    {
        /// <summary>
        /// 应用 Id
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }

        /// <summary>
        /// 消息类
        /// </summary>
        public string MsgType { get; set; }

        /// <summary>
        /// 消息创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 消息 id
        /// </summary>
        public long MsgId { get; set; }
    }
}
