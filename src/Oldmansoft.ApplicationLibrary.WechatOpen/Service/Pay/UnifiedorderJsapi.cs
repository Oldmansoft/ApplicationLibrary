using System;

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
            var result = new Data.JsapiOrderRequest
            {
                appId = Config.AppId,
                package = string.Format("prepay_id={0}", GetResponse().prepay_id),
                timeStamp = DateTime.Now.GetUnixTimestamp().ToString(),
                signType = "MD5",
                nonceStr = Guid.NewGuid().ToString("N")
            };
            result.paySign = Config.Signature(result);
            return result;
        }
    }
}
