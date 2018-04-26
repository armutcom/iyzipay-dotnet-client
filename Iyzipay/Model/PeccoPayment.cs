using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class PeccoPayment : PaymentResource
    {
        private const string PeccoPaymentUrl = "/payment/pecco/auth";

        public string Token { get; set; }

        public static PeccoPayment Create(CreatePeccoPaymentRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<PeccoPayment>(options.BaseUrl + PeccoPaymentUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<PeccoPayment> CreateAsync(CreatePeccoPaymentRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<PeccoPayment>(options.BaseUrl + PeccoPaymentUrl, GetHttpHeaders(request, options), request);
        }
    }
}
