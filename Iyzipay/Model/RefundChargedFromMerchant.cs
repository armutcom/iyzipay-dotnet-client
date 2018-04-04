using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class RefundChargedFromMerchant : IyzipayResource
    {
        private const string RefundChargedFromMerchantUrl = "/payment/iyzipos/refund/merchant/charge";

        public string PaymentId { get; set; }
        public string PaymentTransactionId { get; set; }
        public string Price { get; set; }

        public static RefundChargedFromMerchant Create(CreateRefundRequest request, Options options)
        {
            return RestHttpClient.Create().Post<RefundChargedFromMerchant>(options.BaseUrl + RefundChargedFromMerchantUrl, GetHttpHeaders(request, options), request);
        }


        public static async Task<RefundChargedFromMerchant> CreateAsync(CreateRefundRequest request, Options options)
        {
            return await RestHttpClient.Create().PostAsync<RefundChargedFromMerchant>(options.BaseUrl + RefundChargedFromMerchantUrl, GetHttpHeaders(request, options), request);
        }
    }
}
