namespace MirthConnectFX
{
    public class MessageService : ServiceBase, IMessageService
    {
        public MessageService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session, "messages")
        {
        }

        public void ClearMessages(string channelId)
        {
            var request = CreateRequest().ForOperation(Operations.Messages.ClearMessages);
            request.AddPostData("data", channelId);

            request.Execute();
        }
    }
}