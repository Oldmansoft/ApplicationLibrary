namespace Oldmansoft.ApplicationLibrary.PullQueue.Redis
{
    /// <summary>
    /// 队列
    /// </summary>
    public class Queue
    {
        private Infrastructure.IQueueRepository Repository { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        public Queue()
        {
            new Repositories.Factory().GetRepository<Infrastructure.IQueueRepository>();
        }

        /// <summary>
        /// 入列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="category"></param>
        /// <param name="value"></param>
        public void Enqueue<T>(string category, T value)
        {
            Repository.Enqueue(category, value);
        }

        /// <summary>
        /// 出列
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public bool TryDequeue(string category)
        {
            return Repository.TryDequeue(category);
        }

        /// <summary>
        /// 出列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="category"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryDequeue<T>(string category, out T value)
        {
            return Repository.TryDequeue(category, out value);
        }

        /// <summary>
        /// 探列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="category"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryPeek<T>(string category, out T value)
        {
            return Repository.TryPeek(category, out value);
        }
    }
}
