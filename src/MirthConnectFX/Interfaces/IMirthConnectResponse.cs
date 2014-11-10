using System.Collections.Generic;
using System.Net;

namespace MirthConnectFX
{
    public interface IMirthConnectResponse
    {
        List<Cookie> Cookies { get; }
        string Content { get; }
    }
}