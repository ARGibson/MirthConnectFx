using System;
using System.Net;

namespace MirthConnectFX
{
    public class HttpWebRequestFactory : IHttpWebRequestFactory
    {
        public IHttpWebRequest Create(Uri uri)
        {
            return new HttpWebRequestAdapter((HttpWebRequest) HttpWebRequest.Create(uri));
        }
    }
}