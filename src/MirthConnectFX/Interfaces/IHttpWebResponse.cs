using System.IO;
using System.Net;

namespace MirthConnectFX
{
    public interface IHttpWebResponse
    {
        CookieCollection Cookies { get; set; }
        Stream GetResponseStream();
        HttpStatusCode StatusCode { get; }
    }
}