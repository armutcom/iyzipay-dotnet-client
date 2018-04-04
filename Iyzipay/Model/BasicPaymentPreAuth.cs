using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class BasicPaymentPreAuth : BasicPaymentResource
    {
        private const string BasicPaymentPreAuthUrl = "/payment/preauth/basic";

        public static BasicPaymentPreAuth Create(CreateBasicPaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<BasicPaymentPreAuth>(options.BaseUrl + BasicPaymentPreAuthUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<BasicPaymentPreAuth> CreateAsync(CreateBasicPaymentRequest request, Options options)
        {
            return await RestHttpClient.Create().PostAsync<BasicPaymentPreAuth>(options.BaseUrl + BasicPaymentPreAuthUrl, GetHttpHeaders(request, options), request);
        }
    }
}
