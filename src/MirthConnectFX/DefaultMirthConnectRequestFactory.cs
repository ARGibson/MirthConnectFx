namespace MirthConnectFX
{
    public class DefaultMirthConnectRequestFactory : IMirthConnectRequestFactory
    {
        private const string BaseUrl = "https://localhost:8443/";

        protected IHttpWebRequestFactory HttpWebRequestFactory { get; set; }

        public DefaultMirthConnectRequestFactory()
        {
            HttpWebRequestFactory = new HttpWebRequestFactory();
        }
        
        public virtual IMirthConnectRequest Create(string path)
        {
            return new MirthConnectRequest(HttpWebRequestFactory, string.Concat(BaseUrl, path));
        }
    }
}