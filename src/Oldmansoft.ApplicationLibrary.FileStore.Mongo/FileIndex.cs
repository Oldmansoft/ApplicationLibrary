using System.IO;
using System.Linq;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo
{
    /// <summary>
    /// 文件索引
    /// </summary>
    public class FileIndex : IFileIndex
    {
        private Repositories.Factory Factory { get; set; }

        private Infrastructure.IFileIndexRepository Repository { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        public FileIndex()
        {
            Factory = new Repositories.Factory();
            Repository = Factory.GetRepository<Infrastructure.IFileIndexRepository>();
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="contentLength"></param>
        /// <returns></returns>
        public FileData Create(string id, string name, string contentType, long contentLength)
        {
            return FileData.Create(id, name, contentType, contentLength);
        }

        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileData Get(string id)
        {
            return Repository.Get(id);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="file"></param>
        public void Add(FileData file)
        {
            Repository.Add(file);
            Factory.GetUnitOfWork().Commit();
        }

        /// <summary>
        /// 修改名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Change(string id, string name)
        {
            var domain = Repository.Get(id);
            if (domain == null) return;
            domain.SetName(name);
            Repository.Replace(domain);
            Factory.GetUnitOfWork().Commit();
        }

        /// <summary>
        /// 添加引用计数
        /// </summary>
        /// <param name="id"></param>
        public void DecRef(string id)
        {
            Repository.DecRef(id);
            Factory.GetUnitOfWork().Commit();
        }

        /// <summary>
        /// 减少引用计数
        /// </summary>
        /// <param name="id"></param>
        public void IncRef(string id)
        {
            Repository.IncRef(id);
            Factory.GetUnitOfWork().Commit();
        }

        /// <summary>
        /// 移除文件
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            var domain = Repository.Get(id);
            if (domain == null) return;
            Repository.Remove(domain);
            Factory.GetUnitOfWork().Commit();
        }

        /// <summary>
        /// 是否有此位置
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool HasLocation(string location)
        {
            return Repository.HasLocation(location);
        }
    }
}
