using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    /// <summary>
    /// 链接参数
    /// </summary>
    public class LinkParameter
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
        /// 链接
        /// </summary>
        public string Url { get; set; }
    }
}
