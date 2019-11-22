using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class PayWithIyzicoInitialize : PayWithIyzicoInitializeResource
    {
        public static PayWithIyzicoInitialize Create(CreatePayWithIyzicoInitializeRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<PayWithIyzicoInitialize>(options.BaseUrl + "/payment/pay-with-iyzico/initialize", GetHttpHeaders(request, options), request);
        }

        public static async Task<PayWithIyzicoInitialize> CreateAsync(CreatePayWithIyzicoInitializeRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<PayWithIyzicoInitialize>(options.BaseUrl + "/payment/pay-with-iyzico/initialize", GetHttpHeaders(request, options), request);
        }
    }
}
