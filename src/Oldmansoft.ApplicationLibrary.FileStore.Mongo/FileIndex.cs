using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo
{
    public class FileIndex : IFileIndex
    {
        private Repositories.RepositoryFactory Factory { get; set; }

        public FileIndex()
        {
            Factory = new Repositories.RepositoryFactory();
        }

        public void Add(FileData file)
        {
            var repository = Factory.CreateFileIndexRepository();
            repository.Add(file);
            Factory.GetUnitOfWork().Commit();
        }

        public FileData Create(Stream stream, string name, string contentType)
        {
            return FileData.Create(stream, name, contentType);
        }

        public void DecRef(string id)
        {
            Factory.CreateFileIndexRepository().DecRef(id);
            Factory.GetUnitOfWork().Commit();
        }

        public FileData Get(string id)
        {
            return Factory.CreateFileIndexRepository().Get(id);
        }

        public void IncRef(string id)
        {
            Factory.CreateFileIndexRepository().IncRef(id);
            Factory.GetUnitOfWork().Commit();
        }

        public void Remove(string id)
        {
            var repository = Factory.CreateFileIndexRepository();
            var domain = repository.Get(id);
            if (domain == null) return;
            repository.Remove(domain);
            Factory.GetUnitOfWork().Commit();
        }

        public bool HasLocation(string location)
        {
            return Factory.CreateFileIndexRepository().Query().Where(o => o.Location == location).FirstOrDefault() != null;
        }
    }
}
