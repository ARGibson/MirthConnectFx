namespace MirthConnectFX
{
    public class MirthConnectSession : IMirthConnectSession
    {
        public string SessionID { get; private set; }

        public MirthConnectSession(string sessionId)
        {
            SessionID = sessionId;
        }
    }
}