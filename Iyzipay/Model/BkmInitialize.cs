using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class BkmInitialize : IyzipayResource
    {
        private const string BkmInitializeUrl = "/payment/bkm/initialize";

        public string HtmlContent { get; set; }
        public string Token { get; set; }
        
        public static BkmInitialize Create(CreateBkmInitializeRequest request, Options options)
        {
            BkmInitialize response = RestHttpClient.Create().Post<BkmInitialize>(options.BaseUrl + BkmInitializeUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }

        public static async Task<BkmInitialize> CreateAsync(CreateBkmInitializeRequest request, Options options)
        {
            BkmInitialize response = await RestHttpClient.Create().PostAsync<BkmInitialize>(options.BaseUrl + BkmInitializeUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }
    }
}
