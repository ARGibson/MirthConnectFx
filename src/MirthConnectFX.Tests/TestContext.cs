using System;
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

        protected void WithExpectedRequest(string op, string responseText = null, bool errorResponse = false)
        {
            var response = new MockHttpWebResponse();
            var request = new MockHttpWebRequest();

            response.Cookies = new CookieCollection { AuthCookie };

            if (responseText != null)
                response.SetResponseStream(new MemoryStream(Encoding.UTF8.GetBytes(responseText)));

            if (errorResponse)
                response.SetStatusCode(HttpStatusCode.InternalServerError);

            request.SetResponse(response);
            
            RequestFactory.AddRequest(op, request);
        }

        protected TServiceInterface CreateService<TService, TServiceInterface>(string version = null) 
            where TService : ServiceBase
        {
            var session = new MirthConnectSession("12345") {Version = version};
            var service = Activator.CreateInstance(typeof (TService), new object[] {RequestFactory, session}, null);

            return (TServiceInterface) service;
        }
    }
}