using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 配置
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// 应用 Id
        /// </summary>
        string AppId { get; }

        /// <summary>
        /// 应用密钥
        /// </summary>
        string AppSecret { get; }
    }
}
