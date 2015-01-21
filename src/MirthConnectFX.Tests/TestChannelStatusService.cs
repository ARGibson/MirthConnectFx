using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace MirthConnectFX.Tests
{
    public class TestChannelStatusService : TestContext
    {
        [Test]
        public void Stop_StopsChannel()
        {
            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";

            WithExpectedRequest(Operations.ChannelStatus.StopChannel);

            var service = new ChannelStatusService(RequestFactory, new MirthConnectSession("12345"));
            service.StopChannel(channelId);

            var postData = RequestFactory.Requests.First().GetPostData();

            postData.Should().ContainKey("id");
            postData["id"].Should().Be(channelId);
        }

        [Test]
        public void Start_StartsChannel()
        {
            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";

            WithExpectedRequest(Operations.ChannelStatus.StartChannel);

            var service = new ChannelStatusService(RequestFactory, new MirthConnectSession("12345"));
            service.StartChannel(channelId);

            var postData = RequestFactory.Requests.First().GetPostData();

            postData.Should().ContainKey("id");
            postData["id"].Should().Be(channelId);
        }

        [Test]
        public void GetChannelStatus_ReturnsChannelStatusList()
        {
            const string responseXml = @"<list>
                                          <channelStatus>
                                            <channelId>2b0a4fe9-98c7-44b3-8f66-732dc18a300b</channelId>
                                            <name>FX Test Channel</name>
                                            <state>STOPPED</state>
                                            <deployedRevisionDelta>2</deployedRevisionDelta>
                                            <deployedDate>
                                              <time>1421840183165</time>
                                              <timezone>Europe/London</timezone>
                                            </deployedDate>
                                          </channelStatus>
                                        </list>";
            
            WithExpectedRequest(Operations.ChannelStatus.GetChannelStatus, responseXml);

            var service = new ChannelStatusService(RequestFactory, new MirthConnectSession("12345"));
            var status = service.GetChannelStatus().First();

            status.ChannelId.Should().Be("2b0a4fe9-98c7-44b3-8f66-732dc18a300b");
            status.State.Should().Be("STOPPED");
        }
    }
}