using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider
{
    /// <summary>
    /// 存储器
    /// </summary>
    /// <typeparam name="TKey">参数</typeparam>
    /// <typeparam name="TValue">存值</typeparam>
    public interface IStore<TKey, TValue>
    {
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set(TKey key, TValue value);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TValue Get(TKey key);
    }
}
