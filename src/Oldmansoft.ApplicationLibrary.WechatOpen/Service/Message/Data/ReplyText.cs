using System.Collections.Generic;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data
{
    /// <summary>
    /// 文本消息
    /// </summary>
    class ReplyText : ReplyMessage
    {
        internal override string Type
        {
            get { return "text"; }
        }

        private string Content { get; set; }

        /// <summary>
        /// 创建文本消息
        /// </summary>
        /// <param name="content"></param>
        public ReplyText(string content)
        {
            Content = content;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="elements"></param>
        protected override void SetBody(List<XmlElement> elements)
        {
            elements.Add(Extends.CreateElement(Document, "Content", Content));
        }
    }
}
