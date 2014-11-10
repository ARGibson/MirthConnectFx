namespace MirthConnectFX
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IMirthConnectRequestFactory mirthConnectRequestFactory;

        public ConfigurationService(IMirthConnectRequestFactory mirthConnectRequestFactory)
        {
            this.mirthConnectRequestFactory = mirthConnectRequestFactory;
        }

        public string GetVersion()
        {
            var request = mirthConnectRequestFactory.Create("configuration");
            request.AddPostData("op", "getVersion");

            var response = request.Execute();

            return response.Content;
        }
    }
}