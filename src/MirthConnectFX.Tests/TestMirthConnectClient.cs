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

            WithExpectedRequest(Requests.Users);

            var session = client.Login("username", "password", "version");

            session.SessionID.ShouldEqual("12345");
        }

        [Test]
        public void MirthConnectClient_Login_GetsVersion()
        {
            var client = MirthConnectClient
                .Create()
                .WithRemoteRequestFactory(RequestFactory);

            WithExpectedRequest(Requests.Users);
            WithExpectedRequest(Requests.Configuration, "2.2.1.5861");

            var session = client.Login("username", "password", "version");
            session.Version.ShouldEqual("2.2.1.5861");
        }
    }
}