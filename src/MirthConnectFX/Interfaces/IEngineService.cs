using System.Collections.Generic;

namespace MirthConnectFX
{
    public interface IEngineService
    {
        void DeployChannels(IEnumerable<string> channelIds);
        void UndeployChannels(IEnumerable<string> channelIds);
    }
}