using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo.Repositories
{
    class FileIndexRepository : ClassicDomain.Driver.Mongo.Repository<FileData, string, Mapping>
    {
        public FileIndexRepository(ClassicDomain.UnitOfWork uow)
            : base(uow)
        { }

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
    }
}
