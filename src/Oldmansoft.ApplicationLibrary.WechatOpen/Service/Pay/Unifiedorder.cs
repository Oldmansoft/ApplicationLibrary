using System;
using System.Text;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// 统一下单
    /// </summary>
    public abstract class Unifiedorder
    {
        /// <summary>
        /// 支付
        /// </summary>
        protected IConfig Config { get; private set; }

        private Data.UnifiedorderRequest Request { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="config"></param>
        /// <param name="request"></param>
        public Unifiedorder(IConfig config, Data.UnifiedorderRequest request)
        {
            Config = config ?? throw new ArgumentNullException("config");
            Request = request ?? throw new ArgumentNullException("request");
        }
        
        /// <summary>
        /// 获取下单结果
        /// </summary>
        /// <returns></returns>
        protected Data.UnifiedorderResponse GetResponse()
        {
            Request.sign = Config.Signature(Request);
            var xml = Util.XmlSerializer.Serialize(Request).InnerXml;
            string content;
            using (var client = new System.Net.Http.HttpClient())
            {
                var response = client.PostAsync(new Uri("https://api.mch.weixin.qq.com/pay/unifiedorder"), new System.Net.Http.StringContent(xml, Encoding.UTF8)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }
            var dom = new System.Xml.XmlDocument();
            dom.LoadXml(content);
            var result = Util.XmlSerializer.Deserialize<Data.UnifiedorderResponse>(dom);
            if (result.return_code == "FAIL")
            {
                WechatOpen.Util.Logger.Warn(string.Format("输入:\r\n{0}\r\n输出:\r\n{1}", xml, content));
                throw new WechatException(result.return_msg);
            }
            return result;
        }
    }
}
