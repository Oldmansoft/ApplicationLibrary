using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// JSAPI 下单请求
    /// </summary>
    public class JsapiOrderRequest
    {
        /// <summary>
        /// 随机字符串，不长于32位。
        /// </summary>
        public string nonceStr { get; set; }

        /// <summary>
        /// 统一下单接口返回的prepay_id参数值，提交格式如：prepay_id=***
        /// </summary>
        public string package { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public string timeStamp { get; set; }

        /// <summary>
        /// 签名类型，默认为MD5，支持HMAC-SHA256和MD5。注意此处需与统一下单的签名类型一致
        /// </summary>
        public string signType { get; set; }

        /// <summary>
        /// 公众号id
        /// </summary>
        public string appId { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string paySign { get; set; }
    }
}
