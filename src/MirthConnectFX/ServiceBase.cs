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

        protected IMirthConnectRequest CreateRequest(string op)
        {
            var request = MirthConnectRequestFactory.Create(ServicePath);
            request.AddPostData("op", op);

            if (!string.IsNullOrWhiteSpace(Session.SessionID))
                request.AuthSessionId = Session.SessionID;

            return request;
        }
    }
}