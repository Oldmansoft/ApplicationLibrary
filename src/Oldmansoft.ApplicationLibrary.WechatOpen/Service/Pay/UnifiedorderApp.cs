using System;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// App 统下一单
    /// </summary>
    public class UnifiedorderApp : Unifiedorder
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="config"></param>
        /// <param name="request"></param>
        public UnifiedorderApp(IConfig config, Data.UnifiedorderRequest request)
            : base(config, request)
        {
        }

        /// <summary>
        /// 获取请求
        /// </summary>
        /// <returns></returns>
        public Data.AppOrderRequest GetRequest()
        {
            return new Data.AppOrderRequest
            {
                appid = Config.AppId,
                partnerid = Config.MchId,
                prepayid = GetResponse().prepay_id,
                package = "Sign=WXPay",
                timestamp = DateTime.Now.GetUnixTimestamp().ToString(),
                noncestr = Guid.NewGuid().ToString("N")
            };
        }
    }
}
