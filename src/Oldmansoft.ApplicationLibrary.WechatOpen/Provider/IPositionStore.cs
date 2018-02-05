using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider
{
    /// <summary>
    /// 位置存储器
    /// </summary>
    public interface IPositionStore : IStore<string, Data.Position>
    {
    }
}
