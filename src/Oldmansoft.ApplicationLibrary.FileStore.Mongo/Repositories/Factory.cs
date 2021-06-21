using Oldmansoft.ApplicationLibrary.FileStore.Mongo.Infrastructure;
using Oldmansoft.ClassicDomain;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo.Repositories
{
    /// <summary>
    /// 仓储工厂
    /// </summary>
    public class Factory : RepositoryFactory
    {
        static Factory()
        {
            Add<IFileIndexRepository, FileIndexRepository>();
        }

        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="connectionString"></param>
        public static void SetConnectionString(string connectionString)
        {
            ConnectionString.Set<Mapping>(connectionString);
        }
    }
}
