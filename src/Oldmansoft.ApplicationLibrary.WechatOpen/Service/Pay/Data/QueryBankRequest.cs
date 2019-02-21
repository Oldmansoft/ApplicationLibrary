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
    public class QueryBankRequest : Request
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        public string partner_trade_no { get; set; }
    }
}
