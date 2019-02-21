using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 查询企业付款请求
    /// </summary>
    public class GetTransferInfoRequest
    {
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string partner_trade_no { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 商户号的appid
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        public GetTransferInfoRequest()
        {
            nonce_str = Guid.NewGuid().ToString("N");
        }
    }
}
