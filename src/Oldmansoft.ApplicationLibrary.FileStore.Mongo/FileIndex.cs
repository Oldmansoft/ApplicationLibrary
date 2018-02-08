using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo
{
    /// <summary>
    /// 文件索引
    /// </summary>
    public class FileIndex : IFileIndex
    {
        private Repositories.RepositoryFactory Factory { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        public FileIndex()
        {
            Factory = new Repositories.RepositoryFactory();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="file"></param>
        public void Add(FileData file)
        {
            var repository = Factory.CreateFileIndexRepository();
            repository.Add(file);
            Factory.GetUnitOfWork().Commit();
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public FileData Create(Stream stream, string name, string contentType)
        {
            return FileData.Create(stream, name, contentType);
        }

        /// <summary>
        /// 添加引用计数
        /// </summary>
        /// <param name="id"></param>
        public void DecRef(string id)
        {
            Factory.CreateFileIndexRepository().DecRef(id);
            Factory.GetUnitOfWork().Commit();
        }

        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileData Get(string id)
        {
            return Factory.CreateFileIndexRepository().Get(id);
        }

        /// <summary>
        /// 减少引用计数
        /// </summary>
        /// <param name="id"></param>
        public void IncRef(string id)
        {
            Factory.CreateFileIndexRepository().IncRef(id);
            Factory.GetUnitOfWork().Commit();
        }

        /// <summary>
        /// 移除文件
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            var repository = Factory.CreateFileIndexRepository();
            var domain = repository.Get(id);
            if (domain == null) return;
            repository.Remove(domain);
            Factory.GetUnitOfWork().Commit();
        }

        /// <summary>
        /// 是否有此位置
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool HasLocation(string location)
        {
            return Factory.CreateFileIndexRepository().Query().Where(o => o.Location == location).FirstOrDefault() != null;
        }
    }
}
