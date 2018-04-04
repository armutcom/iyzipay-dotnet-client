using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class Payment : PaymentResource
    {
        private const string PaymentCreateUrl = "/payment/auth";
        private const string PaymentRetrieveUrl = "/payment/detail";

        public static Payment Create(CreatePaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Payment>(options.BaseUrl + PaymentCreateUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Payment> CreateAsync(CreatePaymentRequest request, Options options)
        {
            return await RestHttpClient.Create().PostAsync<Payment>(options.BaseUrl + PaymentCreateUrl, GetHttpHeaders(request, options), request);
        }

        public static Payment Retrieve(RetrievePaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Payment>(options.BaseUrl + PaymentRetrieveUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Payment> RetrieveAsync(RetrievePaymentRequest request, Options options)
        {
            return await RestHttpClient.Create().PostAsync<Payment>(options.BaseUrl + PaymentRetrieveUrl, GetHttpHeaders(request, options), request);
        }
    }
}
