using System;
using System.Collections.Generic;
using System.Linq;
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

        public void RemoveFilterTable(string uid)
        {
            var request = CreateRequest().ForOperation(Operations.Messages.RemoveFilterTable);
            request.AddPostData("uid", uid);

            request.Execute();
        }

        public IEnumerable<MessageObject> GetMessagesByPage(string uid, int page, int pageSize, int maxMessages)
        {
            var request = CreateRequest().ForOperation(Operations.Messages.GetMessagesByPage);
            request.AddPostData("uid", uid);
            request.AddPostData("page", page.ToString());
            request.AddPostData("pageSize", pageSize.ToString());
            request.AddPostData("maxMessages", maxMessages.ToString());

            var response = request.Execute();
            var messages = response.Content.ToObject<MessageObjectList>();

            return messages.MessageObjects != null ? messages.MessageObjects.ToList() : new List<MessageObject>();
        }

        public void ProcessMessage(string channelId, string message, Protocol protocol)
        {
            var request = CreateRequest().ForOperation(Operations.Messages.ProcessMessage);
            var messageObject = new MessageObject
            {
                Id = Guid.NewGuid().ToString(),
                ChannelId = channelId,
                RawDataProtocol = protocol,
                RawData = message.Replace("\r\n", "&#xd;"),
                DateCreated = DateTime.Now.ToMirthDateTime("Europe/London"),
                ConnectorName = "Source"
            };

            request.AddPostData("message", messageObject.ToXml());

            request.Execute();
        }
    }
}