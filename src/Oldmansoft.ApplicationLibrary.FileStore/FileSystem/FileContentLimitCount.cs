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
            if (CurrentDir == null)
            {
                lock (DirectoryLocker)
                {
                    if (CurrentDir == null)
                    {
                        CurrentDir = GetDir(false);
                        CurrentCount = Directory.GetFiles(CurrentDir).Length;
                        CurrentDate = DateTime.Now.Date;
                    }
                }
            }
        }

        private string GetDir(bool inc)
        {
            var datePath = DateTime.Now.ToString(@"yyyy\\MM\\dd");
            var dateDir = Path.Combine(BasePath, datePath);
            if (!Directory.Exists(dateDir))
            {
                Directory.CreateDirectory(dateDir);
            }

            short maxNumber = 1;
            short numberName;
            foreach (var item in Directory.GetDirectories(dateDir))
            {
                if (short.TryParse(item, out numberName))
                {
                    if (numberName > maxNumber) maxNumber = numberName;
                }
            }
            if (inc) maxNumber++;
            var result = Path.Combine(dateDir, maxNumber.ToString());
            if (!Directory.Exists(result))
            {
                Directory.CreateDirectory(result);
            }
            return result;
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
                    CurrentCount = Directory.GetFiles(CurrentDir).Length;
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
