using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security;
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

            try
            {
                return new MirthConnectResponse(httpRequest.GetResponse());
            }
            catch (WebException ex)
            {
                const string message = "Mirth returned error processing request";
                var remoteError = string.Empty;
                
                if (ex.Response == null)
                    throw new MirthConnectException(message, remoteError, ex);

                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    remoteError = reader.ReadToEnd();
                }

                throw new MirthConnectException(message, remoteError, ex);
            }
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
                sb.AppendFormat("{0}={1}&", postItem.Key, UrlEncode(postItem.Value));

            return Encoding.UTF8.GetBytes(sb.ToString().TrimEnd('&'));
        }

        private static string UrlEncode(string value)
        {
            const int limit = 2000;
            var sb = new StringBuilder();
            var loops = value.Length / limit;

            for (var i = 0; i <= loops; i++)
            {
                sb.Append(i < loops
                    ? Uri.EscapeDataString(value.Substring(limit*i, limit))
                    : Uri.EscapeDataString(value.Substring(limit*i)));
            }

            return sb.ToString();
        }

        private void IncludeAuthCookieIfAvailable(IHttpWebRequest httpRequest)
        {
            if (!string.IsNullOrWhiteSpace(AuthSessionId))
                httpRequest.CookieContainer.Add(new Cookie("JSESSIONID", AuthSessionId, "/", httpRequest.RequestUri.Host));
        }
    }
}