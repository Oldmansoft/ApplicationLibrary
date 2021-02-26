using System;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 统一下单请求
    /// </summary>
    public class UnifiedorderRequest
    {
        /// <summary>
        /// 公众账号ID
        /// 微信分配的公众账号ID（企业号corpid即为此appId） 
        /// </summary>
        public string appid { get; set; }

        /// <summary>
        /// 商户号，根据appid ，库内部获取 
        /// 微信支付分配的商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 设备号，非必需
        /// </summary>
        public string device_info { get; set; }

        /// <summary>
        /// 随机字符串，库内部生成
        /// 随机字符串，不长于32位。推荐随机数生成算法
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名，（根据key 库内部生成）
        /// 签名，详见签名生成算法
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 商品描述
        /// 商品或支付单简要描述
        /// </summary>
        public string body { get; set; }

        /// <summary>
        /// 商品详情，非必需
        /// 商品详细列表，使用Json格式，传输签名前请务必使用CDATA标签将JSON文本串保护起来。
        /// </summary>
        public string detail { get; set; }

        /// <summary>
        /// 附加数据(如：深圳分店),非必需
        /// 在查询API和支付通知中原样返回，该字段主要用于商户携带订单的自定义数据
        /// </summary>
        public string attach { get; set; }

        /// <summary>
        /// 商户订单号
        /// 商户系统内部的订单号,32个字符内、可包含字母, 其他说明见商户订单号
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 货币类型,非必需
        /// 符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// </summary>
        public string fee_type { get; set; }

        /// <summary>
        /// 总金额
        /// 订单总金额，单位为分，详见支付金额
        /// </summary>
        public int total_fee { get; set; }

        /// <summary>
        /// 终端IP
        /// APP和网页支付提交用户端ip，Native支付填调用微信支付API的机器IP
        /// </summary>
        public string spbill_create_ip { get; set; }

        /// <summary>
        /// 交易起始时间,非必需
        /// 订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。其他详见时间规则
        /// </summary>
        public string time_start { get; set; }

        /// <summary>
        /// 交易结束时间,非必需
        /// 订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。其他详见时间规则
        /// 注意：最短失效时间间隔必须大于5分钟
        /// </summary>
        public string time_expire { get; set; }

        /// <summary>
        /// 商品标记,非必需
        /// 商品标记，代金券或立减优惠功能的参数，说明详见代金券或立减优惠
        /// </summary>
        public string goods_tag { get; set; }

        /// <summary>
        /// 接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。
        /// </summary>
        public string notify_url { get; set; }

        /// <summary>
        /// 交易类型
        /// 取值如下：JSAPI[微信JS]，NATIVE[二维码]，APP，详细说明见参数规定
        /// </summary>
        public string trade_type { get; set; }

        /// <summary>
        /// 商品ID,非必需
        /// trade_type=NATIVE，此参数必传。此id为二维码中包含的商品ID，商户自行定义。
        /// </summary>
        public string product_id { get; set; }

        /// <summary>
        /// 指定支付方式,非必需
        /// no_credit--指定不能使用信用卡支付
        /// </summary>
        public string limit_pay { get; set; }

        /// <summary>
        /// 用户标识,非必需
        /// trade_type=JSAPI，此参数必传，用户在商户appid下的唯一标识。openid如何获取，
        /// 可参考【获取openid】。企业号请使用【企业号OAuth2.0接口】获取企业号内成员userid，再调用【企业号userid转openid接口】进行转换
        /// </summary>
        public string openid { get; set; }

        internal UnifiedorderRequest(string appId, string mchId, string outTradeNo, string title, int totalFee, string notifyUrl)
        {
            if (string.IsNullOrEmpty(outTradeNo)) throw new ArgumentNullException("outTradeNo");
            if (string.IsNullOrEmpty(title)) throw new ArgumentNullException("title");
            if (string.IsNullOrEmpty(notifyUrl)) throw new ArgumentNullException("notifyUrl");

            appid = appId;
            mch_id = mchId;
            time_expire = DateTime.Now.AddMinutes(5).AddSeconds(1).ToString("yyyyMMddHHmmss");
            nonce_str = Guid.NewGuid().ToString("N");

            total_fee = totalFee;
            out_trade_no = outTradeNo;
            body = title.CutByUtf8(105);
            notify_url = notifyUrl;
        }
    }
}
