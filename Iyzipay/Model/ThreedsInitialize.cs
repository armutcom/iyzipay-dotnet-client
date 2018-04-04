using System.Threading.Tasks;
using Armut.Iyzipay.Request;
using Newtonsoft.Json;

namespace Armut.Iyzipay.Model
{
    public class ThreedsInitialize : IyzipayResource
    {
        private const string ThreedsInitializeUrl = "/payment/3dsecure/initialize";

        [JsonProperty(PropertyName = "threeDSHtmlContent")]
        public string HtmlContent { get; set; }

        public static ThreedsInitialize Create(CreatePaymentRequest request, Options options)
        {
            ThreedsInitialize response = RestHttpClient.Create().Post<ThreedsInitialize>(options.BaseUrl + ThreedsInitializeUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }

        public static async Task<ThreedsInitialize> CreateAsync(CreatePaymentRequest request, Options options)
        {
            ThreedsInitialize response = await RestHttpClient.Create().PostAsync<ThreedsInitialize>(options.BaseUrl + ThreedsInitializeUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }
    }
}
