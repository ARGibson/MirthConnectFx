namespace MirthConnectFX
{
    public interface IRemoteRequest
    {
        IRemoteResponse Execute();
        void AddPostData(string key, string value);
    }
}