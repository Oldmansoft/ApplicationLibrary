using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    internal static class Extends
    {
        public static string GetSHA1Hash(this string source)
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException();
            var cleanBytes = Encoding.Default.GetBytes(source);
            var hashedBytes = System.Security.Cryptography.SHA1.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        public static string GetMd5Hash(this string source)
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException();
            var cleanBytes = Encoding.Default.GetBytes(source);
            var hashedBytes = System.Security.Cryptography.MD5.Create().ComputeHash(cleanBytes);
            return BitConverter.ToString(hashedBytes).Replace("-", "");
        }

        /// <summary>
        /// 创建元素
        /// </summary>
        /// <param name="source"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static XmlElement CreateElement(this XmlDocument source, string name, object value)
        {
            var element = source.CreateElement(name);
            if (value == null) return element;

            if (value.GetType() == typeof(string))
            {
                element.AppendChild(source.CreateCDataSection(value.ToString()));
            }
            else
            {
                element.InnerText = value.ToString();
            }
            return element;
        }

        public static string GetText(this XmlNode source)
        {
            if (source == null) return null;
            if (source.LastChild == null) return null;
            return source.LastChild.Value;
        }

        public static string GetText(this XmlElement source, string xpath)
        {
            if (source == null) return null;
            return source.SelectSingleNode(xpath).GetText();
        }
    }
}
