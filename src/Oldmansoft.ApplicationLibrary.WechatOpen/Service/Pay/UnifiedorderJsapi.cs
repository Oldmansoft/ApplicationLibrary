using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// Jsapi 统下一单
    /// </summary>
    public class UnifiedorderJsapi : Unifiedorder
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="config"></param>
        /// <param name="request"></param>
        public UnifiedorderJsapi(IConfig config, Data.UnifiedorderRequest request)
            : base(config, request)
        {
        }

        /// <summary>
        /// 获取请求
        /// </summary>
        /// <returns></returns>
        public Data.JsapiOrderRequest GetRequest()
        {
            var result = new Data.JsapiOrderRequest();
            result.appId = Config.AppId;
            result.package = string.Format("prepay_id={0}", GetResponse().prepay_id);
            result.timeStamp = DateTime.Now.GetUnixTimestamp().ToString();
            result.signType = "MD5";
            result.nonceStr = Guid.NewGuid().ToString("N");
            result.paySign = Config.Signature(result);
            return result;
        }
    }
}
