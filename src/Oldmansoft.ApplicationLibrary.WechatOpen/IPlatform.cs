using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oldmansoft.ApplicationLibrary.WechatOpen
{
    public interface IPlatform
    {
        IConfig Config { get; }

        Provider.IPositionStore PositionStore { get; }

        Data.AccessTokenResponse GetPlatformToken();

        string GetPlatformTokenString();
    }
}
