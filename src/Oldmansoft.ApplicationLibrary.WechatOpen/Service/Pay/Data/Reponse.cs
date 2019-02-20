using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 返回结果
    /// </summary>
    public abstract class Reponse
    {
        /// <summary>
        /// SUCCESS/FAIL 
        /// 此字段是通信标识，非交易标识
        /// </summary>
        public string return_code { get; set; }

        /// <summary>
        /// 返回信息，如非空，为错误原因 
        /// 签名失败
        /// 参数格式校验错误
        /// </summary>
        public string return_msg { get; set; }

        /// <summary>
        /// 业务结果
        /// SUCCESS/FAIL
        /// SUCCESS退款申请接收成功，结果通过退款查询接口查询
        /// FAIL 提交业务失败
        /// </summary>
        public string result_code { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string err_code { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string err_code_des { get; set; }

        /// <summary>
        /// 随机字符串
        /// 微信返回的随机字符串
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名
        /// 微信返回的签名，详见签名算法
        /// </summary>
        public string sign { get; set; }
    }
}
