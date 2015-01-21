using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MirthConnectFX.Model;
using NUnit.Framework;

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

            var service = CreateService<ChannelsService, IChannelsService>();
            var summary = service.GetChannelSummary();

            summary.Should().NotBeEmpty();
            summary.Any(x => x.Id == "0f2783ee-ced9-414c-8854-6840e74e8e21").Should().BeTrue();
        }

        [TestCase(null, "channel", "<id>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</id>")]
        [TestCase("2.2.1.5861", "channel", "<id>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</id>")]
        [TestCase("3.1.1.7461", "channelIds", "<set><string>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</string></set>")]
        public void GetChannel_ReturnsChannel(string version, string postDataKey, string postDataValue)
        {
            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";
            const string responseXml =
                @"<list><channel><id>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</id><name>FX Test Channel</name></channel></list>";

            WithExpectedRequest(Operations.Channels.GetChannel, responseXml);

            var service = CreateService<ChannelsService, IChannelsService>(version);
            var channel = service.GetChannel(channelId);

            channel.Id.Should().Be(channelId);
            channel.Name.Should().Be("FX Test Channel");

            var postData = RequestFactory.Requests.First().GetPostData();

            postData.ContainsKey(postDataKey).Should().BeTrue();
            postData[postDataKey].Should().Contain(postDataValue);
        }

        [TestCase(null, "channelIds", "<string>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</string></set>")]
        [TestCase("2.2.1.5861", "channel", "<id>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</id>")]
        [TestCase("3.1.1.7461", "channelIds", "<string>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</string></set>")]
        public void GetChannels_ReturnsChannel(string version, string postDataKey, string postDataValue)
        {
            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";
            const string responseXml =
                @"<list><channel><id>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</id><name>FX Test Channel</name></channel></list>";

            WithExpectedRequest(Operations.Channels.GetChannel, responseXml);

            var service = CreateService<ChannelsService, IChannelsService>(version);
            var channel = service.GetChannels(new List<string> { channelId }).First();

            channel.Id.Should().Be(channelId);
            channel.Name.Should().Be("FX Test Channel");

            var postData = RequestFactory.Requests.First().GetPostData();

            postData.ContainsKey(postDataKey).Should().BeTrue();
            postData[postDataKey].Should().Contain(postDataValue);
        }

        [Test]
        public void Update_ReturnsTrueOnSuccess()
        {
            WithExpectedRequest(Operations.Channels.UpdateChannel, "true");
            var service = CreateService<ChannelsService, IChannelsService>();
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

            var service = CreateService<ChannelsService, IChannelsService>();
            service.EnableChannel(channelId);

            var postData = RequestFactory.Requests.First(x => x.Operation == Operations.Channels.UpdateChannel).GetPostData();
            postData["channel"].Contains("<enabled>true</enabled>");
        }

        [Test]
        public void Disable_DisablesChannel()
        {
            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";
            const string responseXml =
                @"<list><channel><id>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</id><enabled>true</enabled></channel></list>";

            WithExpectedRequest(Operations.Channels.GetChannel, responseXml);
            WithExpectedRequest(Operations.Channels.UpdateChannel, "true");

            var service = CreateService<ChannelsService, IChannelsService>();
            service.DisableChannel(channelId);

            var postData = RequestFactory.Requests.First(x => x.Operation == Operations.Channels.UpdateChannel).GetPostData();
            postData["channel"].Contains("<enabled>false</enabled>");
        }
    }
}