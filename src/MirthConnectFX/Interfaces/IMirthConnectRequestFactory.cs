namespace MirthConnectFX
{
    public interface IMirthConnectRequestFactory
    {
        IMirthConnectRequest Create(string path);
    }
}