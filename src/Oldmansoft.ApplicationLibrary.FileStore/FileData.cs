using System;
using System.IO;

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
        public DateTime Created { get; private set; }
        
        private FileData()
        {
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="contentLength"></param>
        /// <returns></returns>
        public static FileData Create(string id, string name, string contentType, long contentLength)
        {
            return new FileData
            {
                Id = id,
                Name = name,
                ContentType = contentType,
                ContentLength = contentLength,
                Count = 1,
                Created = DateTime.UtcNow
            };
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static FileData CreateWithStream(Stream stream, string name, string contentType)
        {
            stream.Position = 0;
            return new FileData
            {
                Stream = stream,
                Id = BitConverter.ToString(new System.Security.Cryptography.SHA256CryptoServiceProvider().ComputeHash(stream)).Replace("-", ""),
                Name = name,
                ContentType = contentType,
                ContentLength = stream.Length,
                Count = 1,
                Created = DateTime.UtcNow
            };
        }

        internal Stream GetStream()
        {
            Stream.Position = 0;
            return Stream;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="location"></param>
        public void SetLocation(string location)
        {
            Location = location;
        }
    }
}
