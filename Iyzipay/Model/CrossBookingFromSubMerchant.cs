using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class CrossBookingFromSubMerchant : IyzipayResource
    {
        private const string CrossBookingFromSubMerchantUrl = "/crossbooking/receive";

        public static CrossBookingFromSubMerchant Create(CreateCrossBookingRequest request, Options options)
        {
            return RestHttpClient.Create().Post<CrossBookingFromSubMerchant>(options.BaseUrl + CrossBookingFromSubMerchantUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<CrossBookingFromSubMerchant> CreateAsync(CreateCrossBookingRequest request, Options options)
        {
            return await RestHttpClient.Create().PostAsync<CrossBookingFromSubMerchant>(options.BaseUrl + CrossBookingFromSubMerchantUrl, GetHttpHeaders(request, options), request);
        }
    }
}
