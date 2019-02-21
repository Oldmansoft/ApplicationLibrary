using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 申请退款请求内容
    /// </summary>
    public class RefundRequest : Request
    {
        /// <summary>
        /// 微信分配的公众账号ID（企业号corpid即为此appId）
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 微信支付分配的商户号 
        /// </summary>
        public string mch_id { get; set; }
        
        /// <summary>
        /// 微信的订单号，优先使用,当没提供out_trade_no时需要传这个。 
        /// </summary>
        public string transaction_id { get; set; }

        /// <summary>
        /// 商户系统内部的订单号，当没提供transaction_id时需要传这个。 
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 商户退款单号
        /// 商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
        /// </summary>
        public string out_refund_no { get; set; }

        /// <summary>
        /// 订单金额
        /// 订单总金额，单位为分
        /// </summary>
        public int total_fee { get; set; }

        /// <summary>
        /// 退款金额
        /// 退款总金额，单位为分
        /// </summary>
        public int refund_fee { get; set; }

        /// <summary>
        /// 退款原因
        /// 若商户传入，会在下发给用户的退款消息中体现退款原因
        /// </summary>
        public string refund_desc { get; set; }

        /// <summary>
        /// 退款结果通知url
        /// 异步接收微信支付退款结果通知的回调地址，通知URL必须为外网可访问的url，不允许带参数
        /// 如果参数中传了notify_url，则商户平台上配置的回调地址将不会生效。
        /// </summary>
        public string notify_url { get; set; }
    }
}
