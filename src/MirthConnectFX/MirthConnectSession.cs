namespace MirthConnectFX
{
    public class MirthConnectSession : IMirthConnectSession
    {
        public string SessionID { get; private set; }
        public string Version { get; set; }

        public MirthConnectSession(string sessionId)
        {
            SessionID = sessionId;
        }

        public bool IsMirthVersion(MirthBaseVersion version)
        {
            return !string.IsNullOrWhiteSpace(Version) && Version.StartsWith(((int)version).ToString());
        }
    }
}