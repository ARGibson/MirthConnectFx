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

        public void WithExpectedRequest(string url, string responseText = null, bool errorResponse = false)
        {
            var response = new MockHttpWebResponse();
            var request = new MockHttpWebRequest();

            response.Cookies = new CookieCollection { AuthCookie };

            if (responseText != null)
                response.SetResponseStream(new MemoryStream(Encoding.UTF8.GetBytes(responseText)));

            if (errorResponse)
                response.SetStatusCode(HttpStatusCode.InternalServerError);

            request.SetResponse(response);
            
            RequestFactory.SetRequest(url, request);
        }

        public static class Requests
        {
            public static string Configuration  { get { return "https://localhost:8443/configuration"; } }
            public static string Users          { get { return "https://localhost:8443/users"; } }
            public static string Channels       { get { return "https://localhost:8443/channels"; } }
        }
    }
}