namespace MirthConnectFX
{
    public interface IMirthConnectClient
    {
        IConfigurationService   Configuration   { get; }
        IUserService            Users           { get; }
        IChannelsService        Channels        { get; }
        IChannelStatusService   ChannelStatus   { get; }
        IEngineService Engine { get; }

        IMirthConnectClient WithRemoteRequestFactory(IMirthConnectRequestFactory _mirthConnectRequestFactory);
        IMirthConnectClient WithSession(IMirthConnectSession session);
        IMirthConnectSession Login(string username, string password, string version);
    }
}