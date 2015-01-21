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
    }
}