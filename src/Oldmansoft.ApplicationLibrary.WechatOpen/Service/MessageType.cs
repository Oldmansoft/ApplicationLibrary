using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public enum MessageType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        Text,

        /// <summary>
        /// 图片消息
        /// </summary>
        Image,

        /// <summary>
        /// 语音消息
        /// </summary>
        Voice,

        /// <summary>
        /// 视频消息
        /// </summary>
        Video,

        /// <summary>
        /// 小视频消息
        /// </summary>
        ShortVideo,

        /// <summary>
        /// 地理位置消息
        /// </summary>
        Location,

        /// <summary>
        /// 链接消息
        /// </summary>
        Link,

        /// <summary>
        /// 事件推送
        /// </summary>
        Event,

        /* 下面扩展类型，为内部使用 */
        /// <summary>
        /// 订阅事件
        /// </summary>
        Subscribe,

        /// <summary>
        /// 取消订阅事件
        /// </summary>
        Unsubscribe,

        /// <summary>
        /// 扫码事件
        /// </summary>
        Scan,

        /// <summary>
        /// 上报地理位置事件
        /// </summary>
        Position,

        /// <summary>
        /// 点击事件
        /// </summary>
        Click,

        /// <summary>
        /// 点击菜单跳转链接事件
        /// </summary>
        View,

        /// <summary>
        /// 事件推送群发结果
        /// </summary>
        MassSendJobFinish,

        /// <summary>
        /// 模版消息发送结果
        /// </summary>
        TemplateSendJobFinish
    }
}
