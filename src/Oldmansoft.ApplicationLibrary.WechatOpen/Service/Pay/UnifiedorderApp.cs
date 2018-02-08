using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = new Data.AppOrderRequest();
            result.appid = Config.AppId;
            result.partnerid = Config.MchId;
            result.prepayid = GetResponse().prepay_id;
            result.package = "Sign=WXPay";
            result.timestamp = DateTime.Now.GetUnixTimestamp().ToString();
            result.noncestr = Guid.NewGuid().ToString("N");
            return result;
        }
    }
}
