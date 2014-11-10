﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MirthConnectFX
{
    public class MirthConnectRequest : IMirthConnectRequest
    {
        private readonly IHttpWebRequestFactory httpRequestFactory;
        private readonly string url;
        private IDictionary<string, string> postData;

        public MirthConnectRequest(IHttpWebRequestFactory httpRequestFactory, string url)
        {
            this.httpRequestFactory = httpRequestFactory;
            this.url = url;
            this.postData = new Dictionary<string, string>();
        }

        public IMirthConnectResponse Execute()
        {
            var postData = PreparePostData();
            var httpRequest = httpRequestFactory.Create(new Uri(url));

            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.ContentLength = postData.Length;
            httpRequest.CookieContainer = new CookieContainer();

            using (var dataStream = httpRequest.GetRequestStream())
            {
                dataStream.Write(postData, 0, postData.Length);
            }

            return new MirthConnectResponse(httpRequest.GetResponse());
        }

        public void AddPostData(string key, string value)
        {
            postData.Add(key, value);
        }

        private byte[] PreparePostData()
        {
            var sb = new StringBuilder();
            foreach (var postItem in postData)
                sb.AppendFormat("{0}={1}&", postItem.Key, postItem.Value);

            return Encoding.UTF8.GetBytes(sb.ToString().TrimEnd('&'));
        }
    }
}