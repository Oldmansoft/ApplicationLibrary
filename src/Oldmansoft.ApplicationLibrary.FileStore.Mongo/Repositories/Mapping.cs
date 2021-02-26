using Oldmansoft.ClassicDomain.Driver.Mongo;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo.Repositories
{
    class Mapping : Context
    {
        protected override void OnModelCreating()
        {
            Add<FileData, string>(o => o.Id);
        }
    }
}
