using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class BasicPaymentPostAuth : BasicPaymentResource
    {
        private const string BasicPaymentPostAuthUrl = "/payment/postauth/basic";

        public static BasicPaymentPostAuth Create(CreatePaymentPostAuthRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<BasicPaymentPostAuth>(options.BaseUrl + BasicPaymentPostAuthUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<BasicPaymentPostAuth> CreateAsync(CreatePaymentPostAuthRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<BasicPaymentPostAuth>(options.BaseUrl + BasicPaymentPostAuthUrl, GetHttpHeaders(request, options), request);
        }
    }
}
