using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class Extends
    {
        /// <summary>
        /// 获取 SHA1 Hash
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetSHA1Hash(this string source)
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException();
            var input = Encoding.UTF8.GetBytes(source);
            var hashed = System.Security.Cryptography.SHA1.Create().ComputeHash(input);
            return BitConverter.ToString(hashed).Replace("-", "");
        }

        /// <summary>
        /// 获取 MD5 Hash
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetMd5Hash(this string source)
        {
            if (string.IsNullOrEmpty(source)) throw new ArgumentNullException();
            var input = Encoding.UTF8.GetBytes(source);
            var hashed = new Util.Md5().ComputeHash(input);
            return BitConverter.ToString(hashed).Replace("-", "");
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

        /// <summary>
        /// 获取文本
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string GetText(this XmlNode source)
        {
            if (source == null) return null;
            if (source.LastChild == null) return null;
            return source.LastChild.Value;
        }

        /// <summary>
        /// 获取文本
        /// </summary>
        /// <param name="source"></param>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public static string GetText(this XmlElement source, string xpath)
        {
            if (source == null) return null;
            return source.SelectSingleNode(xpath).GetText();
        }

        /// <summary>
        /// 获取 Unix 时间戳
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int GetUnixTimestamp(this DateTime source)
        {
            DateTime startTime;
            if (source.Kind == DateTimeKind.Local)
            {
                startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            }
            else
            {
                startTime = TimeZone.CurrentTimeZone.ToUniversalTime(new DateTime(1970, 1, 1));
            }
            return (int)(source - startTime).TotalSeconds;
        }

        /// <summary>
        /// 获取本地时间
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static DateTime GetLocalTime(this int source)
        {
            return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(source);
        }

        /// <summary>
        /// 修正长度
        /// </summary>
        /// <param name="source"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static string CutByUtf8(this string source, int max)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;
            if (Encoding.UTF8.GetByteCount(source) <= max) return source;
            var result = new StringBuilder();
            var total = 0;
            for (var i = 0; i < source.Length; i++)
            {
                total += Encoding.UTF8.GetByteCount(new char[] { source[i] });
                if (total > max) break;
                result.Append(source[i]);
            }
            return result.ToString();
        }

        /// <summary>
        /// 自动设值
        /// </summary>
        /// <param name="source"></param>
        /// <param name="obj"></param>
        /// <param name="value"></param>
        public static void SetAutoValue(this System.Reflection.PropertyInfo source, object obj, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            if (source.PropertyType == typeof(string))
            {
                source.SetValue(obj, value);
            }
            else
            {
                source.SetValue(obj, Convert.ChangeType(value, source.PropertyType));
            }
        }
    }
}
