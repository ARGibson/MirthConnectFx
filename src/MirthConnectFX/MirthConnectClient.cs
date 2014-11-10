namespace MirthConnectFX
{
    public class MirthConnectClient : IMirthConnectClient
    {
        private IMirthConnectRequestFactory mirthConnectRequestFactory;
        private IMirthConnectSession session;

        public IConfigurationService Configuration  { get { return new ConfigurationService(mirthConnectRequestFactory, session); } }
        public IUserService          Users          { get { return new UsersService(mirthConnectRequestFactory); } }

        public MirthConnectClient()
        {
            WithRemoteRequestFactory(new DefaultMirthConnectRequestFactory());
            WithSession(new MirthConnectSession(string.Empty));
        }

        public static IMirthConnectClient Create()
        {
            return new MirthConnectClient();
        }

        public IMirthConnectClient WithRemoteRequestFactory(IMirthConnectRequestFactory _mirthConnectRequestFactory)
        {
            this.mirthConnectRequestFactory = _mirthConnectRequestFactory;
            return this;
        }

        public IMirthConnectClient WithSession(IMirthConnectSession session)
        {
            this.session = session;
            return this;
        }
    }
}