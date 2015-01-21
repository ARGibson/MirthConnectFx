using System.Collections.Generic;
using MirthConnectFX.Model;
using MirthConnectFX.Utility;

namespace MirthConnectFX
{
    public class EngineService : ServiceBase, IEngineService
    {
        public EngineService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session, "engine")
        {
        }

        public void DeployChannel(IEnumerable<string> channelIds)
        {
            var request = CreateRequest().ForOperation(Operations.Engine.DeployChannels);

            var channelList = new ChannelList();
            foreach (var channelId in channelIds)
                channelList.ChannelSummaries.Add(new ChannelSummary { Id = channelId});

            request.AddPostData("channelIds", channelList.ToXml());

            request.Execute();
        }
    }
}