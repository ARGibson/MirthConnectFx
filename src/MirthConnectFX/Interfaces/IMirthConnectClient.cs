namespace MirthConnectFX
{
    public interface IMirthConnectClient
    {
        IConfigurationService   Configuration   { get; }
        IUserService            Users           { get; }
        
        IMirthConnectClient WithRemoteRequestFactory(IMirthConnectRequestFactory _mirthConnectRequestFactory);
        IMirthConnectClient WithSession(IMirthConnectSession session);
    }
}