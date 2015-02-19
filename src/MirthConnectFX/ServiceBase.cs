namespace MirthConnectFX
{
    public class ServiceBase
    {
        protected IMirthConnectRequestFactory MirthConnectRequestFactory { get; set; }
        protected IMirthConnectSession Session { get; set; }
        protected string ServicePath { get; set; }

        protected ServiceBase(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session, string servicePath)
        {
            MirthConnectRequestFactory = mirthConnectRequestFactory;
            Session = session;
            ServicePath = servicePath;
        }

        protected IMirthConnectRequest CreateRequest()
        {
            var request = MirthConnectRequestFactory.Create(ServicePath);

            if (!string.IsNullOrWhiteSpace(Session.SessionID))
                request.AuthSessionId = Session.SessionID;

            return request;
        }
    }
}