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
            
            WithExpectedRequest(Requests.Channels, responseXml);

            var service = new ChannelsService(RequestFactory, new MirthConnectSession("12345"));
            var summary = service.GetChannelSummary();

            summary.Should().NotBeEmpty();
            summary.Any(x => x.Id == "0f2783ee-ced9-414c-8854-6840e74e8e21").Should().BeTrue();
        }

        [Test]
        public void Update_ReturnsTrueOnSuccess()
        {
            WithExpectedRequest(Requests.Channels, "true");
            var service = new ChannelsService(RequestFactory, new MirthConnectSession("12345"));
            service.Update(new Channel()).Should().BeTrue();

            var postData = ((MirthConnectRequest)RequestFactory.LastRequest).GetPostData();

            postData.ContainsKey("channel").Should().BeTrue();
            postData["channel"].Should().Contain("<channel");
        }

        [Test]
        public void Update_HandlesFailure()
        {
            WithExpectedRequest(Requests.Channels, "error", true);

            var service = new ChannelsService(RequestFactory, new MirthConnectSession("12345"));

            Action action = () => service.Update(new Channel());
            action.ShouldThrow<MirthConnectException>()
                .WithMessage("Mirth returned error processing request")
                .WithInnerException<WebException>();
        }
    }
}