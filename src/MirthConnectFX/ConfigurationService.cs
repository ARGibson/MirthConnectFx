namespace MirthConnectFX
{
    public class ConfigurationService : ServiceBase, IConfigurationService
    {
        public ConfigurationService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session) {}

        public string GetVersion()
        {
            var request = MirthConnectRequestFactory.Create("configuration");
            request.AuthSessionId = Session.SessionID;
            request.AddPostData("op", "getVersion");

            var response = request.Execute();

            return response.Content;
        }
    }
}