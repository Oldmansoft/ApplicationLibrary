namespace Oldmansoft.ApplicationLibrary.FileStore
{
    /// <summary>
    /// 文件索引
    /// </summary>
    public interface IFileIndex
    {
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        FileData Create(System.IO.Stream stream, string name, string contentType);

        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        FileData Get(string id);

        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="file"></param>
        void Add(FileData file);

        /// <summary>
        /// 增加引用计数
        /// </summary>
        /// <param name="id"></param>
        void IncRef(string id);

        /// <summary>
        /// 减少引用计数
        /// </summary>
        /// <param name="id"></param>
        void DecRef(string id);

        /// <summary>
        /// 移除文件
        /// </summary>
        /// <param name="id"></param>
        void Remove(string id);

        /// <summary>
        /// 是否有此位置
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        bool HasLocation(string location);
    }
}
