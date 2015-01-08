namespace MirthConnectFX
{
    public class ConfigurationService : ServiceBase, IConfigurationService
    {
        public ConfigurationService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session, "configuration") {}

        public string GetVersion()
        {
            var request = CreateRequest().ForOperation(Operations.Configuration.GetVerson);
            var response = request.Execute();

            return response.Content;
        }
    }
}