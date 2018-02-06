using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Keyword
{
    /// <summary>
    /// 关键字消息类型
    /// </summary>
    public enum KeywordType
    {
        /// <summary>
        /// 点击消息
        /// </summary>
        Click = 1,
        /// <summary>
        /// 文本消息
        /// </summary>
        Input = 2,
        /// <summary>
        /// 点击和文本消息
        /// </summary>
        ClickAndInput = 3
    }
}
