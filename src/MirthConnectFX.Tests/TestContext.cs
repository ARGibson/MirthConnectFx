using System.Net;
using NUnit.Framework;

namespace MirthConnectFX.Tests
{
    public class TestContext
    {
        protected Cookie AuthCookie { get; set; }
        protected MockMirthConnectRequestFactory RequestFactory { get; set; }

        [SetUp]
        public void SetUp()
        {
            RequestFactory = new MockMirthConnectRequestFactory();
            RequestFactory.SetHttpWebRequestFactory(new MockHttpWebRequestFactory());
            AuthCookie = new Cookie("JSESSIONID", "12345", "/");
        }

        public void WithExpectedRequest(string url)
        {
            var response = new MockHttpWebResponse();
            var request = new MockHttpWebRequest();

            response.Cookies = new CookieCollection();
            response.Cookies.Add(AuthCookie);

            request.SetResponse(response);
            
            RequestFactory.SetRequest(url, request);
        }
    }
}