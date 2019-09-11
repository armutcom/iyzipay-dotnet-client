namespace Armut.Iyzipay.Request.V2
{
    public class RetrieveTransactionReportRequest : BaseRequestV2
    {
        public string TransactionDate { get; set; }
        
        public int Page { get; set; }
    }
}