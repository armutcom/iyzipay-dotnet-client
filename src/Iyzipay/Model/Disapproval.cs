using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class Disapproval : IyzipayResource
    {
        private const string DisapprovalUrl = "/payment/iyzipos/item/disapprove";

        public string PaymentTransactionId { get; set; }

        public static Disapproval Create(CreateApprovalRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<Disapproval>(options.BaseUrl + DisapprovalUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Disapproval> CreateAsync(CreateApprovalRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<Disapproval>(options.BaseUrl + DisapprovalUrl, GetHttpHeaders(request, options), request);
        }
    }
}
