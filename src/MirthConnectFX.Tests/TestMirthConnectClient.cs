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
            var client = MirthConnectConnectClient
                .Create()
                .WithRemoteRequestFactory(new MockMirthConnectRequestFactory());

            var session = client.Users.Login("username", "password", "version");

            session.SessionID.ShouldNotBeNull();
        }
    }
}