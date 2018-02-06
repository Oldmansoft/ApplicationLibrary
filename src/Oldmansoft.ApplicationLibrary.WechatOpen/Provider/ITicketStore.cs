using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Provider
{
    /// <summary>
    /// Js Api Ticket 存储器
    /// </summary>
    public interface ITicketStore : IStore<string, WechatOpen.Data.Ticket>
    {
    }
}
