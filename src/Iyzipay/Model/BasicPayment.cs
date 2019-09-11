using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class BasicPayment : BasicPaymentResource
    {
        private const string BasicPaymentUrl = "/payment/auth/basic";

        public static BasicPayment Create(CreateBasicPaymentRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<BasicPayment>(options.BaseUrl + BasicPaymentUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<BasicPayment> CreateAsync(CreateBasicPaymentRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<BasicPayment>(options.BaseUrl + BasicPaymentUrl, GetHttpHeaders(request, options), request);
        }
    }
}
