namespace MirthConnectFX
{
    public class MirthConnectClient : IMirthConnectClient
    {
        private IMirthConnectRequestFactory _mirthConnectRequestFactory;

        public IUserService Users { get { return new UsersService(_mirthConnectRequestFactory); } }

        public MirthConnectClient()
        {
            WithRemoteRequestFactory(new DefaultMirthConnectRequestFactory());
        }

        public static IMirthConnectClient Create()
        {
            return new MirthConnectClient();
        }

        public IMirthConnectClient WithRemoteRequestFactory(IMirthConnectRequestFactory _mirthConnectRequestFactory)
        {
            this._mirthConnectRequestFactory = _mirthConnectRequestFactory;
            return this;
        }
    }
}