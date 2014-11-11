namespace MirthConnectFX
{
    public class ChannelsService : IChannelsService
    {
        private readonly IMirthConnectRequestFactory mirthConnectRequestFactory;
        private readonly IMirthConnectSession session;

        public ChannelsService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
        {
            this.mirthConnectRequestFactory = mirthConnectRequestFactory;
            this.session = session;
        }
        
        public string GetChannelSummary()
        {
            var request = mirthConnectRequestFactory.Create("channels");
            request.AuthSessionId = session.SessionID;
            request.AddPostData("op", "getChannelSummary");
            request.AddPostData("cachedChannels", "<map/>");

            var response = request.Execute();

            return response.Content;
        }
    }
}