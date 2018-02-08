using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore
{
    /// <summary>
    /// 文件数据
    /// </summary>
    public class FileData
    {
        private Stream Stream;

        /// <summary>
        /// 文件序号
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 文件类型
        /// </summary>
        public string ContentType { get; private set; }

        /// <summary>
        /// 文件长度
        /// </summary>
        public long ContentLength { get; private set; }

        /// <summary>
        /// 引用数量
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// 文件位置
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; private set; }
        
        private FileData()
        {
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static FileData Create(Stream stream, string name, string contentType)
        {
            var domain = new FileData();
            domain.Stream = stream;
            stream.Position = 0;
            domain.Id = BitConverter.ToString(new System.Security.Cryptography.SHA256CryptoServiceProvider().ComputeHash(stream)).Replace("-", "");
            domain.Name = name;
            domain.ContentType = contentType;
            domain.ContentLength = stream.Length;
            domain.Count = 1;
            domain.CreatedTime = DateTime.Now;
            return domain;
        }

        internal Stream GetStream()
        {
            Stream.Position = 0;
            return Stream;
        }

        internal void SetLocation(string location)
        {
            Location = location;
        }

        internal string GetLocation()
        {
            return Location;
        }
    }
}
