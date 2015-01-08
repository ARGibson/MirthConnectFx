using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MirthConnectFX
{
    public class MirthConnectRequest : IMirthConnectRequest
    {
        private readonly IHttpWebRequestFactory httpRequestFactory;
        private readonly string url;
        private readonly IDictionary<string, string> postData;

        public string AuthSessionId { get; set; }

        public MirthConnectRequest(IHttpWebRequestFactory httpRequestFactory, string url)
        {
            this.httpRequestFactory = httpRequestFactory;
            this.url = url;
            this.postData = new Dictionary<string, string>();
        }

        public virtual IMirthConnectRequest ForOperation(string operation)
        {
            AddPostData("op", operation);
            return this;
        }

        public IMirthConnectResponse Execute()
        {
            var data = PreparePostData();
            var httpRequest = httpRequestFactory.Create(new Uri(url));

            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.ContentLength = data.Length;
            httpRequest.CookieContainer = new CookieContainer();

            IncludeAuthCookieIfAvailable(httpRequest);

            using (var dataStream = httpRequest.GetRequestStream())
            {
                dataStream.Write(data, 0, data.Length);
            }

            return new MirthConnectResponse(httpRequest.GetResponse());
        }

        public void AddPostData(string key, string value)
        {
            postData.Add(key, value);
        }

        public IDictionary<string, string> GetPostData()
        {
            return postData;
        }

        private byte[] PreparePostData()
        {
            var sb = new StringBuilder();
            foreach (var postItem in postData)
                sb.AppendFormat("{0}={1}&", postItem.Key, postItem.Value);

            return Encoding.UTF8.GetBytes(sb.ToString().TrimEnd('&'));
        }

        private void IncludeAuthCookieIfAvailable(IHttpWebRequest httpRequest)
        {
            if (!string.IsNullOrWhiteSpace(AuthSessionId))
                httpRequest.CookieContainer.Add(new Cookie("JSESSIONID", AuthSessionId, "/", httpRequest.RequestUri.Host));
        }
    }
}