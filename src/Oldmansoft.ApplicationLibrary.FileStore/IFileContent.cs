using System.IO;

namespace Oldmansoft.ApplicationLibrary.FileStore
{
    /// <summary>
    /// 文件内容
    /// </summary>
    public interface IFileContent
    {
        /// <summary>
        /// 创建位置
        /// </summary>
        /// <returns></returns>
        string CreateLocation();

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="location">位置</param>
        /// <param name="stream">文件流</param>
        void Save(string location, Stream stream);

        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="location">位置</param>
        /// <returns></returns>
        Stream OpenRead(string location);

        /// <summary>
        /// 移除文件
        /// </summary>
        /// <param name="location">位置</param>
        void Remove(string location);
    }
}
