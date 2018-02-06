using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 下单返回
    /// </summary>
    public class UnifiedorderResponse
    {
        /// <summary>
        /// 业务结果
        /// SUCCESS/FAIL
        /// </summary>
        public string result_code { get; set; }

        /// <summary>
        /// 返回结果
        /// </summary>
        public string return_code { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string return_msg { get; set; }

        /// <summary>
        /// 公众账号ID
        /// 调用接口提交的公众账号ID
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 商户号
        /// 调用接口提交的商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 设备号，非必需
        /// 调用接口提交的终端设备号
        /// </summary>
        public string device_info { get; set; }

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

        /// <summary>
        /// 错误代码，非必需
        /// 详细参见第6节错误列表
        /// </summary>
        public string err_code { get; set; }

        /// <summary>
        /// 错误代码描述，非必需
        /// 错误返回的信息描述
        /// </summary>
        public string err_code_des { get; set; }

        /// <summary>
        /// 交易类型
        /// 调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，详细说明见参数规定
        /// </summary>
        public string trade_type { get; set; }

        /// <summary>
        /// 预支付交易会话标识
        /// 微信生成的预支付回话标识，用于后续接口调用中使用，该值有效期为2小时
        /// </summary>
        public string prepay_id { get; set; }

        /// <summary>
        /// 二维码链接，非必需
        /// trade_type为NATIVE是有返回，可将该参数值生成二维码展示出来进行扫码支付
        /// </summary>
        public string code_url { get; set; }
    }
}
