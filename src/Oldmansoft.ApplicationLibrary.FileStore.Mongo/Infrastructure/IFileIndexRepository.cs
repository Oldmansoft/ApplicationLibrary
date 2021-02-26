using System;
using System.Collections.Generic;
using System.Text;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo.Infrastructure
{
    interface IFileIndexRepository : ClassicDomain.IRepository<FileData, string>
    {
        void IncRef(string id);

        void DecRef(string id);

        bool HasLocation(string location);
    }
}
