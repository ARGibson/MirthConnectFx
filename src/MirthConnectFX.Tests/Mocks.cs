using System.Collections.Generic;
using System.Net;

namespace MirthConnectFX.Tests
{
    public class MockMirthConnectRequestFactory : IMirthConnectRequestFactory
    {
        public IMirthConnectRequest CreateRemoteRequest(string path)
        {
            return new MockMirthConnectRequest();
        }
    }
    
    public class MockMirthConnectRequest : IMirthConnectRequest
    {
        public IMirthConnectResponse Execute()
        {
            return new MockMirthConnectResponse();
        }

        public void AddPostData(string key, string value) { }
    }

    public class MockMirthConnectResponse : IMirthConnectResponse
    {
        public List<Cookie> Cookies
        {
            get { return new List<Cookie> { new Cookie("JSESSIONID", "12345", "/") }; }
        }
    }
}