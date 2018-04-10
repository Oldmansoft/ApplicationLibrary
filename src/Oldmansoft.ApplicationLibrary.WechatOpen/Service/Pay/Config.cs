using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay
{
    /// <summary>
    /// 支付配置
    /// </summary>
    public class Config : IConfig
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string AppId { get; private set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; private set; }

        /// <summary>
        /// 商户密钥
        /// </summary>
        public string MchKey { get; private set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="mchId"></param>
        /// <param name="mchKey"></param>
        public Config(string appId, string mchId, string mchKey)
        {
            if (string.IsNullOrWhiteSpace(appId)) throw new ArgumentNullException("appId");
            if (string.IsNullOrWhiteSpace(mchId)) throw new ArgumentNullException("mchId");
            if (string.IsNullOrWhiteSpace(mchKey)) throw new ArgumentNullException("mchKey");
            AppId = appId;
            MchId = mchId;
            MchKey = mchKey;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Signature<T>(T input)
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
                if (item.Key.ToLower() == "paysign") continue;
                if (string.IsNullOrWhiteSpace(item.Value)) continue;

                content.Append(item.Key.Trim());
                content.Append("=");
                content.Append(item.Value.Trim());
                content.Append("&");
            }
            content.Append("key=");
            content.Append(MchKey);
            var text = content.ToString();
            var result = text.GetMd5Hash();
            WechatOpen.Util.Logger.Debug(string.Format("{0}\r\nHash:{1}", text, result));
            return result;
        }
    }
}
