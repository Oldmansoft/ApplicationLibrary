using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 申请退款返回内容
    /// </summary>
    public class RefundResponse : Reponse
    {
        /// <summary>
        /// 微信分配的公众账号ID
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }
        
        /// <summary>
        /// 微信订单号
        /// </summary>
        public string transaction_id { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string out_refund_no { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string refund_id { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public int refund_fee { get; set; }

        /// <summary>
        /// 应结退款金额
        /// </summary>
        public int settlement_refund_fee { get; set; }

        /// <summary>
        /// 订单总金额，单位为分
        /// </summary>
        public int total_fee { get; set; }

        /// <summary>
        /// 应结订单金额
        /// </summary>
        public int settlement_total_fee { get; set; }

        /// <summary>
        /// 标价币种
        /// </summary>
        public string fee_type { get; set; }

        /// <summary>
        /// 现金支付金额
        /// </summary>
        public int cash_fee { get; set; }

        /// <summary>
        /// 现金支付币种
        /// </summary>
        public string cash_fee_type { get; set; }

        /// <summary>
        /// 现金退款金额
        /// </summary>
        public string cash_refund_fee { get; set; }
    }
}
