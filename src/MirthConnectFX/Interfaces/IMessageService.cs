using System.Collections.Generic;
using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public interface IMessageService
    {
        void ClearMessages(string channelId);
        int CreateTempTable(string uid, MessageObjectFilter filter);
        void RemoveFilterTable(string uid);
        IEnumerable<MessageObject> GetMessagesByPage(string uid, int page, int pageSize, int maxMessages);
        //void ProcessMessage(string channelId, string message, Protocol protocol);
    }
}