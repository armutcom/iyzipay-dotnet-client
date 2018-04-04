using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class Card : IyzipayResource
    {
        private const string CardUrl = "/cardstorage/card";

        public string ExternalId { get; set; }
        public string Email { get; set; }
        public string CardUserKey { get; set; }
        public string CardToken { get; set; }
        public string CardAlias { get; set; }
        public string BinNumber { get; set; }
        public string CardType { get; set; }
        public string CardAssociation { get; set; }
        public string CardFamily { get; set; }
        public long? CardBankCode { get; set; }
        public string CardBankName { get; set; }

        public static Card Create(CreateCardRequest request, Options options)
        {
            return RestHttpClient.Create().Post<Card>(options.BaseUrl + CardUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Card> CreateAsync(CreateCardRequest request, Options options)
        {
            return await RestHttpClient.Create().PostAsync<Card>(options.BaseUrl + CardUrl, GetHttpHeaders(request, options), request);
        }

        public static Card Delete(DeleteCardRequest request, Options options)
        {
            return RestHttpClient.Create().Delete<Card>(options.BaseUrl + CardUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Card> DeleteAsync(DeleteCardRequest request, Options options)
        {
            return await RestHttpClient.Create().DeleteAsync<Card>(options.BaseUrl + CardUrl, GetHttpHeaders(request, options), request);
        }
    }
}
