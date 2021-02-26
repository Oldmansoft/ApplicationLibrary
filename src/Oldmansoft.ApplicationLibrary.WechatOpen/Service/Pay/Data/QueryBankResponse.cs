namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 查询企业付款银行卡返回
    /// </summary>
    public class QueryBankResponse : Response
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
        /// 微信企业付款单号
        /// </summary>
        public string payment_no { get; set; }

        /// <summary>
        /// 银行卡号
        /// </summary>
        public string bank_no_md5 { get; set; }

        /// <summary>
        /// 用户真实姓名
        /// </summary>
        public string true_name_md5 { get; set; }

        /// <summary>
        /// 代付金额
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// 代付单状态
        /// PROCESSING（处理中，如有明确失败，则返回额外失败原因；否则没有错误原因）
        /// SUCCESS（付款成功）
        /// FAILED（付款失败,需要替换付款单号重新发起付款）
        /// BANK_FAIL（银行退票，订单状态由付款成功流转至退票,退票时付款金额和手续费会自动退还）
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        public int cmms_amt { get; set; }

        /// <summary>
        /// 商户下单时间
        /// </summary>
        public string create_time { get; set; }

        /// <summary>
        /// 成功付款时间
        /// 无法保证银行不会退票
        /// </summary>
        public string pay_succ_time { get; set; }

        /// <summary>
        /// 失败原因
        /// </summary>
        public string reason { get; set; }
    }
}
