using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore.FileSystem
{
    public class FileContent : IFileContent
    {
        private static object FileLocker = new object();
        private static object Counter_Locker = new object();
        private static ushort Counter;

        private string BasePath;

        private FileContent()
        {
        }

        public static FileContent Create(string basePath)
        {
            var domain = new FileContent();
            domain.BasePath = basePath;
            return domain;
        }

        private string CreatePath()
        {
            lock (Counter_Locker)
            {
                Counter++;
            }
            var fileName = string.Format("{0:HHmmssffff}_{1}.file", DateTime.UtcNow, Counter);
            var path = DateTime.UtcNow.ToString("yyyyMMdd");
            var dir = Path.Combine(BasePath, path);
            lock (FileLocker)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }

            return Path.Combine(path, fileName);
        }

        public string Save(Stream stream)
        {
            var location = CreatePath();
            var buffer = new byte[1024 * 100];
            using (var fs = new FileStream(Path.Combine(BasePath, location), FileMode.CreateNew))
            {
                var length = stream.Read(buffer, 0, buffer.Length);
                while (length > 0)
                {
                    fs.Write(buffer, 0, length);
                    length = stream.Read(buffer, 0, buffer.Length);
                }
            }
            
            return location;
        }

        public Stream Load(string location)
        {
            var result = new MemoryStream();
            try
            {
                using (var stream = new FileStream(Path.Combine(BasePath, location), FileMode.Open))
                {
                    stream.CopyTo(result);
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            result.Position = 0;
            return result;
        }

        public void Remove(string location)
        {
            if (string.IsNullOrEmpty(location)) throw new ArgumentNullException("location");
            File.Delete(Path.Combine(BasePath, location));
        }
    }
}
