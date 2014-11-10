using System.Net;

namespace MirthConnectFX
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IMirthConnectRequestFactory mirthConnectRequestFactory;
        private readonly IMirthConnectSession session;

        public ConfigurationService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
        {
            this.mirthConnectRequestFactory = mirthConnectRequestFactory;
            this.session = session;
        }

        public string GetVersion()
        {
            var request = mirthConnectRequestFactory.Create("configuration");
            request.AuthSessionId = session.SessionID;
            request.AddPostData("op", "getVersion");

            var response = request.Execute();

            return response.Content;
        }
    }
}