using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data
{
    /// <summary>
    /// 处理参数
    /// </summary>
    public class DealParameter
    {
        /// <summary>
        /// 源文档
        /// </summary>
        public System.Xml.XmlDocument Source { get; set; }

        /// <summary>
        /// 信息头
        /// </summary>
        public InputHead Head { get; set; }

        /// <summary>
        /// 消息类型
        /// </summary>
        public MessageType DealType { get; set; }

        /// <summary>
        /// 参数值
        /// </summary>
        public object Paramenter { get; set; }
    }
}
