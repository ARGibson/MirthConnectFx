namespace MirthConnectFX
{
    public class ChannelStatusService : ServiceBase, IChannelStatusService
    {
        public ChannelStatusService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session, "channelstatus")
        {
        }

        public void StopChannel(string channelId)
        {
            var request = CreateRequest().ForOperation(Operations.ChannelStatus.StopChannel);
            request.AddPostData("id", channelId);

            request.Execute();
        }
    }
}