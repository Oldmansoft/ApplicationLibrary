﻿using Oldmansoft.ApplicationLibrary.PullQueue.Redis.Infrastructure;

namespace Oldmansoft.ApplicationLibrary.PullQueue.Redis.Repositories
{
    class Factory : ClassicDomain.RepositoryFactory
    {
        static Factory()
        {
            Add<IQueueRepository, QueueRepository>();
        }

        /// <summary>
        /// 设置连接字符串
        /// </summary>
        /// <param name="connectionString"></param>
        public static void SetConnectionString(string connectionString)
        {
            ClassicDomain.ConnectionString.Set<Mapping>(connectionString);
        }
    }
}
