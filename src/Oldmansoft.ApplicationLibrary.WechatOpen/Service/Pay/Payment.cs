using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private IConfig Config { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="config"></param>
        public Payment(IConfig config)
        {
            if (config == null) throw new ArgumentNullException();
            Config = config;
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
        public Data.UnifiedorderRequest CreateUnifiedorder4Jsapi(string outTradeNo, string title, int totalFee, string notifyUrl, string openId)
        {
            if (string.IsNullOrEmpty(openId)) throw new ArgumentNullException("openId");

            var result = new Data.UnifiedorderRequest(Config.AppId, Config.MchId, outTradeNo, title, totalFee, notifyUrl);
            result.trade_type = "JSAPI";
            result.openid = openId;
            return result;
        }

        /// <summary>
        /// 下单请求
        /// </summary>
        /// <param name="outTradeNo">商户订单号</param>
        /// <param name="title">商品或支付单简要描述</param>
        /// <param name="totalFee">订单总金额，单位为分</param>
        /// <param name="notifyUrl">接收微信支付异步通知回调地址，通知url必须为直接可访问的url，不能携带参数。</param>
        /// <param name="type">交易类型</param>
        /// <returns></returns>
        public Data.UnifiedorderRequest CreateUnifiedorder(string outTradeNo, string title, int totalFee, string notifyUrl, PayType type)
        {
            var result = new Data.UnifiedorderRequest(Config.AppId, Config.MchId, outTradeNo, title, totalFee, notifyUrl);
            result.trade_type = type.ToString();
            return result;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Sign<T>(T input)
            where T : class
        {
            if (input == null) throw new ArgumentNullException();
            var sorted = new SortedDictionary<string, string>();
            foreach (var property in typeof(T).GetProperties())
            {
                var value = property.GetValue(input);
                if (value == null) continue;
                sorted.Add(property.Name, value.ToString());
            }

            var content = new StringBuilder();
            foreach (var item in sorted)
            {
                if (item.Key.ToLower() == "sign") continue;
                if (item.Key.ToLower() == "signtype") continue;
                if (string.IsNullOrWhiteSpace(item.Value)) continue;
                
                content.Append(item.Key.Trim());
                content.Append("=");
                content.Append(item.Value.Trim());
                content.Append("&");
            }
            content.Append("key=");
            content.Append(Config.MchKey);
            return content.ToString().GetMd5Hash();
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="dom"></param>
        /// <returns></returns>
        public string Sign(System.Xml.XmlDocument dom)
        {
            var content = new StringBuilder();
            var root = dom.DocumentElement;
            for (var i = 0; i < root.ChildNodes.Count; i++)
            {
                var node = root.ChildNodes[i];
                if (node.Name.ToLower() == "sign") continue;
                if (node.Name.ToLower() == "signtype") continue;

                content.Append(node.Name);
                content.Append("=");
                content.Append(node.GetText());
                content.Append("&");
            }
            content.Append("key=");
            content.Append(Config.MchKey);
            return content.ToString().GetMd5Hash();
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Data.UnifiedorderResponse Unifiedorder(Data.UnifiedorderRequest request)
        {
            if (request == null) throw new ArgumentNullException();
            request.sign = Sign(request);
            var xml = Util.XmlSerializer.Serialize(request).InnerXml;

            string content;
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = client.PostAsync(new Uri("https://api.mch.weixin.qq.com/pay/unifiedorder"), new System.Net.Http.StringContent(xml)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }

            var dom = new System.Xml.XmlDocument();
            dom.LoadXml(content);
            return Util.XmlSerializer.Deserialize<Data.UnifiedorderResponse>(dom);
        }
        
        /// <summary>
        /// 获取 Jsapi 内容
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public Data.JsapiOrderRequest FromJsapi(Data.UnifiedorderResponse response)
        {
            var result = new Data.JsapiOrderRequest();
            result.appId = Config.AppId;
            result.package = string.Format("prepay_id={0}", response.prepay_id);
            result.timeStamp = DateTime.Now.GetUnixTimestamp().ToString();
            result.signType = "MD5";
            result.nonceStr = Guid.NewGuid().ToString("N");
            result.paySign = Sign(result);
            return result;
        }

        /// <summary>
        /// 获取 App 内容
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public Data.AppOrderRequest FromApp(Data.UnifiedorderResponse response)
        {
            var result = new Data.AppOrderRequest();
            result.appid = Config.AppId;
            result.partnerid = Config.MchId;
            result.prepayid = response.prepay_id;
            result.package = "Sign=WXPay";
            result.timestamp = DateTime.Now.GetUnixTimestamp().ToString();
            result.noncestr = Guid.NewGuid().ToString("N");
            return result;
        }

        /// <summary>
        /// 获取二维码地址
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public string FromNavite(Data.UnifiedorderResponse response)
        {
            return response.code_url;
        }
        
        /// <summary>
        /// 解析订单
        /// </summary>
        /// <param name="dom"></param>
        /// <returns></returns>
        public Data.OrderResponse Parse(System.Xml.XmlDocument dom)
        {
            return Util.XmlSerializer.Deserialize<Data.OrderResponse>(dom);
        }

        /// <summary>
        /// 查询订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Data.OrderResponse OrderQuery(Data.OrderRequestRequest request)
        {
            if (request == null) throw new ArgumentNullException();
            request.sign = Sign(request);
            var xml = Util.XmlSerializer.Serialize(request).InnerXml;

            string content;
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = client.PostAsync(new Uri("https://api.mch.weixin.qq.com/pay/orderquery"), new System.Net.Http.StringContent(xml)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }

            var dom = new System.Xml.XmlDocument();
            dom.LoadXml(content);
            return Util.XmlSerializer.Deserialize<Data.OrderResponse>(dom);
        }
    }
}
