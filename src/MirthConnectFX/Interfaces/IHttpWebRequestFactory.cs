using System;

namespace MirthConnectFX
{
    public interface IHttpWebRequestFactory
    {
        IHttpWebRequest Create(Uri uri);
    }
}