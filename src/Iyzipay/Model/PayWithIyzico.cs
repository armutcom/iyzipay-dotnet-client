using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class PayWithIyzico : PaymentResource
    {
        public string Token { get; set; }

        public string CallbackUrl { get; set; }

        public static PayWithIyzico Retrieve(RetrievePayWithIyzicoRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<PayWithIyzico>(options.BaseUrl + "/payment/iyzipos/checkoutform/auth/ecom/detail", GetHttpHeaders(request, options), request);
        }

        public static async Task<PayWithIyzico> RetrieveAsync(RetrievePayWithIyzicoRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<PayWithIyzico>(options.BaseUrl + "/payment/iyzipos/checkoutform/auth/ecom/detail", GetHttpHeaders(request, options), request);
        }
    }
}
