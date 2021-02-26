namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 退款查询返回
    /// </summary>
    public class RefundQueryResponse : Response
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
        /// 订单总退款次数
        /// 订单总共已发生的部分退款次数，当请求参数传入offset后有返回
        /// </summary>
        public int? total_refund_count { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        public string transaction_id { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public int total_fee { get; set; }

        /// <summary>
        /// 应结订单金额
        /// 当订单使用了免充值型优惠券后返回该参数，应结订单金额=订单金额-免充值优惠券金额。
        /// </summary>
        public int? settlement_total_fee { get; set; }

        /// <summary>
        /// 货币种类
        /// </summary>
        public string fee_type { get; set; }

        /// <summary>
        /// 现金支付金额
        /// </summary>
        public int cash_fee { get; set; }

        /// <summary>
        /// 退款笔数
        /// </summary>
        public int refund_count { get; set; }

        /// <summary>
        /// 退款项
        /// </summary>
        public RefundQueryResponseItem[] items { get; set; }
    }

    /// <summary>
    /// 退款查询返回项
    /// </summary>
    public class RefundQueryResponseItem
    {
        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string out_refund_no { get; set; }

        /// <summary>
        /// 微信退款单号
        /// </summary>
        public string refund_id { get; set; }

        /// <summary>
        /// 退款渠道
        /// ORIGINAL—原路退款
        /// BALANCE—退回到余额
        /// OTHER_BALANCE—原账户异常退到其他余额账户
        /// OTHER_BANKCARD—原银行卡异常退到其他银行卡
        /// </summary>
        public string refund_channel { get; set; }

        /// <summary>
        /// 申请退款金额
        /// </summary>
        public int refund_fee { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public int? settlement_refund_fee { get; set; }

        /// <summary>
        /// 总代金券退款金额
        /// </summary>
        public int? coupon_refund_fee { get; set; }

        /// <summary>
        /// 退款代金券使用数量
        /// </summary>
        public int? coupon_refund_count { get; set; }

        /// <summary>
        /// 代金券
        /// </summary>
        public RefundQueryResponseItemCoupon[] coupons { get; set; }

        /// <summary>
        /// 退款状态
        /// </summary>
        public string refund_status { get; set; }

        /// <summary>
        /// 退款资金来源
        /// REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款/基本账户
        /// REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款
        /// </summary>
        public string refund_account { get; set; }

        /// <summary>
        /// 退款入账账
        /// </summary>
        public string refund_recv_accout { get; set; }

        /// <summary>
        /// 退款成功时间
        /// </summary>
        public string refund_success_time { get; set; }
    }

    /// <summary>
    /// 退款查询返回项代金券
    /// </summary>
    public class RefundQueryResponseItemCoupon
    {
        /// <summary>
        /// 退款代金券ID
        /// </summary>
        public string coupon_refund_id { get; set; }

        /// <summary>
        /// 代金券类型
        /// CASH--充值代金券 
        /// NO_CASH---非充值优惠券
        /// </summary>
        public string coupon_type { get; set; }

        /// <summary>
        /// 单个代金券退款金额
        /// </summary>
        public int coupon_refund_fee { get; set; }
    }
}
