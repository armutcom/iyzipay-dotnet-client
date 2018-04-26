using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class Approval : IyzipayResource
    {
        private const string ApprovalUrl = "/payment/iyzipos/item/approve";

        public string PaymentTransactionId { get; set; }

        public static Approval Create(CreateApprovalRequest request, Options options)
        {
            return  RestHttpClient.Instance.Post<Approval>(options.BaseUrl + ApprovalUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Approval> CreateAsync(CreateApprovalRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<Approval>(options.BaseUrl + ApprovalUrl, GetHttpHeaders(request, options), request);
        }
    }
}
