using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class CheckoutForm : PaymentResource
    {
        private const string CheckoutFormUrl = "/payment/iyzipos/checkoutform/auth/ecom/detail";

        public string Token { get; set; }
        public string CallbackUrl { get; set; }      

        public static CheckoutForm Retrieve(RetrieveCheckoutFormRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<CheckoutForm>(options.BaseUrl + CheckoutFormUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<CheckoutForm> RetrieveAsync(RetrieveCheckoutFormRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<CheckoutForm>(options.BaseUrl + CheckoutFormUrl, GetHttpHeaders(request, options), request);
        }
    }
}
