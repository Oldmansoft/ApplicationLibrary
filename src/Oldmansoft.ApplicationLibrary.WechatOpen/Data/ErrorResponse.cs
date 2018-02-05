using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Data
{
    /// <summary>
    /// 异常结果
    /// </summary>
    class ErrorResponse
    {
        /// <summary>
        /// 全局返回码
        /// </summary>
        public int errcode { get; set; }

        /// <summary>
        /// 异常信息
        /// </summary>
        public string errmsg { get; set; }
    }
}
