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

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string ContentType { get; private set; }

        public long ContentLength { get; private set; }

        public int Count { get; private set; }

        public string Location { get; set; }

        public DateTime CreatedTime { get; private set; }
        
        private FileData()
        {
        }

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
