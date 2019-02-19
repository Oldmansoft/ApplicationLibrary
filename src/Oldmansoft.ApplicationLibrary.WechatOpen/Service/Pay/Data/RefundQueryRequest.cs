using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 退款查询请求
    /// </summary>
    public class RefundQueryRequest
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
        /// 随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名，（根据key 库内部生成）
        /// 详见签名生成算法
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 偏移量，当部分退款次数超过10次时可使用，表示返回的查询结果从这个偏移量开始取记录
        /// </summary>
        public int? offset { get; set; }

        /// <summary>
        /// 微信生成的退款单号，在申请退款接口有返回
        /// </summary>
        public string refund_id { get; set; }

        /// <summary>
        /// 商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。
        /// </summary>
        public string out_refund_no { get; set; }

        /// <summary>
        /// 商户系统内部订单号，要求32个字符内，只能是数字、大小写字母_-|*@ ，且在同一个商户号下唯一。
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 微信订单号
        /// 微信订单号查询的优先级是： refund_id > out_refund_no > transaction_id > out_trade_no
        /// </summary>
        public string transaction_id { get; set; }
    }
}
