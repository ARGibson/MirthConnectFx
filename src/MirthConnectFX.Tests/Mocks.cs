using System.Collections.Generic;
using System.Net;

namespace MirthConnectFX.Tests
{
    public class MockRemoteRequestFactory : IRemoteRequestFactory
    {
        public IRemoteRequest CreateRemoteRequest(string path)
        {
            return new MockRemoteRequest();
        }
    }
    
    public class MockRemoteRequest : IRemoteRequest
    {
        public IRemoteResponse Execute()
        {
            return new MockRemoteResponse();
        }

        public void AddPostData(string key, string value) { }
    }

    public class MockRemoteResponse : IRemoteResponse
    {
        public List<Cookie> Cookies
        {
            get { return new List<Cookie> { new Cookie("JSESSIONID", "12345", "/") }; }
        }
    }
}