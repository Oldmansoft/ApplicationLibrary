using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Concurrent;
using System.IO;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo
{
    /// <summary>
    /// 文件内容
    /// </summary>
    public class FileContent : IFileContent
    {
        private static ConcurrentDictionary<string, MongoServer> Servers { get; set; }

        static FileContent()
        {
            Servers = new ConcurrentDictionary<string, MongoServer>();
        }

        private MongoGridFS Fs { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="connectionString"></param>
        public FileContent(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException();

            var setting = MongoServerSettings.FromUrl(new MongoUrl(connectionString));
            var databaseName = new Uri(connectionString).GetDatabaseName();

            if (!Servers.TryGetValue(connectionString, out MongoServer server))
            {
                server = new MongoServer(setting);
                Servers.TryAdd(connectionString, server);
            }
            Fs = server.GetDatabase(databaseName).GetGridFS(new MongoGridFSSettings() { Root = "FileContent" });
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public Stream OpenRead(string location)
        {
            return Fs.OpenRead(location);
        }

        /// <summary>
        /// 移除文件
        /// </summary>
        /// <param name="location"></param>
        public void Remove(string location)
        {
            if (string.IsNullOrEmpty(location)) throw new ArgumentNullException();
            Fs.Delete(location);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="location">位置</param>
        /// <param name="stream">文件流</param>
        public void Save(string location, Stream stream)
        {
            Fs.Upload(stream, location);
        }

        /// <summary>
        /// 创建位置
        /// </summary>
        /// <returns></returns>
        public string CreateLocation()
        {
            return ClassicDomain.Driver.GuidGenerator.Default.Create(ClassicDomain.Driver.StorageMapping.MongoMapping).ToString("N"); ;
        }
    }
}
