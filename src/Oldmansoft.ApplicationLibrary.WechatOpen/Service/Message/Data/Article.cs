using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 注释
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string PicUrl { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Url { get; set; }
    }
}
