using System.Threading.Tasks;
using Armut.Iyzipay.Request;
using Newtonsoft.Json;

namespace Armut.Iyzipay.Model
{
    public class BasicThreedsInitializePreAuth : IyzipayResource
    {
        private const string BasicThreedsInitializePreAuthUrl = "/payment/3dsecure/initialize/preauth/basic";

        [JsonProperty(PropertyName = "threeDSHtmlContent")]
        public string HtmlContent { get; set; }

        public static BasicThreedsInitializePreAuth Create(CreateBasicPaymentRequest request, Options options)
        {
            BasicThreedsInitializePreAuth response = RestHttpClient.Instance.Post<BasicThreedsInitializePreAuth>(options.BaseUrl + BasicThreedsInitializePreAuthUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }

        public static async Task<BasicThreedsInitializePreAuth> CreateAsync(CreateBasicPaymentRequest request, Options options)
        {
            BasicThreedsInitializePreAuth response = await RestHttpClient.Instance.PostAsync<BasicThreedsInitializePreAuth>(options.BaseUrl + BasicThreedsInitializePreAuthUrl, GetHttpHeaders(request, options), request);

            if (response != null)
            {
                response.HtmlContent = DigestHelper.DecodeString(response.HtmlContent);
            }
            return response;
        }
    }
}
