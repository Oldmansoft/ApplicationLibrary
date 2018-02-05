using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.ParameterSupporter
{
    /// <summary>
    /// 位置参数
    /// </summary>
    public class LocationParameter
    {
        /// <summary>
        /// 地理位置维度
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// 地理位置经度
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }
    }
}
