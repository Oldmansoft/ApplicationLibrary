using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Data
{
    /// <summary>
    /// 签名输入
    /// 注意事项
    /// 1.签名用的noncestr和timestamp必须与wx.config中的nonceStr和timestamp相同。
    /// 2.签名用的url必须是调用JS接口页面的完整URL。
    /// </summary>
    public class SignatureRequest
    {
        /// <summary>
        /// 票据
        /// </summary>
        public string jsapi_ticket { get; set; }

        /// <summary>
        /// 随机串
        /// </summary>
        public string noncestr { get; set; }

        /// <summary>
        /// 时间戳
        /// </summary>
        public long timestamp { get; set; }

        /// <summary>
        /// 当前网页的URL（不包含#及其后面部分）
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 生成拼接字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("jsapi_ticket=");
            result.Append(jsapi_ticket);
            result.Append("&noncestr=");
            result.Append(noncestr);
            result.Append("&timestamp=");
            result.Append(timestamp);
            result.Append("&url=");
            result.Append(url);
            return result.ToString();
        }
    }
}
