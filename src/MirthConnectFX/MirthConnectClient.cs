namespace MirthConnectFX
{
    public class MirthConnectClient : IMirthConnectClient
    {
        private IMirthConnectRequestFactory mirthConnectRequestFactory;
        private IMirthConnectSession session;

        public IConfigurationService Configuration  { get { return new ConfigurationService(mirthConnectRequestFactory, session); } }
        public IUserService          Users          { get { return new UsersService(mirthConnectRequestFactory); } }
        public IChannelsService      Channels       { get { return new ChannelsService(mirthConnectRequestFactory, session); }}
        public IChannelStatusService ChannelStatus  { get { return new ChannelStatusService(mirthConnectRequestFactory, session); }}
        public IEngineService        Engine         { get { return new EngineService(mirthConnectRequestFactory, session); }}
        public ICodeTemplateService  CodeTemplates  { get { return new CodeTemplateService(mirthConnectRequestFactory, session); }}
        public IMessageService       Messages       { get { return new MessageService(mirthConnectRequestFactory, session); }}

        protected MirthConnectClient(string baseUrl)
        {
            WithRemoteRequestFactory(new DefaultMirthConnectRequestFactory(baseUrl));
            WithSession(new MirthConnectSession(string.Empty));
        }

        public static IMirthConnectClient Create(string baseUrl)
        {
            return new MirthConnectClient(baseUrl);
        }

        public IMirthConnectClient WithRemoteRequestFactory(IMirthConnectRequestFactory mirthConnectRequestFactory)
        {
            this.mirthConnectRequestFactory = mirthConnectRequestFactory;
            return this;
        }

        public IMirthConnectClient WithSession(IMirthConnectSession session)
        {
            this.session = session;
            return this;
        }

        public IMirthConnectSession Login(string username, string password, string version)
        {
            var newSession = Users.Login(username, password, version);
            WithSession(newSession);

            newSession.Version = Configuration.GetVersion();

            return newSession;
        }
    }
}