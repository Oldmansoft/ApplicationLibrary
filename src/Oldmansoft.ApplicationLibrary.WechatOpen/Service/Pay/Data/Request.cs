using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 请求
    /// </summary>
    public class Request
    {

        /// <summary>
        /// 随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名，（根据key 库内部生成）
        /// 详见签名生成算法
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        public Request()
        {
            nonce_str = Guid.NewGuid().ToString("N");
        }
    }
}
