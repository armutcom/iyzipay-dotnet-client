using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class PaymentItem : IyzipayResource
    {
        private const string PaymentItemUrl = "/payment/item";

        public string ItemId { get; set; }
        public string PaymentTransactionId { get; set; }
        public int? TransactionStatus { get; set; }
        public string Price { get; set; }
        public string PaidPrice { get; set; }
        public string MerchantCommissionRate { get; set; }
        public string MerchantCommissionRateAmount { get; set; }
        public string IyziCommissionRateAmount { get; set; }
        public string IyziCommissionFee { get; set; }
        public string BlockageRate { get; set; }
        public string BlockageRateAmountMerchant { get; set; }
        public string BlockageRateAmountSubMerchant { get; set; }
        public string BlockageResolvedDate { get; set; }
        public string SubMerchantKey { get; set; }
        public string SubMerchantPrice { get; set; }
        public string SubMerchantPayoutRate { get; set; }
        public string SubMerchantPayoutAmount { get; set; }
        public string MerchantPayoutAmount { get; set; }
        public ConvertedPayout ConvertedPayout { get; set; }

        public static PaymentItem Update(UpdatePaymentItemRequest request, Options options)
        {
            return RestHttpClient.Create().Put<PaymentItem>(options.BaseUrl + PaymentItemUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<PaymentItem> UpdateAsync(UpdatePaymentItemRequest request, Options options)
        {
            return await RestHttpClient.Create().PutAsync<PaymentItem>(options.BaseUrl + PaymentItemUrl, GetHttpHeaders(request, options), request);
        }
    }
}
