namespace MirthConnectFX
{
    public class ServiceBase
    {
        protected IMirthConnectRequestFactory MirthConnectRequestFactory { get; set; }
        protected IMirthConnectSession Session { get; set; }

        protected ServiceBase(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
        {
            MirthConnectRequestFactory = mirthConnectRequestFactory;
            Session = session;
        }
    }
}