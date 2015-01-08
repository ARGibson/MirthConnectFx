using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MirthConnectFX.Tests
{
    public class MockMirthConnectRequestFactory : DefaultMirthConnectRequestFactory
    {
        private const string BaseUrl = "https://localhost:8443/";

        public IList<MockMirthConnectRequest> Requests { get; private set; }
        
        public MockHttpWebRequestFactory MockHttpFactory 
        { 
            get { return (MockHttpWebRequestFactory) HttpWebRequestFactory; } 
        }

        public MockMirthConnectRequestFactory()
        {
            Requests = new List<MockMirthConnectRequest>();
        }

        public override IMirthConnectRequest Create(string path)
        {
            var request = new MockMirthConnectRequest(HttpWebRequestFactory, string.Concat(BaseUrl, path));
            Requests.Add(request);

            return request;
        }

        public MockMirthConnectRequestFactory SetHttpWebRequestFactory(IHttpWebRequestFactory factory)
        {
            HttpWebRequestFactory = factory;
            return this;
        }

        public MockMirthConnectRequestFactory AddRequest(string op, IHttpWebRequest request)
        {
            MockHttpFactory.AddRequest(op, request);
            return this;
        }
    }

    public class MockMirthConnectRequest : MirthConnectRequest
    {
        public string Operation { get; private set; }
        private readonly MockHttpWebRequestFactory httpRequestFactory;

        public MockMirthConnectRequest(IHttpWebRequestFactory httpRequestFactory, string url)
            : base(httpRequestFactory, url)
        {
            this.httpRequestFactory = (MockHttpWebRequestFactory)httpRequestFactory;
        }

        public override IMirthConnectRequest ForOperation(string operation)
        {
            httpRequestFactory.SetNextOperation(operation);
            Operation = operation;
            return base.ForOperation(operation);
        }
    }

    public class MockHttpWebRequestFactory : IHttpWebRequestFactory
    {
        private readonly IDictionary<string, IHttpWebRequest> requestMap;
        private string nextOperation;

        public MockHttpWebRequestFactory()
        {
            requestMap = new Dictionary<string, IHttpWebRequest>();
        }
        
        public IHttpWebRequest Create(Uri uri)
        {
            return string.IsNullOrWhiteSpace(nextOperation) || !requestMap.ContainsKey(nextOperation) 
                ? new MockHttpWebRequest() 
                : requestMap[nextOperation];
        }

        public void AddRequest(string op, IHttpWebRequest request)
        {
            requestMap.Add(op, request);
        }

        public void SetNextOperation(string operation)
        {
            nextOperation = operation;
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
        public HttpStatusCode StatusCode { get; private set; }

        public MockHttpWebResponse()
        {
            responseStream = Stream.Null;
        }

        public Stream GetResponseStream()
        {
            if (StatusCode == HttpStatusCode.InternalServerError)
                throw new WebException("The remote server returned an error: (500) Internal Server Error.");
            
            return responseStream;
        }
        
        public void SetResponseStream(Stream stream)
        {
            responseStream = stream;
        }

        public void SetStatusCode(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}