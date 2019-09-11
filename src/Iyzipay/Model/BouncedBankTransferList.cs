using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Request;
using Newtonsoft.Json;

namespace Armut.Iyzipay.Model
{
    public class BouncedBankTransferList : IyzipayResource
    {
        private const string BouncedBankTransferListUrl = "/reporting/settlement/bounced";

        [JsonProperty(PropertyName = "bouncedRows")]
        public List<BankTransfer> BankTransfers { get; set; }

        public static BouncedBankTransferList Retrieve(RetrieveTransactionsRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<BouncedBankTransferList>(options.BaseUrl + BouncedBankTransferListUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<BouncedBankTransferList> RetrieveAsync(RetrieveTransactionsRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<BouncedBankTransferList>(options.BaseUrl + BouncedBankTransferListUrl, GetHttpHeaders(request, options), request);
        }
    }
}
