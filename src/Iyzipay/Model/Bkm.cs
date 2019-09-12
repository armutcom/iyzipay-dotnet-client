using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class Bkm : PaymentResource
    {
        private const string BkmUrl = "/payment/bkm/auth/detail";

        public string Token { get; set; }
        public string CallbackUrl { get; set; }     

        public static Bkm Retrieve(RetrieveBkmRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<Bkm>(options.BaseUrl + BkmUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Bkm> RetrieveAsync(RetrieveBkmRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<Bkm>(options.BaseUrl + BkmUrl, GetHttpHeaders(request, options), request);
        }
    }
}
