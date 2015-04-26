using MirthConnectFX.Interfaces;

namespace MirthConnectFX
{
    public class EventsService : ServiceBase, IEventsService
    {
        public EventsService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
            : base(mirthConnectRequestFactory, session, "events")
        {
        }

        public void RemoveAllEvents()
        {
            var request = CreateRequest().ForOperation(Operations.Events.RemoveAllEvents);
            request.Execute();
        }
    }
}