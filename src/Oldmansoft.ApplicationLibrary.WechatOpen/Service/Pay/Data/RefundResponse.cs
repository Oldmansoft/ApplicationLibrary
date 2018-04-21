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
    public class RefundResponse
    {
        /// <summary>
        /// SUCCESS/FAIL 
        /// 此字段是通信标识，非交易标识
        /// </summary>
        public string return_code { get; set; }
        
        /// <summary>
        /// 返回信息，如非空，为错误原因 
        /// 签名失败
        /// 参数格式校验错误
        /// </summary>
        public string return_msg { get; set; }

        /// <summary>
        /// 业务结果
        /// SUCCESS/FAIL
        /// SUCCESS退款申请接收成功，结果通过退款查询接口查询
        /// FAIL 提交业务失败
        /// </summary>
        public string result_code { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        public string err_code { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string err_code_des { get; set; }

        /// <summary>
        /// 微信分配的公众账号ID
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

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
