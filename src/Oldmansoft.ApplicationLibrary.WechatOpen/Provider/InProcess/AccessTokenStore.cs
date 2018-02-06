using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider.InProcess
{
    class AccessTokenStore : IAccessTokenStore
    {
        private static System.Runtime.Caching.MemoryCache Memory = new System.Runtime.Caching.MemoryCache("AccessTokenStore");

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public AccessTokenResponse Get(string key)
        {
            return Memory.Get(key) as AccessTokenResponse;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, AccessTokenResponse value)
        {
            Memory.Set(key, value, new System.Runtime.Caching.CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddSeconds(value.expires_in) });
        }
    }
}
