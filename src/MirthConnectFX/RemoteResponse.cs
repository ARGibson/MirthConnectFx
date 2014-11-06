using System.Collections.Generic;
using System.Net;

namespace MirthConnectFX
{
    public class RemoteResponse : IRemoteResponse
    {
        public List<Cookie> Cookies { get; private set; }
    }
}