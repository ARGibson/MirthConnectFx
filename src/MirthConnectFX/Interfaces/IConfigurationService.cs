using System.Collections.Generic;
using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public interface IConfigurationService
    {
        string GetVersion();
        void SetGlobalScripts(GlobalScripts scripts);
        ServerConfiguration GetServerConfiguation();
    }
}