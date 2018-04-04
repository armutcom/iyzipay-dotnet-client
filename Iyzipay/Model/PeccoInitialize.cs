using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class PeccoInitialize : IyzipayResource
    {
        private const string PeccoInitializeUrl = "/payment/pecco/initialize";

        public string HtmlContent { get; set; }
        public string RedirectUrl { get; set; }
        public string Token { get; set; }
        public long? TokenExpireTime { get; set; }

        public static PeccoInitialize Create(CreatePeccoInitializeRequest request, Options options)
        {
            return RestHttpClient.Create().Post<PeccoInitialize>(options.BaseUrl + PeccoInitializeUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<PeccoInitialize> CreateAsync(CreatePeccoInitializeRequest request, Options options)
        {
            return await RestHttpClient.Create().PostAsync<PeccoInitialize>(options.BaseUrl + PeccoInitializeUrl, GetHttpHeaders(request, options), request);
        }
    }
}
