namespace MirthConnectFX
{
    public interface IMirthConnectRequest
    {
        string AuthSessionId { get; set; }

        IMirthConnectRequest ForOperation(string operation);
        IMirthConnectResponse Execute();
        void AddPostData(string key, string value);
    }
}