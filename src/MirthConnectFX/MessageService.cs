using MirthConnectFX.Model;
using MirthConnectFX.Utility;

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

        public int CreateTempTable(string uid, MessageObjectFilter filter)
        {
            var request = CreateRequest().ForOperation(Operations.Messages.CreateTempTable);
            request.AddPostData("uid", uid);
            request.AddPostData("filter", filter.ToXml());

            var response = request.Execute();
            return int.Parse(response.Content);
        }
    }
}