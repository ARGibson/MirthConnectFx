using System;
using System.IO;
using System.Net;

namespace MirthConnectFX
{
    public interface IHttpWebRequest
    {
        string Method { get; set; }
        string ContentType { get; set; }
        long ContentLength { get; set; }
        CookieContainer CookieContainer { get; set; }
        Uri RequestUri { get; }
        IHttpWebResponse GetResponse();
        Stream GetRequestStream();
    }
}