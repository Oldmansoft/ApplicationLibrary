using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// Native 统下一单
    /// </summary>
    public class UnifiedorderNavite : Unifiedorder
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="config"></param>
        /// <param name="request"></param>
        public UnifiedorderNavite(IConfig config, Data.UnifiedorderRequest request)
            : base(config, request)
        {
        }

        /// <summary>
        /// 获取请求
        /// </summary>
        /// <returns></returns>
        public string GetRequest()
        {
            return GetResponse().code_url;
        }
    }
}
