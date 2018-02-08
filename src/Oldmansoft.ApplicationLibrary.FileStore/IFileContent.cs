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
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        string Save(Stream stream);

        /// <summary>
        /// 加载文件
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        Stream Load(string location);

        /// <summary>
        /// 移除文件
        /// </summary>
        /// <param name="location"></param>
        void Remove(string location);
    }
}
