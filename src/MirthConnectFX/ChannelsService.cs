using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public class ChannelsService : ServiceBase, IChannelsService
    {
        public ChannelsService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
            : base(mirthConnectRequestFactory, session, "channels")
        {
        }
        
        public IEnumerable<ChannelSummary> GetChannelSummary()
        {
            var request = CreateRequest("getChannelSummary");
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

            var request = CreateRequest("updateChannel");
            request.AddPostData("channel", channelXml);
            request.AddPostData("override", "true");

            try
            {
                var response = request.Execute();
                return Boolean.Parse(response.Content);
            }
            catch (WebException ex)
            {
                throw new MirthConnectException("Mirth returned error processing request", ex);
            }
        }

        public Channel GetChannel(string channelId)
        {
            var requestChannel = new Channel {Id = channelId};
            var requestChannelXml = string.Empty;

            using (var stream = new MemoryStream())
            {
                using (var writer = XmlWriter.Create(stream))
                {
                    new XmlSerializer(requestChannel.GetType()).Serialize(writer, requestChannel);
                    requestChannelXml = Encoding.UTF8.GetString(stream.ToArray());
                }
            }

            var request = CreateRequest("getChannel");
            request.AddPostData("channel", requestChannelXml);

            var response = request.Execute();

            var xmlSerializer = new XmlSerializer(typeof(ChannelList));
            var channelList = (ChannelList)xmlSerializer.Deserialize(new StringReader(response.Content));

            return channelList.Channels.FirstOrDefault();
        }
    }
}