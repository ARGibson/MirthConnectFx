using NUnit.Framework;
using Should;

namespace MirthConnectFX.Tests
{
    [TestFixture]
    public class TestMirthConnectClient : TestContext
    {       
        [Test]
        public void MirthConnectClient_CanLogin()
        {            
            var client = MirthConnectClient
                .Create()
                .WithRemoteRequestFactory(RequestFactory);

            WithExpectedRequest("https://localhost:8443/users");

            var session = client.Login("username", "password", "version");

            session.SessionID.ShouldEqual("12345");
        }

        [Test]
        public void MirthConnectClient_Login_GetsVersion()
        {
            var client = MirthConnectClient
                .Create()
                .WithRemoteRequestFactory(RequestFactory);

            WithExpectedRequest("https://localhost:8443/users");
            WithExpectedRequest("https://localhost:8443/configuration", "2.2.1.5861");

            var session = client.Login("username", "password", "version");
            session.Version.ShouldEqual("2.2.1.5861");
        }

        [Test]
        public void MirthConnectClient_CanGetChannelSummary()
        {
            var client = MirthConnectClient
                .Create()
                .WithSession(new MirthConnectSession("12345"))
                .WithRemoteRequestFactory(RequestFactory);

            const string responseXml = @"<list>
                                  <channelSummary>
                                    <id>0f2783ee-ced9-414c-8854-6840e74e8e21</id>
                                    <added>true</added>
                                    <deleted>false</deleted>
                                  </channelSummary>
                                </list>";

            WithExpectedRequest("https://localhost:8443/channels", responseXml);

            var summary = client.Channels.GetChannelSummary();
            summary.ShouldContain(responseXml);
        }
    }
}