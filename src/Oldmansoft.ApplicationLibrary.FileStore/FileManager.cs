using System;
using System.IO;

namespace Oldmansoft.ApplicationLibrary.FileStore
{
    /// <summary>
    /// 文件管理
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// 文件内容
        /// </summary>
        public IFileContent FileContent { get; protected set; }

        /// <summary>
        /// 文件索引
        /// </summary>
        public IFileIndex FileIndex { get; protected set; }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="fileIndex"></param>
        public FileManager(IFileContent fileContent, IFileIndex fileIndex)
        {
            FileContent = fileContent;
            FileIndex = fileIndex;
        }

        /// <summary>
        /// 制作序号
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public virtual string MakeId(Stream stream)
        {
            return BitConverter.ToString(new System.Security.Cryptography.SHA256CryptoServiceProvider().ComputeHash(stream)).Replace("-", "");
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public FileData CreateAndSave(Stream stream, string name, string contentType)
        {
            stream.Position = 0;
            var file = FileIndex.Create(MakeId(stream), name, contentType, stream.Length);

            if (FileIndex.Get(file.Id) != null)
            {
                FileIndex.IncRef(file.Id);
            }
            else
            {
                file.SetLocation(FileContent.CreateLocation());
                stream.Position = 0;
                FileContent.Save(file.Location, stream);
                FileIndex.Add(file);
            }
            return file;
        }

        /// <summary>
        /// 创建文件的数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="contentType"></param>
        /// <param name="contentLength"></param>
        /// <returns></returns>
        public FileData Create(string id, string name, string contentType, long contentLength)
        {
            var file = FileIndex.Create(id, name, contentType, contentLength);
            file.SetLocation(FileContent.CreateLocation());
            return file;
        }

        /// <summary>
        /// 添加外部保存的文件
        /// </summary>
        /// <param name="file"></param>
        public void Add(FileData file)
        {
            if (FileIndex.Get(file.Id) != null)
            {
                FileIndex.IncRef(file.Id);
            }
            else
            {
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
                FileContent.Remove(file.Location);
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
        public FileData Get(string id, out Stream stream)
        {
            var file = FileIndex.Get(id);
            stream = null;
            if (file == null) return null;

            stream = FileContent.OpenRead(file.Location);
            return file;
        }
    }
}
