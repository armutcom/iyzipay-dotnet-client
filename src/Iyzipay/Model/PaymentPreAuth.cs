using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class PaymentPreAuth : PaymentResource
    {
        private const string PaymentPreAuthCreateUrl = "/payment/preauth";
        private const string PaymentPreAuthRetrieveUrl = "/payment/detail";

        public static PaymentPreAuth Create(CreatePaymentRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<PaymentPreAuth>(options.BaseUrl + PaymentPreAuthCreateUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<PaymentPreAuth> CreateAsync(CreatePaymentRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<PaymentPreAuth>(options.BaseUrl + PaymentPreAuthCreateUrl, GetHttpHeaders(request, options), request);
        }

        public static PaymentPreAuth Retrieve(RetrievePaymentRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<PaymentPreAuth>(options.BaseUrl + PaymentPreAuthRetrieveUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<PaymentPreAuth> RetrieveAsync(RetrievePaymentRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<PaymentPreAuth>(options.BaseUrl + PaymentPreAuthRetrieveUrl, GetHttpHeaders(request, options), request);
        }
    }
}
