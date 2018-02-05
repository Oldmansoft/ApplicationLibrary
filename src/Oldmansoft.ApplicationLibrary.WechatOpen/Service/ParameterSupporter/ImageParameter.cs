using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    /// <summary>
    /// 图片参数
    /// </summary>
    public class ImageParameter : MediaParameter
    {
        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }
    }
}
