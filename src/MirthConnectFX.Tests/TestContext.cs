using System.IO;
using System.Net;
using System.Text;
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

        public void WithExpectedRequest(string url, string responseText = null)
        {
            var response = new MockHttpWebResponse();
            var request = new MockHttpWebRequest();

            response.Cookies = new CookieCollection { AuthCookie };

            if (responseText != null)
                response.SetResponseStream(new MemoryStream(Encoding.UTF8.GetBytes(responseText)));

            request.SetResponse(response);
            
            RequestFactory.SetRequest(url, request);
        }
    }
}