namespace Oldmansoft.ApplicationLibrary.PullQueue.Redis.Infrastructure
{
    interface IQueueRepository : ClassicDomain.IRepository
    {
        void Enqueue<T>(string category, T value);

        bool TryDequeue(string category);

        bool TryDequeue<T>(string category, out T value);

        bool TryPeek<T>(string category, out T value);
    }
}
