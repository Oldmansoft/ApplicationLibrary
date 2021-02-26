namespace Oldmansoft.ApplicationLibrary.FileStore
{
    /// <summary>
    /// 文件管理
    /// </summary>
    public class FileManager
    {
        private IFileContent FileContent { get; set; }

        private IFileIndex FileIndex { get; set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="factory"></param>
        public FileManager(IFileProvider factory)
        {
            FileContent = factory.CreateFileContent();
            FileIndex = factory.CreateFileIndex();
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public FileData Create(System.IO.Stream stream, string name, string contentType)
        {
            return FileIndex.Create(stream, name, contentType);
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="file"></param>
        public void Save(FileData file)
        {
            if (FileIndex.Get(file.Id) != null)
            {
                FileIndex.IncRef(file.Id);
            }
            else
            {
                var location = FileContent.Save(file.GetStream());
                file.SetLocation(location);
                FileIndex.Add(file);
            }
        }

        /// <summary>
        /// 移除文件
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string id)
        {
            var file = FileIndex.Get(id);
            if (file == null) return;
            FileIndex.DecRef(id);
            file = FileIndex.Get(id);
            if (file.Count == 0)
            {
                FileIndex.Remove(id);
                FileContent.Remove(file.GetLocation());
            }
        }

        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public FileData Get(string id)
        {
            var file = FileIndex.Get(id);
            return file;
        }

        /// <summary>
        /// 获取文件
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stream">文件内容流</param>
        /// <returns></returns>
        public FileData Get(string id, out System.IO.Stream stream)
        {
            var file = FileIndex.Get(id);
            stream = null;
            if (file == null) return null;

            stream = FileContent.Load(file.GetLocation());
            return file;
        }
    }
}
