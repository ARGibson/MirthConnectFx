using System;
using System.Linq;
using System.Net;
using MirthConnectFX.Model;
using NUnit.Framework;
using FluentAssertions;

namespace MirthConnectFX.Tests
{
    [TestFixture]
    public class TestChannelService : TestContext
    {
        [Test]
        public void GetChannelSummary_ReturnsChannelSummary()
        {
            const string responseXml = @"<list>
                                  <channelSummary>
                                    <id>0f2783ee-ced9-414c-8854-6840e74e8e21</id>
                                    <added>true</added>
                                    <deleted>false</deleted>
                                  </channelSummary>
                                </list>";
            
            WithExpectedRequest(Operations.Channels.GetChannelSummary, responseXml);

            var service = CreateService();
            var summary = service.GetChannelSummary();

            summary.Should().NotBeEmpty();
            summary.Any(x => x.Id == "0f2783ee-ced9-414c-8854-6840e74e8e21").Should().BeTrue();
        }

        [Test]
        public void GetChannel_ReturnsChannel()
        {
            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";
            const string responseXml =
                @"<list><channel><id>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</id><name>FX Test Channel</name></channel></list>";

            WithExpectedRequest(Operations.Channels.GetChannel, responseXml);

            var service = CreateService();
            var channel = service.GetChannel(channelId);

            channel.Id.Should().Be(channelId);
            channel.Name.Should().Be("FX Test Channel");

            var postData = RequestFactory.Requests.First().GetPostData();

            postData.ContainsKey("channel").Should().BeTrue();
            postData["channel"].Should().Contain("<id>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</id>");
        }

        [Test]
        public void Update_ReturnsTrueOnSuccess()
        {
            WithExpectedRequest(Operations.Channels.UpdateChannel, "true");
            var service = CreateService();
            service.Update(new Channel()).Should().BeTrue();

            var postData = RequestFactory.Requests.First().GetPostData();

            postData.ContainsKey("channel").Should().BeTrue();
            postData["channel"].Should().Contain("<channel");
        }

        [Test]
        public void Enable_EnablesChannel()
        {
            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";
            const string responseXml =
                @"<list><channel><id>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</id><enabled>false</enabled></channel></list>";
            
            WithExpectedRequest(Operations.Channels.GetChannel, responseXml);
            WithExpectedRequest(Operations.Channels.UpdateChannel, "true");

            var service = CreateService();
            service.EnableChannel(channelId);

            var postData = RequestFactory.Requests.First(x => x.Operation == Operations.Channels.UpdateChannel).GetPostData();
            postData["channel"].Contains("<enabled>true</enabled>");
        }

        private ChannelsService CreateService()
        {
            return new ChannelsService(RequestFactory, new MirthConnectSession("12345"));
        }
    }
}