namespace MirthConnectFX
{
    public interface IMirthConnectRequestFactory
    {
        IMirthConnectRequest CreateRemoteRequest(string path);
    }
}