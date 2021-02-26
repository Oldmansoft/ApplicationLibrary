using Oldmansoft.ApplicationLibrary.FileStore.Mongo.Infrastructure;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo.Repositories
{
    class RepositoryFactory : ClassicDomain.RepositoryFactory
    {
        static RepositoryFactory()
        {
            Add<IFileIndexRepository, FileIndexRepository>();
        }
    }
}
