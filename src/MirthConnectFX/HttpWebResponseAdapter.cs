using System.IO;
using System.Net;

namespace MirthConnectFX
{
    public class HttpWebResponseAdapter : IHttpWebResponse
    {
        private readonly HttpWebResponse response;

        public CookieCollection Cookies
        {
            get { return response.Cookies; }
            set { response.Cookies = value; }
        }

        public HttpStatusCode StatusCode
        {
            get { return response.StatusCode; }
        }

        public HttpWebResponseAdapter(HttpWebResponse response)
        {
            this.response = response;
        }

        public Stream GetResponseStream()
        {
            return response.GetResponseStream();
        }
    }
}