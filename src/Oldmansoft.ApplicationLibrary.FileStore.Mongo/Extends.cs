using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.FileStore.Mongo
{
    static class Extends
    {
        internal static string GetDatabase(this Uri source)
        {
            return source.AbsolutePath.Substring(1);
        }
    }
}
