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

            var session = client.Users.Login("username", "password", "version");

            session.SessionID.ShouldEqual("12345");
        }

        [Test]
        public void MirthConnectClient_CanGetVersion()
        {
            var client = MirthConnectClient
                .Create()
                .WithRemoteRequestFactory(RequestFactory);

            WithExpectedRequest("https://localhost:8443/configuration", "2.2.1.5861");

            var version = client.Configuration.GetVersion();
            version.ShouldEqual("2.2.1.5861");
        }
    }
}