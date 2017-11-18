using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo.Repositories
{
    class RepositoryFactory
    {
        private ClassicDomain.UnitOfWork Uow { get; set; }

        public RepositoryFactory()
        {
            Uow = new ClassicDomain.UnitOfWork();
        }

        public ClassicDomain.IUnitOfWork GetUnitOfWork()
        {
            return Uow;
        }

        public FileIndexRepository CreateFileIndexRepository()
        {
            return new FileIndexRepository(Uow);
        }
    }
}
