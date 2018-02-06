using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    class Visitor
    {
        public static T Get<T>(string url)
        {
            string content;
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(new Uri(url)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }
            if (content.IndexOf("\"errcode\"") > -1)
            {
                var error = Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Error>(content);
                if (error.errcode != 0)
                {
                    throw CallException.Create(error);
                }
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
        }


        /// <summary>
        /// 提交内容
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static void Post(string url, object data)
        {
            var value = string.Empty;
            if (data != null)
            {
                value = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            string content;
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(url), new StringContent(value)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }
            if (content.IndexOf("\"errcode\"") == -1)
            {
                throw new FormatException(string.Format("没有解析：{0}", content));
            }

            var error = Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Error>(content);
            if (error.errcode != 0)
            {
                throw CallException.Create(error);
            }
        }

        /// <summary>
        /// 提交内容
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T Post<T>(string url, object data)
        {
            var value = string.Empty;
            if (data != null)
            {
                value = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            }
            string content;
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(new Uri(url), new StringContent(value)).Result;
                content = response.Content.ReadAsStringAsync().Result;
            }
            if (content.IndexOf("\"errcode\"") > -1)
            {
                var error = Newtonsoft.Json.JsonConvert.DeserializeObject<Data.Error>(content);
                if (error.errcode != 0)
                {
                    throw CallException.Create(error);
                }
            }
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(content);
        }
    }
}
