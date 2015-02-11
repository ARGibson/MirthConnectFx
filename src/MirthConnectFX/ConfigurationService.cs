using System.Collections.Generic;
using MirthConnectFX.Model;
using MirthConnectFX.Utility;

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

        public void SetGlobalScripts(GlobalScripts scripts)
        {
            var request = CreateRequest().ForOperation(Operations.Configuration.SetGlobalScripts);
            request.AddPostData("scripts", scripts.ToXml());

            request.Execute();
        }
    }
}