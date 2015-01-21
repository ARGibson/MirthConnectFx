using System;
using System.Collections.Generic;
using MirthConnectFX.Model;
using MirthConnectFX.Utility;

namespace MirthConnectFX
{
    public class ChannelStatusService : ServiceBase, IChannelStatusService
    {
        public ChannelStatusService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session, "channelstatus")
        {
        }

        public void StopChannel(string channelId)
        {
            var request = CreateRequest().ForOperation(Operations.ChannelStatus.StopChannel);
            request.AddPostData("id", channelId);

            request.Execute();
        }

        public void StartChannel(string channelId)
        {
            var request = CreateRequest().ForOperation(Operations.ChannelStatus.StartChannel);
            request.AddPostData("id", channelId);

            request.Execute();
        }

        public List<ChannelStatus> GetChannelStatus()
        {
            var request = CreateRequest().ForOperation(Operations.ChannelStatus.GetChannelStatus);

            var response = request.Execute();
            return response.Content.ToObject<ChannelList>().ChannelStatuses;
        }
    }
}