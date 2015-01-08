using System.Collections.Generic;
using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public interface IChannelsService
    {
        IEnumerable<ChannelSummary> GetChannelSummary();
        bool Update(Channel channel);
        Channel GetChannel(string channelId);
        void EnableChannel(string channelId);
    }
}