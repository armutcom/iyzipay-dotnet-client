using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class CheckoutFormInitialize : CheckoutFormInitializeResource
    {
        private const string CheckoutFormUrl = "/payment/iyzipos/checkoutform/initialize/auth/ecom";

        public static CheckoutFormInitialize Create(CreateCheckoutFormInitializeRequest request, Options options)
        {
            return RestHttpClient.Create().Post<CheckoutFormInitialize>(options.BaseUrl + CheckoutFormUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<CheckoutFormInitialize> CreateAsync(CreateCheckoutFormInitializeRequest request, Options options)
        {
            return await RestHttpClient.Create().PostAsync<CheckoutFormInitialize>(options.BaseUrl + CheckoutFormUrl, GetHttpHeaders(request, options), request);
        }
    }
}
