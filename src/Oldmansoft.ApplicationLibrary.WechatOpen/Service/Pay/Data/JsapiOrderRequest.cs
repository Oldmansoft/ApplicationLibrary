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
        public string nonceStr { get; set; }

        public string package { get; set; }

        public string timeStamp { get; set; }

        public string signType { get; set; }

        public string appId { get; set; }

        public string paySign { get; set; }
    }
}
