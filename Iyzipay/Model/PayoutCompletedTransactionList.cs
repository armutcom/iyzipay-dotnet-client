using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class PayoutCompletedTransactionList : IyzipayResource
    {
        private const string PayoutCompletedTransactionListUrl = "/reporting/settlement/payoutcompleted";

        public List<PayoutCompletedTransaction> PayoutCompletedTransactions { get; set; }

        public static PayoutCompletedTransactionList Retrieve(RetrieveTransactionsRequest request, Options options)
        {
            return RestHttpClient.Create().Post<PayoutCompletedTransactionList>(options.BaseUrl + PayoutCompletedTransactionListUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<PayoutCompletedTransactionList> RetrieveAsync(RetrieveTransactionsRequest request, Options options)
        {
            return await RestHttpClient.Create().PostAsync<PayoutCompletedTransactionList>(options.BaseUrl + PayoutCompletedTransactionListUrl, GetHttpHeaders(request, options), request);
        }
    }
}
