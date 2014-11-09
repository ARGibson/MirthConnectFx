namespace MirthConnectFX
{
    public class MirthConnectConnectClient : IMirthConnectClient
    {
        private IMirthConnectRequestFactory _mirthConnectRequestFactory;

        public IUserService Users { get { return new UsersService(_mirthConnectRequestFactory); } }

        public MirthConnectConnectClient()
        {
            WithRemoteRequestFactory(new DefaultMirthConnectRequestFactory());
        }

        public static IMirthConnectClient Create()
        {
            return new MirthConnectConnectClient();
        }

        public IMirthConnectClient WithRemoteRequestFactory(IMirthConnectRequestFactory _mirthConnectRequestFactory)
        {
            this._mirthConnectRequestFactory = _mirthConnectRequestFactory;
            return this;
        }
    }
}