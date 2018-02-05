using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider
{
    /// <summary>
    /// 用户 Token 存储器
    /// </summary>
    public interface IUserTokenStore : IStore<string, WechatOpen.Data.UserTokenResponse>
    {
    }
}
