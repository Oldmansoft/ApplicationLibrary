using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 下载交易账单请求
    /// </summary>
    public class DownloadBillRequest
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
        /// 下载对账单的日期，格式：20140603
        /// </summary>
        public string bill_date { get; set; }

        /// <summary>
        /// ALL（默认值），返回当日所有订单信息（不含充值退款订单）
        /// SUCCESS，返回当日成功支付的订单（不含充值退款订单）
        /// REFUND，返回当日退款订单（不含充值退款订单）
        /// RECHARGE_REFUND，返回当日充值退款订单
        /// </summary>
        public string bill_type { get; set; }
    }
}
