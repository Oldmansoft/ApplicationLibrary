using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 企业付款到银行返回
    /// </summary>
    public class TransferToBankResponse : Response
    {
        /// <summary>
        /// 商户号
        /// 微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 商户企业付款单号
        /// </summary>
        public string partner_trade_no { get; set; }

        /// <summary>
        /// 代付金额
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// 微信企业付款单号
        /// </summary>
        public string payment_no { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        public string cmms_amt { get; set; }
    }
}
