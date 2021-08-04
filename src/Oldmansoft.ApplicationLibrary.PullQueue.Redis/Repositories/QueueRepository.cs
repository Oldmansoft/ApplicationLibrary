using ServiceStack.Text;
using System;

namespace Oldmansoft.ApplicationLibrary.PullQueue.Redis.Repositories
{
    class QueueRepository : ClassicDomain.Driver.Redis.Repository<Domain.Queue, Guid, Mapping>, Infrastructure.IQueueRepository
    {
        public void Enqueue<T>(string category, T value)
        {
            var content = JsonSerializer.SerializeToString(value);
            Execute<bool>((database) => {
                database.ListRightPush(string.Format("Queue.{0}", category.ToString()), content, StackExchange.Redis.When.Always, StackExchange.Redis.CommandFlags.FireAndForget);
                return true;
            });
        }

        public bool TryDequeue(string category)
        {
            var content = Execute<string>((database) => {
                return database.ListLeftPop(string.Format("Queue.{0}", category.ToString()));
            });
            return content != null;
        }

        public bool TryDequeue<T>(string category, out T value)
        {
            var content = Execute<string>((database) => {
                return database.ListLeftPop(string.Format("Queue.{0}", category.ToString()));
            });
            if (content == null)
            {
                value = default;
                return false;
            }

            value = JsonSerializer.DeserializeFromString<T>(content);
            return true;
        }

        public bool TryPeek<T>(string category, out T value)
        {
            var content = Execute<string>((database) => {
                return database.ListGetByIndex(string.Format("Queue.{0}", category.ToString()), 0);
            });
            if (content == null)
            {
                value = default;
                return false;
            }

            value = JsonSerializer.DeserializeFromString<T>(content);
            return true;
        }
    }
}
