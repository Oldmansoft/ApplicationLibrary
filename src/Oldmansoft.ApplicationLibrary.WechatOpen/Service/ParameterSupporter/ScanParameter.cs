﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    /// <summary>
    /// 扫描参数
    /// </summary>
    public class ScanParameter
    {
        /// <summary>
        /// 创建二维码时的二维码 scene_id 或 scene_str
        /// </summary>
        public string Scene { get; set; }

        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }
}
