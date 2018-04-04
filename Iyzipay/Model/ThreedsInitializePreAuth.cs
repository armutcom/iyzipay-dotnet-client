using System.Threading.Tasks;
using Armut.Iyzipay.Request;
using Newtonsoft.Json;

namespace Armut.Iyzipay.Model
{
    public class ThreedsInitializePreAuth : IyzipayResource
    {
        private const string ThreedsInitializePreAuthUrl = "/payment/3dsecure/initialize/preauth";

        [JsonProperty(PropertyName = "threeDSHtmlContent")]
        public string HtmlContent { get; set; }

        public static ThreedsInitializePreAuth Create(CreatePaymentRequest request, Options options)
        {
            ThreedsInitializePreAuth response = RestHttpClient.Create().Post<ThreedsInitializePreAuth>(options.BaseUrl + ThreedsInitializePreAuthUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }

        public static async Task<ThreedsInitializePreAuth> CreateAsync(CreatePaymentRequest request, Options options)
        {
            ThreedsInitializePreAuth response = await RestHttpClient.Create().PostAsync<ThreedsInitializePreAuth>(options.BaseUrl + ThreedsInitializePreAuthUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }
    }
}
