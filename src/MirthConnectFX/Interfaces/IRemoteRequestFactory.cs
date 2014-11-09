namespace MirthConnectFX
{
    public interface IRemoteRequestFactory
    {
        IRemoteRequest CreateRemoteRequest(string path);
    }
}