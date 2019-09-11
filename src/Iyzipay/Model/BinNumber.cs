using System.Threading.Tasks;
using Armut.Iyzipay.Request;
using Newtonsoft.Json;

namespace Armut.Iyzipay.Model
{
    public class BinNumber : IyzipayResource
    {
        private const string BinNumberUrl = "/payment/bin/check";

        [JsonProperty(PropertyName = "binNumber")]
        public string Bin { get; set; }
        public string CardType { get; set; }
        public string CardAssociation { get; set; }
        public string CardFamily { get; set; }
        public string BankName { get; set; }
        public long BankCode { get; set; }

        public static BinNumber Retrieve(RetrieveBinNumberRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<BinNumber>(options.BaseUrl + BinNumberUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<BinNumber> RetrieveAsync(RetrieveBinNumberRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<BinNumber>(options.BaseUrl + BinNumberUrl, GetHttpHeaders(request, options), request);
        }
    }
}
