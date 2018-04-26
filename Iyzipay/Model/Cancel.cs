using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class Cancel : IyzipayResource
    {
        private const string CancelUrl = "/payment/cancel";

        public string PaymentId { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }
        public string ConnectorName { get; set; }

        public static Cancel Create(CreateCancelRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<Cancel>(options.BaseUrl + CancelUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Cancel> CreateAsync(CreateCancelRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<Cancel>(options.BaseUrl + CancelUrl, GetHttpHeaders(request, options), request);
        }
    }
}
