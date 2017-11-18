using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore
{
    /// <summary>
    /// 文件提供者
    /// </summary>
    public interface IFileProvider
    {
        IFileIndex CreateFileIndex();

        IFileContent CreateFileContent();
    }
}
