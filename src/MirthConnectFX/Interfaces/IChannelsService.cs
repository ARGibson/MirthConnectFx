using System.Collections.Generic;
using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public interface IChannelsService
    {
        IEnumerable<ChannelSummary> GetChannelSummary();
        bool Update(Channel channel);
    }
}