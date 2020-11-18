using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 下载帐单错误返回
    /// </summary>
    public class DownloadBillFailResponse
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        public string return_code { get; set; }

        /// <summary>
        /// 错误码描述
        /// </summary>
        public string return_msg { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public string error_code { get; set; }
    }
}
