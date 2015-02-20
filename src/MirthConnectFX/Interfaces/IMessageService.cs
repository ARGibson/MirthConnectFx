using MirthConnectFX.Model;

namespace MirthConnectFX
{
    public interface IMessageService
    {
        void ClearMessages(string channelId);
        int CreateTempTable(string uid, MessageObjectFilter filter);
    }
}