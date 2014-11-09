namespace MirthConnectFX
{
    public interface IMirthClient
    {
        IUserService Users { get; }
        IMirthClient WithRemoteRequestFactory(IRemoteRequestFactory remoteRequestFactory);
    }
}