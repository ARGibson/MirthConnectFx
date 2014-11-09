namespace MirthConnectFX
{
    public interface IMirthConnectClient
    {
        IUserService Users { get; }
        IMirthConnectClient WithRemoteRequestFactory(IMirthConnectRequestFactory _mirthConnectRequestFactory);
    }
}