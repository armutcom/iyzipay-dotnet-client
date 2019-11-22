using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class ThreedsPayment : PaymentResource
    {
        private const string ThreedsPaymentCreateUrl = "/payment/3dsecure/auth";
        private const string ThreedsPaymentRetrieveUrl = "/payment/detail";

        public static ThreedsPayment Create(CreateThreedsPaymentRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<ThreedsPayment>(options.BaseUrl + ThreedsPaymentCreateUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<ThreedsPayment> CreateAsync(CreateThreedsPaymentRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<ThreedsPayment>(options.BaseUrl + ThreedsPaymentCreateUrl, GetHttpHeaders(request, options), request);
        }

        public static ThreedsPayment Retrieve(RetrievePaymentRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<ThreedsPayment>(options.BaseUrl + ThreedsPaymentRetrieveUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<ThreedsPayment> RetrieveAsync(RetrievePaymentRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<ThreedsPayment>(options.BaseUrl + ThreedsPaymentRetrieveUrl, GetHttpHeaders(request, options), request);
        }
    }
}
