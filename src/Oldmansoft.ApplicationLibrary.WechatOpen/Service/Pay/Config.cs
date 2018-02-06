﻿using System;
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
    }
}
