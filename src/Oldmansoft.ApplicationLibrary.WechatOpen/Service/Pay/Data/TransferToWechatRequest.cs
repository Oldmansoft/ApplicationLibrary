using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 企业付款到零钱请求
    /// </summary>
    public class TransferToWechatRequest
    {
        /// <summary>
        /// 商户账号appid
        /// 申请商户号的appid或商户号绑定的appid
        /// </summary>
        public string mch_appid { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string mchid { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        public string device_info { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 商户订单号
        /// 商户订单号，需保持唯一性(只能是字母或者数字，不能包含有其他字符)
        /// </summary>
        public string partner_trade_no { get; set; }

        /// <summary>
        /// 商户appid下，某用户的openid
        /// </summary>
        public string openid { get; set; }

        /// <summary>
        /// 校验用户姓名选项
        /// NO_CHECK：不校验真实姓名 
        /// FORCE_CHECK：强校验真实姓名
        /// </summary>
        public string check_name { get; set; }

        /// <summary>
        /// 收款用户姓名
        /// </summary>
        public string re_user_name { get; set; }

        /// <summary>
        /// 企业付款金额，单位为分
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// 企业付款备注
        /// </summary>
        public string desc { get; set; }

        /// <summary>
        /// Ip地址
        /// 该IP同在商户平台设置的IP白名单中的IP没有关联，该IP可传用户端或者服务端的IP。
        /// </summary>
        public string spbill_create_ip { get; set; }
    }
}
