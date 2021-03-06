﻿namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 查询企业付款请求
    /// </summary>
    public class GetTransferInfoRequest : Request
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string partner_trade_no { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 商户号的appid
        /// </summary>
        public string appid { get; set; }
    }
}
