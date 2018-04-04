using System.Threading.Tasks;
using Armut.Iyzipay.Request;
using Newtonsoft.Json;

namespace Armut.Iyzipay.Model
{
    public class BasicThreedsInitialize : IyzipayResource
    {
        private const string BasicThreedsInitializeUrl = "/payment/3dsecure/initialize/basic";

        [JsonProperty(PropertyName = "threeDSHtmlContent")]
        public string HtmlContent { get; set; }

        public static BasicThreedsInitialize Create(CreateBasicPaymentRequest request, Options options)
        {
            BasicThreedsInitialize response = RestHttpClient.Create().Post<BasicThreedsInitialize>(options.BaseUrl + BasicThreedsInitializeUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }

        public static async Task<BasicThreedsInitialize> CreateAsync(CreateBasicPaymentRequest request, Options options)
        {
            BasicThreedsInitialize response = await RestHttpClient.Create().PostAsync<BasicThreedsInitialize>(options.BaseUrl + BasicThreedsInitializeUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }
    }
}
