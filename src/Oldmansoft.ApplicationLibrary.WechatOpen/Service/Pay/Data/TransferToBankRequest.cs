using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 企业付款到银行请求
    /// </summary>
    public class TransferToBankRequest : Request
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
        /// 收款方银行卡号
        /// 采用标准RSA算法，公钥由微信侧提供
        /// </summary>
        public string enc_bank_no { get; set; }

        /// <summary>
        /// 收款方用户名
        /// 采用标准RSA算法，公钥由微信侧提供
        /// </summary>
        public string enc_true_name { get; set; }

        /// <summary>
        /// 收款方开户行
        /// 银行卡所在开户行编号
        /// </summary>
        public string bank_code { get; set; }

        /// <summary>
        /// 付款金额
        /// RMB分
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// 付款说明
        /// 企业付款到银行卡付款说明,即订单备注（允许100个字符以内）
        /// </summary>
        public string desc { get; set; }
    }
}
