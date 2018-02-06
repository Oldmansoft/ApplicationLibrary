using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 订单返回
    /// </summary>
    public class OrderResponse
    {
        /// <summary>
        /// SUCCESS/FAIL 
        /// 此字段是通信标识，非交易标识，交易是否成功需要查看trade_state来判断
        /// </summary>
        public string return_code { get; set; }

        /// <summary>
        /// 业务结果
        /// </summary>
        public string result_code { get; set; }

        /// <summary>
        /// 返回信息，如非空，为错误原因 
        /// 签名失败
        /// 参数格式校验错误
        /// </summary>
        public string return_msg { get; set; }

        /// <summary>
        /// 微信分配的公众账号ID 
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
        /// 签名，详见签名生成算法
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 错误码
        /// </summary>
        public string err_code { get; set; }

        /// <summary>
        /// 结果信息描述 
        /// </summary>
        public string err_code_des { get; set; }

        /// <summary>
        /// 微信支付分配的终端设备号， 
        /// </summary>
        public string device_info { get; set; }

        /// <summary>
        /// 用户在商户appid下的唯一标识 
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效 
        /// </summary>
        public string is_subscribe { get; set; }


        /// <summary>
        /// 调用接口提交的交易类型，取值如下：JSAPI，NATIVE，APP，MICROPAY，详细说明见参数规定
        /// </summary>
        public string trade_type { get; set; }

        /// <summary>
        /// SUCCESS—支付成功 
        /// REFUND—转入退款
        /// NOTPAY—未支付
        /// CLOSED—已关闭
        /// REVOKED—已撤销（刷卡支付） 
        /// USERPAYING--用户支付中
        /// PAYERROR--支付失败(其他原因，如银行返回失败)
        /// </summary>

        public string trade_state { get; set; }

        /// <summary>
        /// 银行类型，采用字符串类型的银行标识   
        /// </summary>
        public string bank_type { get; set; }

        /// <summary>
        /// 订单总金额，单位为分 
        /// </summary>
        public string total_fee { get; set; }

        /// <summary>
        /// 应结订单金额=订单金额-非充值代金券金额，应结订单金额 订单金额。 
        /// </summary>
        public string settlement_total_fee { get; set; }

        /// <summary>
        /// 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        public string fee_type { get; set; }

        /// <summary>
        /// 现金支付金额订单现金支付金额，详见支付金额
        /// </summary>
        public string cash_fee { get; set; }

        /// <summary>
        /// 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        public string cash_fee_type { get; set; }

        /// <summary>
        /// “代金券”金额 订单金额，订单金额-“代金券”金额=现金支付金额，详见支付金额
        /// </summary>
        public string coupon_fee { get; set; }

        /// <summary>
        /// 代金券使用数量 
        /// </summary>
        public string coupon_count { get; set; }

        /// <summary>
        /// 微信支付订单号 
        /// </summary>
        public string transaction_id { get; set; }

        /// <summary>
        /// 商户系统的订单号，与请求一致。 
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 商家数据包
        /// 附加数据，原样返回 
        /// </summary>
        public string attach { get; set; }

        /// <summary>
        /// 订单支付时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则 
        /// </summary>
        public string time_end { get; set; }

        /// <summary>
        /// 对当前查询订单状态的描述和下一步操作的指引
        /// </summary>
        public string trade_state_desc { get; set; }
    }
}
