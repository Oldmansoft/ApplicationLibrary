using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Service.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service
{
    /// <summary>
    /// 处理者
    /// </summary>
    public abstract class Dealer
    {
        /// <summary>
        /// 服务接口
        /// </summary>
        protected IPlatform Server { get; private set; }

        internal void SetServer(IPlatform server)
        {
            Server = server;
        }

        /// <summary>
        /// 获取图文
        /// </summary>
        /// <param name="articles"></param>
        /// <returns></returns>
        protected ReplyMessage News(IEnumerable<Article> articles)
        {
            return new ReplyNews(articles);
        }

        /// <summary>
        /// 获取图文
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        protected ReplyMessage News(Article article)
        {
            return new ReplyNews(new Article[] { article });
        }

        /// <summary>
        /// 获取文字
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        protected ReplyMessage Text(string content)
        {
            return new ReplyText(content);
        }
    }
}
