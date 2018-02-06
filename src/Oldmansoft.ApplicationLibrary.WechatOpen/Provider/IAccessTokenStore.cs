using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider
{
    /// <summary>
    /// AccessToken 存储器
    /// </summary>
    public interface IAccessTokenStore : IStore<string, WechatOpen.Data.AccessToken>
    {
    }
}
