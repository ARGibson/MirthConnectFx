namespace MirthConnectFX
{
    public interface IMirthConnectRequest
    {
        string AuthSessionId { get; set; }
        
        IMirthConnectResponse Execute();
        void AddPostData(string key, string value);
    }
}