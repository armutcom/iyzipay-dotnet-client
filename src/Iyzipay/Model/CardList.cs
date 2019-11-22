using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class CardList : IyzipayResource
    {
        private const string CardListUrl = "/cardstorage/cards";

        public string CardUserKey { get; set; }
        public List<Card> CardDetails { get; set; }

        public static CardList Retrieve(RetrieveCardListRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<CardList>(options.BaseUrl + CardListUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<CardList> RetrieveAsync(RetrieveCardListRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<CardList>(options.BaseUrl + CardListUrl, GetHttpHeaders(request, options), request);
        }
    }
}
