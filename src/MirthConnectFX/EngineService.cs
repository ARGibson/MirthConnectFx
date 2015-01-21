using System.Collections.Generic;
using System.Text;

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

            var sb = new StringBuilder("<list>");
            foreach (var channelId in channelIds)
                sb.AppendFormat("<string>{0}</string>", channelId);

            sb.Append("</list>");

            request.AddPostData("channelIds", sb.ToString());

            request.Execute();
        }
    }
}