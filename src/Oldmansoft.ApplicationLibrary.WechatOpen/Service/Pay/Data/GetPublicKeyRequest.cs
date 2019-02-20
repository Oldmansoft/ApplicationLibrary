using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Data
{
    /// <summary>
    /// 获取公钥请求
    /// </summary>
    public class GetPublicKeyRequest
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 签名类型
        /// </summary>
        public string sign_type { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        public GetPublicKeyRequest()
        {
            nonce_str = Guid.NewGuid().ToString("N");
            sign_type = "MD5";
        }
    }
}
