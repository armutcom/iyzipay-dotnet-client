using Armut.Iyzipay.Request.V2;
using System.Threading.Tasks;

namespace Armut.Iyzipay.Model.V2
{
    public class TransactionDetail : TransactionDetailResource
    {
        public static TransactionDetail Retrieve(RetrieveTransactionDetailRequest request, Options options)
        {
            string url = options.BaseUrl
                + "/v2/reporting/payment/details?paymentConversationId="
                + request.PaymentConversationId;

            return RestHttpClient.Instance.Get<TransactionDetail>(url, GetHttpHeadersWithUrlParams(request, url, options));
        }

        public static async Task<TransactionDetail> RetrieveAsync(RetrieveTransactionDetailRequest request, Options options)
        {
            string url = options.BaseUrl
                + "/v2/reporting/payment/details?paymentConversationId="
                + request.PaymentConversationId;

            return await RestHttpClient.Instance.GetAsync<TransactionDetail>(url, GetHttpHeadersWithUrlParams(request, url, options));
        }
    }
}
