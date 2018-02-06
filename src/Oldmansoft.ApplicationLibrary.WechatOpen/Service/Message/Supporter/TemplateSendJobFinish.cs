using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    /// <summary>
    /// 模版消息发送结果
    /// </summary>
    public class TemplateSendJobFinish
    {
        /// <summary>
        /// 群发的消息ID
        /// </summary>
        public long MsgId { get; set; }

        /// <summary>
        /// 群发的结果
        /// </summary>
        public string Status { get; set; }
    }
}
