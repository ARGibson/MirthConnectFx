using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MirthConnectFX.Tests
{
    public class MockMirthConnectRequestFactory : DefaultMirthConnectRequestFactory
    {
        public IMirthConnectRequest LastRequest { get; private set; }
        
        public MockHttpWebRequestFactory MockHttpFactory 
        { 
            get { return (MockHttpWebRequestFactory) HttpWebRequestFactory; } 
        }

        public override IMirthConnectRequest Create(string path)
        {
            var request = base.Create(path);
            LastRequest = request;

            return request;
        }

        public MockMirthConnectRequestFactory SetHttpWebRequestFactory(IHttpWebRequestFactory factory)
        {
            HttpWebRequestFactory = factory;
            return this;
        }

        public MockMirthConnectRequestFactory SetRequest(string url, IHttpWebRequest request)
        {
            MockHttpFactory.SetRequest(url, request);
            return this;
        }
    }

    public class MockHttpWebRequestFactory : IHttpWebRequestFactory
    {
        private readonly IDictionary<string, IHttpWebRequest> requestMap;

        public MockHttpWebRequestFactory()
        {
            requestMap = new Dictionary<string, IHttpWebRequest>();
        }
        
        public IHttpWebRequest Create(Uri uri)
        {
            return requestMap.ContainsKey(uri.AbsoluteUri) ? requestMap[uri.AbsoluteUri] : new MockHttpWebRequest();
        }

        public void SetRequest(string url, IHttpWebRequest request)
        {
            requestMap.Add(url, request);
        }

        public IHttpWebRequest GetRequest(string channel)
        {
            return requestMap.ContainsKey(channel) ? requestMap[channel] : null;
        }
    }

    public class MockHttpWebRequest : IHttpWebRequest
    {
        private IHttpWebResponse response;

        public string Method { get; set; }
        public string ContentType { get; set; }
        public long ContentLength { get; set; }
        public CookieContainer CookieContainer { get; set; }
        public Uri RequestUri { get { return new Uri("https://localhost:8443"); } }

        public MockHttpWebRequest()
        {
            response = new MockHttpWebResponse();
        }

        public IHttpWebResponse GetResponse()
        {
            return response;
        }

        public Stream GetRequestStream()
        {
            return Stream.Null;
        }

        public void SetResponse(IHttpWebResponse response)
        {
            this.response = response;
        }
    }

    public class MockHttpWebResponse : IHttpWebResponse
    {
        private Stream responseStream;
        
        public CookieCollection Cookies { get; set; }

        public MockHttpWebResponse()
        {
            responseStream = Stream.Null;
        }

        public Stream GetResponseStream()
        {
            return responseStream;
        }

        public void SetResponseStream(Stream stream)
        {
            responseStream = stream;
        }
    }
}