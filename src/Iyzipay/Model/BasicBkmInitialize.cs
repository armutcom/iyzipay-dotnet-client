using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class BasicBkmInitialize : IyzipayResource
    {
        private const string BasicBkmInitializeUrl = "/payment/bkm/initialize/basic";

        public string HtmlContent { get; set; }
        public string Token { get; set; }
        
        public static BasicBkmInitialize Create(CreateBasicBkmInitializeRequest request, Options options)
        {
            BasicBkmInitialize response = RestHttpClient.Instance.Post<BasicBkmInitialize>(options.BaseUrl + BasicBkmInitializeUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }

        public static async Task<BasicBkmInitialize> CreateAsync(CreateBasicBkmInitializeRequest request, Options options)
        {
            BasicBkmInitialize response = await RestHttpClient.Instance.PostAsync<BasicBkmInitialize>(options.BaseUrl + BasicBkmInitializeUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }
    }
}
