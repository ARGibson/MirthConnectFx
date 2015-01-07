using System.IO;
using System.Linq;
using MirthConnectFX.Model;
using NUnit.Framework;
using Should;

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

            summary.ShouldNotBeEmpty();
            summary.Any(x => x.Id == "0f2783ee-ced9-414c-8854-6840e74e8e21").ShouldBeTrue();
        }

        [Test]
        public void Update_ReturnsTrueOnSuccess()
        {
            WithExpectedRequest(Requests.Channels, "true");
            var service = new ChannelsService(RequestFactory, new MirthConnectSession("12345"));
            service.Update(new Channel()).ShouldBeTrue();

            var postData = ((MirthConnectRequest)RequestFactory.LastRequest).GetPostData();

            postData.ContainsKey("channel").ShouldBeTrue();
            postData["channel"].ShouldContain("<channel");
        }
    }
}