using System;
using System.IO;
using System.Net;

namespace MirthConnectFX
{
    public class HttpWebRequestAdapter : IHttpWebRequest
    {
        private readonly HttpWebRequest request;

        public string Method
        {
            get { return request.Method; }
            set { request.Method = value; }
        }

        public string ContentType
        {
            get { return request.ContentType; }
            set { request.ContentType = value; }
        }

        public long ContentLength
        {
            get { return request.ContentLength; }
            set { request.ContentLength = value; }
        }

        public CookieContainer CookieContainer
        {
            get { return request.CookieContainer; }
            set { request.CookieContainer = value; }
        }

        public Uri RequestUri
        {
            get { return request.RequestUri; }
        }

        public HttpWebRequestAdapter(HttpWebRequest request)
        {
            this.request = request;
        }

        public IHttpWebResponse GetResponse()
        {
            return new HttpWebResponseAdapter((HttpWebResponse)request.GetResponse());
        }

        public Stream GetRequestStream()
        {
            return request.GetRequestStream();
        }
    }
}