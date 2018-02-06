using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data
{
    /// <summary>
    /// 图文消息
    /// </summary>
    public class ReplyNews : ReplyMessage
    {
        /// <summary>
        /// 内容列表
        /// </summary>
        public IEnumerable<Article> Articles { get; protected set; }

        /// <summary>
        /// 创建图文消息
        /// </summary>
        /// <param name="articles"></param>
        public ReplyNews(IEnumerable<Article> articles)
        {
            Articles = articles;
        }

        internal override string Type
        {
            get { return "news"; }
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="elements"></param>
        protected override void SetBody(List<System.Xml.XmlElement> elements)
        {
            elements.Add(Document.CreateElement("ArticleCount", Articles.Count()));
            var items = Document.CreateElement("Articles");
            foreach (var article in Articles)
            {
                var item = Document.CreateElement("item");
                foreach (var property in article.GetType().GetProperties())
                {
                    var value = property.GetValue(article);
                    if (value == null) continue;

                    var element = Document.CreateElement(property.Name, value);
                    item.AppendChild(element);
                }
                items.AppendChild(item);
            }
            elements.Add(items);
        }
    }
}
