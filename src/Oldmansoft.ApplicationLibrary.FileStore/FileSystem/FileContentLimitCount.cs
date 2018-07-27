using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore.FileSystem
{
    /// <summary>
    /// 文件内容
    /// 限制数量
    /// </summary>
    public class FileContentLimitCount : FileContent
    {
        private static int CurrentCount { get; set; }
        
        private static int CurrentDirCount { get; set; }
        
        private static string CurrentDir { get; set; }

        private static DateTime CurrentDate { get; set; }

        private int LimitCount { get; set; }

        static FileContentLimitCount()
        {
            CurrentDate = DateTime.Now.AddDays(-1).Date;
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="basePath">根目录</param>
        /// <param name="limitCount">限制数量</param>
        /// <returns></returns>
        public FileContentLimitCount(string basePath, int limitCount)
            : base(basePath)
        {
            LimitCount = limitCount;
        }

        private string GetDir(bool inc)
        {
            var datePath = DateTime.Now.ToString(@"yyyy\\MM\\dd");
            var fullPath = Path.Combine(BasePath, datePath);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            short maxNumber = 1;
            short numberName;
            foreach (var item in Directory.GetDirectories(fullPath))
            {
                if (!short.TryParse(Path.GetFileName(item), out numberName)) continue;
                if (numberName > maxNumber) maxNumber = numberName;
            }
            if (inc) maxNumber++;
            var fullPathAndSubnumber = Path.Combine(fullPath, maxNumber.ToString());
            if (!Directory.Exists(fullPathAndSubnumber))
            {
                Directory.CreateDirectory(fullPathAndSubnumber);
            }

            return Path.Combine(datePath, maxNumber.ToString());
        }

        private int GetMaxFileName(string path)
        {
            int maxNumber = 0;
            int numberName;
            foreach (var item in Directory.GetFiles(path))
            {
                if (Path.GetExtension(item) != ".file") continue;
                if (!int.TryParse(Path.GetFileNameWithoutExtension(item), out numberName)) continue;
                if (numberName > maxNumber) maxNumber = numberName;
            }
            return maxNumber;
        }
        
        /// <summary>
        /// 创建文件路径
        /// </summary>
        /// <returns></returns>
        protected override string CreatePath()
        {
            string path;
            lock (DirectoryLocker)
            {
                if (CurrentDate != DateTime.Now.Date)
                {
                    CurrentDir = GetDir(false);
                    CurrentCount = GetMaxFileName(Path.Combine(BasePath, CurrentDir));
                    CurrentDate = DateTime.Now.Date;
                }

                if (CurrentCount >= LimitCount)
                {
                    CurrentDir = GetDir(true);
                    CurrentCount = 1;
                    CurrentDate = DateTime.Now.Date;
                }
                else
                {
                    CurrentCount++;
                }
                path = Path.Combine(CurrentDir, string.Format("{0}.file", CurrentCount));
            }
            
            return path;
        }
    }
}
