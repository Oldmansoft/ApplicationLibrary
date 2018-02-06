using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Message.Data
{
    /// <summary>
    /// 回复消息
    /// </summary>
    public abstract class ReplyMessage
    {
        /// <summary>
        /// 文档
        /// </summary>
        internal XmlDocument Document { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        internal abstract string Type { get; }

        /// <summary>
        /// 获取消息的 Xml 元素列表
        /// </summary>
        /// <returns></returns>
        internal List<XmlElement> GetElements()
        {
            List<XmlElement> result = new List<XmlElement>();
            SetBody(result);
            return result;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="elements"></param>
        protected abstract void SetBody(List<XmlElement> elements);

        /// <summary>
        /// 空对象
        /// </summary>
        internal readonly static ReplyMessage Null = new ReplyNull();

        private int GetNowInt()
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (int)(DateTime.Now - startTime).TotalSeconds;
        }

        internal static DateTime GetDateTimeFromInt(int totalSeconds)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(totalSeconds);
        }

        /// <summary>
        /// 创建微信接口格式的 xml 文档
        /// </summary>
        /// <param name="toUserName"></param>
        /// <param name="fromUserName"></param>
        /// <returns></returns>
        public XmlDocument CreateDocument(string toUserName, string fromUserName)
        {
            var result = new XmlDocument();
            result.LoadXml("<xml></xml>");
            var root = result.DocumentElement;
            root.AppendChild(Extends.CreateElement(result, "ToUserName", toUserName));
            root.AppendChild(Extends.CreateElement(result, "FromUserName", fromUserName));
            root.AppendChild(result.CreateElement("CreateTime", GetNowInt()));
            root.AppendChild(Extends.CreateElement(result, "MsgType", this.Type));
            Document = result;
            foreach (var element in GetElements())
            {
                root.AppendChild(element);
            }

            return result;
        }
    }
}
