namespace Oldmansoft.ApplicationLibrary.FileStore
{
    /// <summary>
    /// 文件提供者
    /// </summary>
    public interface IFileProvider
    {
        /// <summary>
        /// 创建文件索引
        /// </summary>
        /// <returns></returns>
        IFileIndex CreateFileIndex();

        /// <summary>
        /// 创建文件内容
        /// </summary>
        /// <returns></returns>
        IFileContent CreateFileContent();
    }
}
