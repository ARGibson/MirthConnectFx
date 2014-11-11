namespace MirthConnectFX
{
    public class MirthConnectClient : IMirthConnectClient
    {
        private IMirthConnectRequestFactory mirthConnectRequestFactory;
        private IMirthConnectSession session;

        public IConfigurationService Configuration  { get { return new ConfigurationService(mirthConnectRequestFactory, session); } }
        public IUserService          Users          { get { return new UsersService(mirthConnectRequestFactory); } }
        public IChannelsService      Channels       { get { return new ChannelsService(mirthConnectRequestFactory, session); }}

        public MirthConnectClient()
        {
            WithRemoteRequestFactory(new DefaultMirthConnectRequestFactory());
            WithSession(new MirthConnectSession(string.Empty));
        }

        public static IMirthConnectClient Create()
        {
            return new MirthConnectClient();
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
            var session = Users.Login(username, password, version);
            WithSession(session);

            return session;
        }
    }
}