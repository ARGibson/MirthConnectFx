using System.Collections.Generic;
using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public interface IChannelStatusService
    {
        void StopChannel(string channelId);
        void StartChannel(string channelId);
        List<ChannelStatus> GetChannelStatus();
    }
}