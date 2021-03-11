using System;
using System.Collections.Generic;
using System.Text;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// 支付
    /// </summary>
    public class Payment
    {
        /// <summary>
        /// 成功消息
        /// </summary>
        public static readonly string Success = "<xml><return_code><![CDATA[SUCCESS]]></return_code><return_msg><![CDATA[OK]]></return_msg></xml>";

        /// <summary>
        /// 商户配置
        /// </summary>
        public IConfig Config { get; private set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="config"></param>
        public Payment(IConfig config)
        {
            Config = config ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// 公众号支付下单请求
        /// </summary>
        /// <param name="outTradeNo">商户订单号</param>
        /// <param name="title">商品或支付单简要描述</param>
        /// <param name="totalFee">订单总金额，单位为分</param>
        /// <param name="notifyUrl">接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。</param>
        /// <param name="openId">用户在商户appid下的唯一标识</param>
        /// <returns></returns>
        public UnifiedorderJsapi CreateUnifiedorderJsapi(string outTradeNo, string title, int totalFee, string notifyUrl, string openId)
        {
            if (string.IsNullOrEmpty(openId)) throw new ArgumentNullException("openId");

            var result = new Data.UnifiedorderRequest(Config.AppId, Config.MchId, outTradeNo, title, totalFee, notifyUrl)
            {
                trade_type = "JSAPI",
                openid = openId
            };
            return new UnifiedorderJsapi(Config, result);
        }

        /// <summary>
        /// App 下单请求
        /// </summary>
        /// <param name="outTradeNo">商户订单号</param>
        /// <param name="title">商品或支付单简要描述</param>
        /// <param name="totalFee">订单总金额，单位为分</param>
        /// <param name="notifyUrl">接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。</param>
        /// <returns></returns>
        public UnifiedorderApp CreateUnifiedorderApp(string outTradeNo, string title, int totalFee, string notifyUrl)
        {
            var result = new Data.UnifiedorderRequest(Config.AppId, Config.MchId, outTradeNo, title, totalFee, notifyUrl)
            {
                trade_type = "APP"
            };
            return new UnifiedorderApp(Config, result);
        }

        /// <summary>
        /// Navite 下单请求
        /// </summary>
        /// <param name="outTradeNo">商户订单号</param>
        /// <param name="title">商品或支付单简要描述</param>
        /// <param name="totalFee">订单总金额，单位为分</param>
        /// <param name="notifyUrl">接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。</param>
        /// <returns></returns>
        public UnifiedorderNavite CreateUnifiedorderNative(string outTradeNo, string title, int totalFee, string notifyUrl)
        {
            var result = new Data.UnifiedorderRequest(Config.AppId, Config.MchId, outTradeNo, title, totalFee, notifyUrl)
            {
                trade_type = "NATIVE"
            };
            return new UnifiedorderNavite(Config, result);
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="dom"></param>
        /// <returns></returns>
        public string Signature(System.Xml.XmlDocument dom)
        {
            var sorted = new SortedDictionary<string, string>();
            var root = dom.DocumentElement;
            for (var i = 0; i < root.ChildNodes.Count; i++)
            {
                var node = root.ChildNodes[i];
                if (node.Name.ToLower() == "sign") continue;
                if (node.Name.ToLower() == "signtype") continue;
                sorted.Add(node.Name, node.GetText());
            }

            var content = new StringBuilder();
            foreach (var item in sorted)
            {
                content.Append(item.Key);
                content.Append("=");
                content.Append(item.Value);
                content.Append("&");
            }
            content.Append("key=");
            content.Append(Config.MchKey);
            var text = content.ToString();
            var result = text.GetMd5Hash();
            return result;
        }
        
        /// <summary>
        /// 解析订单
        /// </summary>
        /// <param name="dom"></param>
        /// <returns></returns>
        public Data.OrderResponse ParseOrder(System.Xml.XmlDocument dom)
        {
            var result = Util.XmlSerializer.Deserialize<Data.OrderResponse>(dom);
            if (result.return_code == "FAIL")
            {
                throw new WechatException(result.return_msg);
            }
            if (Signature(dom) != result.sign) throw new SignatureException("签名不一致");
            return result;
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Data.OrderResponse OrderQuery(Data.OrderQueryRequest request)
        {
            if (request == null) throw new ArgumentNullException();
            request.sign = Config.Signature(request);
            var xml = Util.XmlSerializer.Serialize(request).InnerXml;

            string content;
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = client.PostAsync(new Uri("https://api.mch.weixin.qq.com/pay/orderquery"), new System.Net.Http.StringContent(xml, Encoding.UTF8)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }

            var dom = new System.Xml.XmlDocument();
            dom.LoadXml(content);
            var result = Util.XmlSerializer.Deserialize<Data.OrderResponse>(dom);
            if (result.return_code == "FAIL")
            {
                throw new WechatException(result.return_msg);
            }
            return result;
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="out_trade_no"></param>
        /// <returns></returns>
        public Data.OrderResponse OrderQuery(string out_trade_no)
        {
            if (string.IsNullOrWhiteSpace(out_trade_no)) throw new ArgumentNullException();

            var request = new Data.OrderQueryRequest
            {
                appid = Config.AppId,
                mch_id = Config.MchId,
                nonce_str = Guid.NewGuid().ToString("N"),
                out_trade_no = out_trade_no
            };

            return OrderQuery(request);
        }

        /// <summary>
        /// 退款查询
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Data.RefundQueryResponse RefundQuery(Data.RefundQueryRequest request)
        {
            if (request == null) throw new ArgumentNullException("request");
            request.sign = Config.Signature(request);
            var xml = Util.XmlSerializer.Serialize(request).InnerXml;
            string content;
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = client.PostAsync(new Uri("https://api.mch.weixin.qq.com/pay/refundquery"), new System.Net.Http.StringContent(xml, Encoding.UTF8)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }

            var dom = new System.Xml.XmlDocument();
            dom.LoadXml(content);
            var result = Util.XmlSerializer.Deserialize<Data.RefundQueryResponse>(dom);
            if (result.return_code == "FAIL")
            {
                throw new WechatException(result.return_msg);
            }
            if (result.result_code == "FAIL")
            {
                throw new WechatBusinessException(result.err_code, result.err_code_des);
            }
            result.items = new Data.RefundQueryResponseItem[result.refund_count];
            for (var i = 0; i < result.items.Length; i++)
            {
                var item = new Data.RefundQueryResponseItem();
                foreach (var property in typeof(Data.RefundQueryResponseItem).GetProperties())
                {
                    var value = dom.DocumentElement.GetText(string.Format("{0}_{1}", property.Name, i));
                    property.SetAutoValue(item, value);
                }
                result.items[i] = item;
                if (!item.coupon_refund_count.HasValue || item.coupon_refund_count.Value == 0) continue;
                item.coupons = new Data.RefundQueryResponseItemCoupon[item.coupon_refund_count.Value];
                for (var j = 0; j < item.coupons.Length; j++)
                {
                    var coupon = new Data.RefundQueryResponseItemCoupon();
                    foreach (var property in typeof(Data.RefundQueryResponseItemCoupon).GetProperties())
                    {
                        var value = dom.DocumentElement.GetText(string.Format("{0}_{1}_{2}", property.Name, i, j));
                        property.SetAutoValue(coupon, value);
                    }
                    item.coupons[j] = coupon;
                }
            }
            return result;
        }

        /// <summary>
        /// 退款查询
        /// </summary>
        /// <param name="value">微信生成的退款单号</param>
        /// <returns></returns>
        public Data.RefundQueryResponse RefundQueryByRefundId(string value)
        {
            var request = new Data.RefundQueryRequest
            {
                appid = Config.AppId,
                mch_id = Config.MchId,
                nonce_str = Guid.NewGuid().ToString("N"),
                refund_id = value
            };
            return RefundQuery(request);
        }

        /// <summary>
        /// 退款查询
        /// </summary>
        /// <param name="value">商户系统内部订单号</param>
        /// <returns></returns>
        public Data.RefundQueryResponse RefundQueryByOutTradeNo(string value)
        {
            var request = new Data.RefundQueryRequest
            {
                appid = Config.AppId,
                mch_id = Config.MchId,
                nonce_str = Guid.NewGuid().ToString("N"),
                out_trade_no = value
            };
            return RefundQuery(request);
        }

        /// <summary>
        /// 退款查询
        /// </summary>
        /// <param name="value">微信订单号</param>
        /// <returns></returns>
        public Data.RefundQueryResponse RefundQueryByTransactionId(string value)
        {
            var request = new Data.RefundQueryRequest
            {
                appid = Config.AppId,
                mch_id = Config.MchId,
                nonce_str = Guid.NewGuid().ToString("N"),
                transaction_id = value
            };
            return RefundQuery(request);
        }

        /// <summary>
        /// 下载交易账单
        /// </summary>
        public string DownloadBill(Data.DownloadBillRequest request)
        {
            if (request == null) throw new ArgumentNullException();
            request.sign = Config.Signature(request);
            var xml = Util.XmlSerializer.Serialize(request).InnerXml;

            string content;
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = client.PostAsync(new Uri("https://api.mch.weixin.qq.com/pay/downloadbill"), new System.Net.Http.StringContent(xml, Encoding.UTF8)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }
            if (string.IsNullOrWhiteSpace(content) || content.Substring(0, 5) == "<xml>")
            {
                var dom = new System.Xml.XmlDocument();
                dom.LoadXml(content);
                var result = Util.XmlSerializer.Deserialize<Data.DownloadBillFailResponse>(dom);
                if (result.return_code == "FAIL")
                {
                    throw new WechatException(result.return_msg);
                }
            }
            return content;
        }

        /// <summary>
        /// 下载交易账单
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public string DownloadBill(DateTime date)
        {
            var request = new Data.DownloadBillRequest
            {
                appid = Config.AppId,
                mch_id = Config.MchId,
                nonce_str = Guid.NewGuid().ToString("N"),
                bill_type = "ALL",
                bill_date = date.ToString("yyyyMMdd")
            };
            return DownloadBill(request);
        }
    }
}
