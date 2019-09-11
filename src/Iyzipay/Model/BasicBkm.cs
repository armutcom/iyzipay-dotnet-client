using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class BasicBkm : BasicPaymentResource
    {
        private const string BasicBkmUrl = "/payment/bkm/auth/detail/basic";

        public string Token { get; set; }
        public string CallbackUrl { get; set; }
        public string PaymentStatus { get; set; }

        public static BasicBkm Retrieve(RetrieveBkmRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<BasicBkm>(options.BaseUrl + BasicBkmUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<BasicBkm> RetrieveAsync(RetrieveBkmRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<BasicBkm>(options.BaseUrl + BasicBkmUrl, GetHttpHeaders(request, options), request);
        }
    }
}
