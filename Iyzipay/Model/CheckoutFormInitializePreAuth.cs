using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class CheckoutFormInitializePreAuth : CheckoutFormInitializeResource
    {
        private const string CheckoutFormUrl = "/payment/iyzipos/checkoutform/initialize/preauth/ecom";

        public static CheckoutFormInitializePreAuth Create(CreateCheckoutFormInitializeRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<CheckoutFormInitializePreAuth>(options.BaseUrl + CheckoutFormUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<CheckoutFormInitializePreAuth> CreateAsync(CreateCheckoutFormInitializeRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<CheckoutFormInitializePreAuth>(options.BaseUrl + CheckoutFormUrl, GetHttpHeaders(request, options), request);
        }
    }
}
