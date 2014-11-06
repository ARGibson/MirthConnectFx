using System.Collections.Generic;
using System.Net;

namespace MirthConnectFX
{
    public interface IRemoteResponse
    {
        List<Cookie> Cookies { get; }
    }
}