using System.Net.Http;
using System.Security.Authentication;

namespace Armut.Iyzipay
{
    public class HttpClient : System.Net.Http.HttpClient
    {

        public HttpClient()
#if NETSTANDARD
            : base(new HttpClientHandler(){ SslProtocols = SslProtocols.Tls12 } )
#endif
        {
        }
    }
}
