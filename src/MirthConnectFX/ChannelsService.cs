using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using MirthConnectFX.Model;
using MirthConnectFX.Utility;

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
            var request = CreateRequest(Operations.Channels.GetChannelSummary);
            request.AddPostData("cachedChannels", "<map/>");

            var response = request.Execute();
            var summary = response.Content.ToObject<ChannelList>();

            return summary.ChannelSummaries;
        }

        public bool Update(Channel channel)
        {
            var channelXml = channel.ToXml();

            var request = CreateRequest(Operations.Channels.UpdateChannel);
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
            var channel = new Channel {Id = channelId}.ToXml();
            var request = CreateRequest(Operations.Channels.GetChannel);
            request.AddPostData("channel", channel);

            var response = request.Execute();
            var channelList = response.Content.ToObject<ChannelList>();

            return channelList.Channels.FirstOrDefault();
        }
    }
}