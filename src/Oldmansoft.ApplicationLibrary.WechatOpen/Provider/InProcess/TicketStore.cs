using Microsoft.Extensions.Caching.Memory;
using Oldmansoft.ApplicationLibrary.WechatOpen.Data;
using System;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider.InProcess
{
    class TicketStore : ITicketStore
    {
        private static readonly MemoryCache Memory = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Ticket Get(string key)
        {
            return Memory.Get(key) as Ticket;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, Ticket value)
        {
            Memory.Set(key, value, new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddSeconds(value.expires_in))
            });
        }
    }
}
