using System.Collections.Generic;

namespace MirthConnectFX
{
    public interface IEngineService
    {
        void DeployChannel(IEnumerable<string> list);
    }
}