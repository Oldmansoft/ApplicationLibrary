using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// 证书支付
    /// </summary>
    public class CertificatePayment
    {
        /// <summary>
        /// 商户配置
        /// </summary>
        private IConfig Config { get; set; }

        /// <summary>
        /// 证书
        /// </summary>
        private X509Certificate2 Certificate { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="config">商户配置</param>
        /// <param name="certificate">证书</param>
        public CertificatePayment(IConfig config, X509Certificate2 certificate)
        {
            if (config == null) throw new ArgumentNullException("config");
            if (certificate == null) throw new ArgumentNullException("certificate");
            Config = config;
            Certificate = certificate;
        }

        private TResponse Request<TRequest, TResponse>(TRequest request, Uri uri)
            where TRequest : Data.Request
            where TResponse : Data.Response, new()
        {
            if (request == null) throw new ArgumentNullException("request");

            request.sign = Config.Signature(request);
            var xml = Util.XmlSerializer.Serialize(request).InnerXml;
            var handler = new System.Net.Http.WebRequestHandler();
            handler.ClientCertificateOptions = System.Net.Http.ClientCertificateOption.Manual;
            handler.UseDefaultCredentials = false;
            handler.ClientCertificates.Add(Certificate);
            string content;
            using (var client = new System.Net.Http.HttpClient(handler))
            {
                var response = client.PostAsync(uri, new System.Net.Http.StringContent(xml, Encoding.UTF8)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }

            var dom = new System.Xml.XmlDocument();
            dom.LoadXml(content);
            var result = Util.XmlSerializer.Deserialize<TResponse>(dom);
            if (result.return_code == "FAIL")
            {
                throw new WechatException(result.return_msg);
            }
            if (result.result_code == "FAIL")
            {
                throw new WechatBusinessException(result.err_code, result.err_code_des);
            }
            return result;
        }
        
        /// <summary>
        /// 申请退款
        /// </summary>
        /// <param name="transaction_id"></param>
        /// <param name="total_fee"></param>
        /// <param name="refund_fee"></param>
        /// <param name="refund_desc"></param>
        /// <param name="out_refund_no"></param>
        /// <param name="notify_url"></param>
        /// <returns></returns>
        public Data.RefundResponse RefundByTransactionId(string transaction_id, int total_fee, int refund_fee, string refund_desc, string out_refund_no, string notify_url)
        {
            if (string.IsNullOrEmpty(transaction_id)) throw new ArgumentNullException("transaction_id");
            if (string.IsNullOrEmpty(out_refund_no)) throw new ArgumentNullException("out_refund_no");

            var request = new Data.RefundRequest();
            request.appid = Config.AppId;
            request.mch_id = Config.MchId;
            request.transaction_id = transaction_id;
            request.total_fee = total_fee;
            request.refund_fee = refund_fee;
            request.refund_desc = refund_desc;
            request.out_refund_no = out_refund_no;
            request.notify_url = notify_url;
            return Request<Data.RefundRequest, Data.RefundResponse>(request, new Uri("https://api.mch.weixin.qq.com/secapi/pay/refund"));
        }

        /// <summary>
        /// 申请退款
        /// </summary>
        /// <param name="out_trade_no"></param>
        /// <param name="total_fee"></param>
        /// <param name="refund_fee"></param>
        /// <param name="refund_desc"></param>
        /// <param name="out_refund_no"></param>
        /// <param name="notify_url"></param>
        /// <returns></returns>
        public Data.RefundResponse RefundByOutTradeNo(string out_trade_no, int total_fee, int refund_fee, string refund_desc, string out_refund_no, string notify_url)
        {
            if (string.IsNullOrEmpty(out_trade_no)) throw new ArgumentNullException("out_trade_no");
            if (string.IsNullOrEmpty(out_refund_no)) throw new ArgumentNullException("out_refund_no");

            var request = new Data.RefundRequest();
            request.appid = Config.AppId;
            request.mch_id = Config.MchId;
            request.out_trade_no = out_trade_no;
            request.total_fee = total_fee;
            request.refund_fee = refund_fee;
            request.refund_desc = refund_desc;
            request.out_refund_no = out_refund_no;
            request.notify_url = notify_url;
            return Request<Data.RefundRequest, Data.RefundResponse>(request, new Uri("https://api.mch.weixin.qq.com/secapi/pay/refund"));
        }

        /// <summary>
        /// 企业付款到微信
        /// </summary>
        /// <param name="partnerTradeNo">商户订单号</param>
        /// <param name="openId">用户openid</param>
        /// <param name="amount">企业付款金额，单位为分</param>
        /// <param name="desc">企业付款备注</param>
        /// <param name="clientIp">Ip地址</param>
        /// <returns></returns>
        public Data.TransferToWechatResponse TransferToWechat(string partnerTradeNo, string openId, int amount, string desc, string clientIp)
        {
            var request = new Data.TransferToWechatRequest();
            request.mch_appid = Config.AppId;
            request.mchid = Config.MchId;
            request.partner_trade_no = partnerTradeNo;
            request.openid = openId;
            request.check_name = "NO_CHECK";
            request.amount = amount;
            request.desc = desc;
            request.spbill_create_ip = clientIp;
            return Request<Data.TransferToWechatRequest, Data.TransferToWechatResponse>(request, new Uri("https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers"));
        }

        /// <summary>
        /// 企业付款到微信
        /// 强校验真实姓名
        /// </summary>
        /// <param name="partnerTradeNo">商户订单号</param>
        /// <param name="openId">用户openid</param>
        /// <param name="userName">收款用户姓名</param>
        /// <param name="amount">企业付款金额，单位为分</param>
        /// <param name="desc">企业付款备注</param>
        /// <param name="clientIp">Ip地址</param>
        /// <returns></returns>
        public Data.TransferToWechatResponse TransferToWechat(string partnerTradeNo, string openId, string userName, int amount, string desc, string clientIp)
        {
            var request = new Data.TransferToWechatRequest();
            request.mch_appid = Config.AppId;
            request.mchid = Config.MchId;
            request.partner_trade_no = partnerTradeNo;
            request.openid = openId;
            request.check_name = "FORCE_CHECK";
            request.re_user_name = userName;
            request.amount = amount;
            request.desc = desc;
            request.spbill_create_ip = clientIp;
            return Request<Data.TransferToWechatRequest, Data.TransferToWechatResponse>(request, new Uri("https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers"));
        }
        
        /// <summary>
        /// 查询企业付款
        /// </summary>
        /// <param name="partner_trade_no"></param>
        /// <returns></returns>
        public Data.GetTransferInfoResponse GetTransferInfo(string partner_trade_no)
        {
            var request = new Data.GetTransferInfoRequest();
            request.appid = Config.AppId;
            request.mch_id = Config.MchId;
            request.partner_trade_no = partner_trade_no;
            return Request<Data.GetTransferInfoRequest, Data.GetTransferInfoResponse>(request, new Uri("https://api.mch.weixin.qq.com/mmpaymkttransfers/gettransferinfo"));
        }

        /// <summary>
        /// 获取公钥
        /// </summary>
        /// <returns></returns>
        public Data.GetPublicKeyResponse GetPublicKey()
        {
            var request = new Data.GetPublicKeyRequest();
            request.mch_id = Config.MchId;
            return Request<Data.GetPublicKeyRequest, Data.GetPublicKeyResponse>(request, new Uri("https://fraud.mch.weixin.qq.com/risk/getpublickey"));
        }

        /// <summary>
        /// 企业付款到银行
        /// </summary>
        /// <param name="partnerTradeNo"></param>
        /// <param name="encBankNo"></param>
        /// <param name="encTrueName"></param>
        /// <param name="bankCode"></param>
        /// <param name="amount"></param>
        /// <param name="desc"></param>
        /// <returns></returns>
        public Data.TransferToBankResponse TransferToBank(string partnerTradeNo, string encBankNo, string encTrueName, string bankCode, int amount, string desc)
        {
            var request = new Data.TransferToBankRequest();
            request.mch_id = Config.MchId;
            request.partner_trade_no = partnerTradeNo;
            request.enc_bank_no = encBankNo;
            request.enc_true_name = encTrueName;
            request.bank_code = bankCode;
            request.amount = amount;
            request.desc = desc;
            return Request<Data.TransferToBankRequest, Data.TransferToBankResponse>(request, new Uri("https://api.mch.weixin.qq.com/mmpaysptrans/pay_bank"));
        }

        /// <summary>
        /// 查询企业付款银行卡
        /// </summary>
        /// <param name="partnerTradeNo"></param>
        /// <returns></returns>
        public Data.QueryBankResponse QueryBank(string partnerTradeNo)
        {
            var request = new Data.QueryBankRequest();
            request.mch_id = Config.MchId;
            request.partner_trade_no = partnerTradeNo;
            return Request<Data.QueryBankRequest, Data.QueryBankResponse>(request, new Uri("https://api.mch.weixin.qq.com/mmpaysptrans/query_bank"));
        }
    }
}
