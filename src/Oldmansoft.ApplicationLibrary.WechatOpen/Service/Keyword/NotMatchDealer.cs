using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Keyword
{
    /// <summary>
    /// 关键字不匹配处理
    /// </summary>
    public abstract class NotMatchDealer : KeywordDealer
    {
        protected override string[] Keywords
        {
            get
            {
                return null;
            }
        }
    }
}
