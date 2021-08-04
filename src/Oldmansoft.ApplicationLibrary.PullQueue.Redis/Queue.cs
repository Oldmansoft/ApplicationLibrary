namespace Oldmansoft.ApplicationLibrary.PullQueue.Redis
{
    public class Queue : IQueue
    {
        private Infrastructure.IQueueRepository Repository { get; set; }

        public Queue()
        {
            new Repositories.Factory().GetRepository<Infrastructure.IQueueRepository>();
        }

        public void Enqueue<T>(string category, T value)
        {
            Repository.Enqueue(category, value);
        }

        public bool TryDequeue(string category)
        {
            return Repository.TryDequeue(category);
        }

        public bool TryDequeue<T>(string category, out T value)
        {
            return Repository.TryDequeue(category, out value);
        }

        public bool TryPeek<T>(string category, out T value)
        {
            return Repository.TryPeek(category, out value);
        }
    }
}
