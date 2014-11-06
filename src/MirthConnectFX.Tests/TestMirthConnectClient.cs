using NUnit.Framework;
using Should;

namespace MirthConnectFX.Tests
{
    [TestFixture]
    public class TestMirthConnectClient
    {       
        [Test]
        public void MirthConnectClient_CanLogin()
        {
            var client = MirthConnectClient
                .Create()
                .WithRemoteRequestFactory(new MockRemoteRequestFactory());

            var session = client.Users.Login("username", "password", "version");

            session.SessionID.ShouldNotBeNull();
        }
    }
}