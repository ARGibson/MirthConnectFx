namespace MirthConnectFX
{
    public class MirthConnectClient : IMirthClient
    {
        private IRemoteRequestFactory remoteRequestFactory;

        public IUserService Users { get { return new UsersService(remoteRequestFactory); } }

        public MirthConnectClient()
        {
            WithRemoteRequestFactory(new DefaultRemoteRequestFactory());
        }

        public static IMirthClient Create()
        {
            return new MirthConnectClient();
        }

        public IMirthClient WithRemoteRequestFactory(IRemoteRequestFactory remoteRequestFactory)
        {
            this.remoteRequestFactory = remoteRequestFactory;
            return this;
        }
    }
}