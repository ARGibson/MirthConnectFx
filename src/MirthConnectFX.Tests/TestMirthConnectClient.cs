using NUnit.Framework;
using FluentAssertions;

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

            WithExpectedRequest(Operations.User.Login);

            var session = client.Login("username", "password", "version");

            session.SessionID.Should().Be("12345");
        }

        [Test]
        public void MirthConnectClient_Login_GetsVersion()
        {
            var client = MirthConnectClient
                .Create()
                .WithRemoteRequestFactory(RequestFactory);

            WithExpectedRequest(Operations.User.Login);
            WithExpectedRequest(Operations.Configuration.GetVerson, "2.2.1.5861");

            var session = client.Login("username", "password", "version");
            session.Version.Should().Be("2.2.1.5861");
        }
    }
}