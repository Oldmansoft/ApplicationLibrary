using System;
using System.IO;

namespace Oldmansoft.ApplicationLibrary.FileStore.FileSystem
{
    /// <summary>
    /// 文件内容
    /// </summary>
    public class FileContent : IFileContent
    {
        /// <summary>
        /// 计数锁
        /// </summary>
        private static readonly object Counter_Locker = new object();

        /// <summary>
        /// 计数器
        /// </summary>
        private static ushort Counter { get; set; }

        /// <summary>
        /// 目录锁
        /// </summary>
        protected static readonly object DirectoryLocker = new object();

        /// <summary>
        /// 根路径
        /// </summary>
        protected string BasePath { get; private set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="basePath"></param>
        public FileContent(string basePath)
        {
            BasePath = basePath;
        }
        
        /// <summary>
        /// 获取计数
        /// </summary>
        /// <returns></returns>
        protected ushort GetCounter()
        {
            lock (Counter_Locker)
            {
                return ++Counter;
            }
        }

        /// <summary>
        /// 创建文件路径
        /// </summary>
        /// <returns></returns>
        public virtual string CreateLocation()
        {
            var fileName = string.Format("{0:HHmmssffff}_{1}.file", DateTime.Now, GetCounter());
            var path = DateTime.UtcNow.ToString(@"yyyy\\MM\\dd");
            var dir = Path.Combine(BasePath, path);
            lock (DirectoryLocker)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }

            return Path.Combine(path, fileName);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="location">位置</param>
        /// <param name="stream">文件流</param>
        public void Save(string location, Stream stream)
        {
            var buffer = new byte[1024 * 64];
            using (var fs = new FileStream(Path.Combine(BasePath, location), FileMode.CreateNew))
            {
                var length = stream.Read(buffer, 0, buffer.Length);
                while (length > 0)
                {
                    fs.Write(buffer, 0, length);
                    length = stream.Read(buffer, 0, buffer.Length);
                }
            }
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="location">位置</param>
        /// <returns></returns>
        public Stream OpenRead(string location)
        {
            return new FileStream(Path.Combine(BasePath, location), FileMode.Open);
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="location">位置</param>
        public void Remove(string location)
        {
            if (string.IsNullOrEmpty(location)) throw new ArgumentNullException("location");
            File.Delete(Path.Combine(BasePath, location));
        }
    }
}
