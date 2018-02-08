using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// 商户配置
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        string AppId { get; }

        /// <summary>
        /// 商户号
        /// </summary>
        string MchId { get; }

        /// <summary>
        /// 商户密钥
        /// </summary>
        string MchKey { get; }
    }
}
