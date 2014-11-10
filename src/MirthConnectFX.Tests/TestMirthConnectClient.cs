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
            var client = MirthConnectConnectClient
                .Create()
                .WithRemoteRequestFactory(RequestFactory);

            WithExpectedRequest("https://localhost:8443/users");

            var session = client.Users.Login("username", "password", "version");

            session.SessionID.ShouldEqual("12345");
        }
    }
}