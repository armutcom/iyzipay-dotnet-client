using Newtonsoft.Json;
using System.Collections.Generic;

namespace Armut.Iyzipay.Model.V2
{
    public class TransactionDetailItem
    {
        public long PaymentId { get; set; }

        public int  PaymentStatus { get; set; }

        public string PaymentRefundStatus { get; set; }

        public string Price { get; set; }

        public string PaidPrice { get; set; }

        public int? Installment { get; set; }

        public string MerchantCommissionRate { get; set; }

        public string MerchantCommissionRateAmount { get; set; }

        public string IyziCommissionFee { get; set; }

        public string IyziCommissionRateAmount { get; set; }

        public string PaymentConversationId { get; set; }

        public int? FraudStatus { get; set; }

        public string CardFamily { get; set; }

        public string CardType { get; set; }

        public string CardAssociation { get; set; }

        public string CardToken { get; set; }

        public string CardUserKey { get; set; }

        public string BinNumber { get; set; }

        public string LastFourDigits { get; set; }

        public string BasketId { get; set; }

        public string Currency { get; set; }

        public string ConnectorName { get; set; }

        public string AuthCode { get; set; }

        public string HostReference { get; set; }

        public string ThreeDS { get; set; }

        public string Phase { get; set; }

        public string AcquirerBankName { get; set; }

        public int? MdStatus { get; set; }

        public string CreatedDate { get; set; }

        public string UpdatedDate { get; set; }

        public string OrderId { get; set; }

        public List<TransactionDetailCancelItem> Cancels { get; set; }

        public List<PaymentTxDetailItem> ItemTransactions { get; set; }
    }
}
