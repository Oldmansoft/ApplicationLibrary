using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore
{
    /// <summary>
    /// 文件内容
    /// </summary>
    public interface IFileContent
    {
        string Save(Stream stream);

        Stream Load(string location);

        void Remove(string location);
    }
}
