using System.Linq;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo.Repositories
{
    class FileIndexRepository : ClassicDomain.Driver.Mongo.Repository<FileData, string, Mapping>, Infrastructure.IFileIndexRepository
    {
        public void IncRef(string id)
        {
            Execute(collection =>
            {
                collection.Update(MongoDB.Driver.Builders.Query.Create("_id", id), MongoDB.Driver.Builders.Update.Inc("Count", 1));
                return true;
            });
        }

        public void DecRef(string id)
        {
            Execute(collection =>
            {
                collection.Update(MongoDB.Driver.Builders.Query.Create("_id", id), MongoDB.Driver.Builders.Update.Inc("Count", -1));
                return true;
            });
        }

        public bool HasLocation(string location)
        {
            return Query().Where(o => o.Location == location).FirstOrDefault() != null;
        }
    }
}
