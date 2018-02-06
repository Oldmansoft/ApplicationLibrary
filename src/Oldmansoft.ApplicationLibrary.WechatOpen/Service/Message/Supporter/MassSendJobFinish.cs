using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Supporter
{
    /// <summary>
    /// 事件推送群发结果
    /// </summary>
    public class MassSendJobFinish : TemplateSendJobFinish
    {

        /// <summary>
        /// group_id下粉丝数；或者openid_list中的粉丝数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 过滤（过滤是指特定地区、性别的过滤、用户设置拒收的过滤，用户接收已超4条的过滤）后，准备发送的粉丝数
        /// </summary>
        public int FilterCount { get; set; }

        /// <summary>
        /// 发送成功的粉丝数
        /// </summary>
        public int SentCount { get; set; }

        /// <summary>
        /// 发送失败的粉丝数
        /// </summary>
        public int ErrorCount { get; set; }
    }
}
