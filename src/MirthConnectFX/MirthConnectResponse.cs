using System.Collections.Generic;
using System.Net;

namespace MirthConnectFX
{
    public class MirthConnectResponse : IMirthConnectResponse
    {
        public List<Cookie> Cookies { get; private set; }
    }
}