using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
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

        public bool Update(Channel channel)
        {
            var channelXml = string.Empty;
            
            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream))
                {
                    new XmlSerializer(channel.GetType()).Serialize(writer, channel);
                    channelXml = Encoding.UTF8.GetString(stream.ToArray());
                }
            }
            
            var request = MirthConnectRequestFactory.Create("channels");
            request.AuthSessionId = Session.SessionID;
            request.AddPostData("op", "updateChannel");
            request.AddPostData("channel", channelXml);
            request.AddPostData("override", "true");

            var response = request.Execute();

            return Boolean.Parse(response.Content);
        }
    }
}