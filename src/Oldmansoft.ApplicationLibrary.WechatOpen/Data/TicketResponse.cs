using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Data
{
    /// <summary>
    /// 票据结果
    /// </summary>
    public class TicketResponse
    {
        /// <summary>
        /// 票据
        /// </summary>
        public string ticket { get; set; }

        /// <summary>
        /// 过期秒数
        /// </summary>
        public int expires_in { get; set; }

        /// <summary>
        /// 刷新时间
        /// </summary>
        public DateTime RefreshTime { get; set; }

        /// <summary>
        /// 是否过期
        /// </summary>
        /// <returns></returns>
        public bool IsExpire()
        {
            return DateTime.Now.Subtract(RefreshTime).TotalSeconds > (expires_in - 60 * 5);
        }
    }
}
