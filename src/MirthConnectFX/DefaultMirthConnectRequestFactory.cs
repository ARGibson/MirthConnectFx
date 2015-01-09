namespace MirthConnectFX
{
    public class DefaultMirthConnectRequestFactory : IMirthConnectRequestFactory
    {
        private string baseUrl;

        protected string BaseUrl
        {
            get { return baseUrl; }
            private set
            {
                baseUrl = value;

                if (!baseUrl.EndsWith("/"))
                    baseUrl = string.Concat(baseUrl, "/");
            }
        }

        protected IHttpWebRequestFactory HttpWebRequestFactory { get; set; }

        public DefaultMirthConnectRequestFactory(string baseUrl)
        {
            BaseUrl = baseUrl;
            HttpWebRequestFactory = new HttpWebRequestFactory();
        }
        
        public virtual IMirthConnectRequest Create(string path)
        {
            return new MirthConnectRequest(HttpWebRequestFactory, string.Concat(BaseUrl, path));
        }
    }
}