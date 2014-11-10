using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace MirthConnectFX
{
    public class MirthConnectResponse : IMirthConnectResponse
    {
        public List<Cookie> Cookies { get; private set; }

        public MirthConnectResponse(IHttpWebResponse httpWebResponse)
        {
            ProcessResponse(httpWebResponse);
        }

        private void ProcessResponse(IHttpWebResponse httpWebResponse)
        {
            Cookies = httpWebResponse.Cookies.Cast<Cookie>().ToList();
        }
    }
}