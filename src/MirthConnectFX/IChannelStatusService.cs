namespace MirthConnectFX
{
    public interface IChannelStatusService
    {
        void StopChannel(string channelId);
        void StartChannel(string channelId);
    }
}