using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oldmansoft.ApplicationLibrary.WechatOpen.Provider.Data;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider.InProcess
{
    /// <summary>
    /// 位置存储器
    /// </summary>
    public class PositionStore : IPositionStore
    {
        private static System.Runtime.Caching.MemoryCache Memory = new System.Runtime.Caching.MemoryCache("PositionStore");

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
            Memory.Set(key, value, new System.Runtime.Caching.CacheItemPolicy() { SlidingExpiration = new TimeSpan(1, 0, 0) });
        }
    }
}
