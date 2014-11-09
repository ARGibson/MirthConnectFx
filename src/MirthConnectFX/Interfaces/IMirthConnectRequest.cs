namespace MirthConnectFX
{
    public interface IMirthConnectRequest
    {
        IMirthConnectResponse Execute();
        void AddPostData(string key, string value);
    }
}