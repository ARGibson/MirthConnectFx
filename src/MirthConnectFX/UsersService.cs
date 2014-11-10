﻿using System.Linq;

namespace MirthConnectFX
{
    public class UsersService : IUserService
    {
        private readonly IMirthConnectRequestFactory mirthConnectRequestFactory;

        public UsersService(IMirthConnectRequestFactory mirthConnectRequestFactory)
        {
            this.mirthConnectRequestFactory = mirthConnectRequestFactory;
        }
        
        public IMirthConnectSession Login(string username, string password, string version)
        {
            var request = mirthConnectRequestFactory.Create("users");
            request.AddPostData("op", "login");
            request.AddPostData("username", username);
            request.AddPostData("password", password);
            request.AddPostData("version", version);
            
            var response = request.Execute();
            var sessionCookie = response.Cookies.FirstOrDefault(x => x.Name == "JSESSIONID");

            return new MirthConnectSession(sessionCookie != null ? sessionCookie.Value : null);
        }
    }
}