using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace MirthConnectFX
{
    public class MirthConnectResponse : IMirthConnectResponse
    {
        public List<Cookie> Cookies { get; private set; }
        public string Content { get; private set; }

        public MirthConnectResponse(IHttpWebResponse httpWebResponse)
        {
            ProcessResponse(httpWebResponse);
        }

        private void ProcessResponse(IHttpWebResponse httpWebResponse)
        {
            if (httpWebResponse.Cookies != null)
                Cookies = httpWebResponse.Cookies.Cast<Cookie>().ToList();

            using (var reader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                Content = reader.ReadToEnd();
            }
        }
    }
}