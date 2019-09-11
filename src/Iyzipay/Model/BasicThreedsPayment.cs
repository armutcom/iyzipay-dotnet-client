using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class BasicThreedsPayment : BasicPaymentResource
    {
        private const string BasicThreedsPaymentUrl = "/payment/3dsecure/auth/basic";

        public static BasicThreedsPayment Create(CreateThreedsPaymentRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<BasicThreedsPayment>(options.BaseUrl + BasicThreedsPaymentUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<BasicThreedsPayment> CreateAsync(CreateThreedsPaymentRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<BasicThreedsPayment>(options.BaseUrl + BasicThreedsPaymentUrl, GetHttpHeaders(request, options), request);
        }
    }
}
