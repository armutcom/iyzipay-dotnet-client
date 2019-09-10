using Newtonsoft.Json;

namespace Armut.Iyzipay.Model.V2
{
    public class TransactionDetailItem
    {
        public string TransactionType { get; set; }

        public string TransactionDate { get; set; }

        public long TransactionId { get; set; }

        public int AfterSettlement { get; set; }

        [JsonProperty(PropertyName = "paymentTxId")]
        public long PaymentTransactionId { get; set; }

        public long PaymentId { get; set; }

        public string ConversationId { get; set; }

        public string PaymentPhase { get; set; }

        public string Price { get; set; }

        public string PaidPrice { get; set; }

        public string TransactionCurrency { get; set; }

        public int Installment { get; set; }

        public int ThreeDS { get; set; }

        public string IyzicoCommission { get; set; }

        public string IyzicoFee { get; set; }

        public string Parity { get; set; }

        public string IyzicoConversionAmount { get; set; }

        public string SettlementCurrency { get; set; }

        public string MerchantPayoutAmount { get; set; }

        public string ConnectorType { get; set; }

        public string PosOrderId { get; set; }

        public string PosName { get; set; }

        public string SubMerchantKey { get; set; }

        public string SubMerchantPayoutAmount { get; set; }

        public string AuthCode { get; set; }

        public string HostReference { get; set; }

        public string BasketId { get; set; }

        public int? TransactionStatus { get; set; }

        public string Currency { get; set; }

        public string PaymentStatus { get; set; }

        public int? FraudStatus { get; set; }

        public string MerchantCommissionRate { get; set; }

        public string MerchantCommissionRateAmount { get; set; }

        public string IyziCommissionFee { get; set; }

        public string IyziCommissionRateAmount { get; set; }

        public string CardFamily { get; set; }

        public string CardType { get; set; }

        public string CardAssociation { get; set; }

        public string CardToken { get; set; }

        public string CardUserKey { get; set; }

        public string BinNumber { get; set; }

        [JsonProperty(PropertyName = "ItemTransactions")]
        public string ConnectorName { get; set; }

        public string Phase { get; set; }

        public string BlockageRate { get; set; }

        public string BlockageRateAmountMerchant { get; set; }

        public string BlockageRateAmountSubMerchant { get; set; }

        public string BlockageResolvedDate { get; set; }

        public string SubMerchantPayoutRate { get; set; }

        public string SubMerchantPrice { get; set; }
    }
}
