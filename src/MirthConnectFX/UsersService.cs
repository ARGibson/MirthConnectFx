using System.Linq;

namespace MirthConnectFX
{
    public class UsersService : ServiceBase, IUserService
    {
        public UsersService(IMirthConnectRequestFactory mirthConnectRequestFactory) 
            : base(mirthConnectRequestFactory, new MirthConnectSession(string.Empty), "users") {}
        
        public IMirthConnectSession Login(string username, string password, string version)
        {
            var request = CreateRequest("login");
            request.AddPostData("username", username);
            request.AddPostData("password", password);
            request.AddPostData("version", version);
            
            var response = request.Execute();
            var sessionCookie = response.Cookies.FirstOrDefault(x => x.Name == "JSESSIONID");

            return new MirthConnectSession(sessionCookie != null ? sessionCookie.Value : null);
        }
    }
}