using Microsoft.Extensions.Caching.Memory;
using Oldmansoft.ApplicationLibrary.WechatOpen.Provider.Data;
using System;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider.InProcess
{
    /// <summary>
    /// 位置存储器
    /// </summary>
    class PositionStore : IPositionStore
    {
        private static readonly MemoryCache Memory = new MemoryCache(new MemoryCacheOptions());

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Position Get(string key)
        {
            return Memory.Get(key) as Position;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(string key, Position value)
        {
            Memory.Set(key, value, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromHours(1)
            });
        }
    }
}
