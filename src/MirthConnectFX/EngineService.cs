using System.Collections.Generic;
using MirthConnectFX.Utility;

namespace MirthConnectFX
{
    public class EngineService : ServiceBase, IEngineService
    {
        public EngineService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session, "engine")
        {
        }

        public void DeployChannels(IEnumerable<string> channelIds)
        {
            var request = CreateRequest().ForOperation(Operations.Engine.DeployChannels);
            
            request.AddPostData("channelIds", channelIds.ToXmlCollection());
            request.Execute();
        }

        public void UndeployChannels(IEnumerable<string> channelIds)
        {
            var request = CreateRequest().ForOperation(Operations.Engine.UndeplyChannels);
            
            request.AddPostData("channelIds", channelIds.ToXmlCollection());
            request.Execute();
        }
    }
}