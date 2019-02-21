using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 查询企业付款银行卡请求
    /// </summary>
    public class QueryBankRequest
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        public string partner_trade_no { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        public QueryBankRequest()
        {
            nonce_str = Guid.NewGuid().ToString("N");
        }
    }
}
