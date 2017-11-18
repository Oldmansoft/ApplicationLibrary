using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore
{
    public class FileManager
    {
        private IFileContent FileContent { get; set; }

        private IFileIndex FileIndex { get; set; }

        public FileManager(IFileProvider factory)
        {
            FileContent = factory.CreateFileContent();
            FileIndex = factory.CreateFileIndex();
        }

        public FileData Create(System.IO.Stream stream, string name, string contentType)
        {
            return FileIndex.Create(stream, name, contentType);
        }

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

        public FileData Get(string id)
        {
            var file = FileIndex.Get(id);
            return file;
        }

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
