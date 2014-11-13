using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public class ChannelsService : ServiceBase, IChannelsService
    {
        public ChannelsService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session) {}
        
        public IEnumerable<ChannelSummary> GetChannelSummary()
        {
            var request = MirthConnectRequestFactory.Create("channels");
            request.AuthSessionId = Session.SessionID;
            request.AddPostData("op", "getChannelSummary");
            request.AddPostData("cachedChannels", "<map/>");

            var response = request.Execute();

            var xmlSerializer = new XmlSerializer(typeof (ChannelList));
            var summary = (ChannelList)xmlSerializer.Deserialize(new StringReader(response.Content));

            return summary.ChannelSummaries;
        }
    }
}