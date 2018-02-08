using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen.Service.Pay.Util
{
    class XmlSerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static XmlDocument Serialize<T>(T value)
            where T : class
        {
            if (value == null) throw new ArgumentNullException();

            var result = new XmlDocument();
            result.LoadXml("<xml></xml>");
            foreach (var property in typeof(T).GetProperties())
            {
                if (!property.CanRead) continue;
                result.DocumentElement.AppendChild(result.CreateElement(property.Name, property.GetValue(value)));
            }
            return result;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dom"></param>
        /// <returns></returns>
        public static T Deserialize<T>(XmlDocument dom)
            where T : class, new()
        {
            T result = new T();
            if (dom == null) return result;

            foreach (var property in typeof(T).GetProperties())
            {
                if (!property.CanWrite) continue;
                property.SetValue(result, dom.DocumentElement.GetText(property.Name));
            }
            return result;
        }
    }
}
