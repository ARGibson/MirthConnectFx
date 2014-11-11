namespace MirthConnectFX
{
    public class ChannelsService : ServiceBase, IChannelsService
    {
        public ChannelsService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session) {}
        
        public string GetChannelSummary()
        {
            var request = MirthConnectRequestFactory.Create("channels");
            request.AuthSessionId = Session.SessionID;
            request.AddPostData("op", "getChannelSummary");
            request.AddPostData("cachedChannels", "<map/>");

            var response = request.Execute();

            return response.Content;
        }
    }
}