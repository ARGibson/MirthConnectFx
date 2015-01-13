namespace MirthConnectFX
{
    public interface IMirthConnectSession
    {
        string SessionID { get; }
        string Version { get; set; }
        bool IsMirthVersion(MirthBaseVersion version);
    }
}