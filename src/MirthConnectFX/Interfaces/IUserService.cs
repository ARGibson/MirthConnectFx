namespace MirthConnectFX
{
    public interface IUserService
    {
        IMirthConnectSession Login(string username, string password, string version);
    }
}