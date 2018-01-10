using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore
{
    /// <summary>
    /// 文件索引
    /// </summary>
    public interface IFileIndex
    {
        FileData Create(System.IO.Stream stream, string name, string contentType);

        FileData Get(string id);

        void Add(FileData file);

        void IncRef(string id);

        void DecRef(string id);

        void Remove(string id);

        bool HasLocation(string location);
    }
}
