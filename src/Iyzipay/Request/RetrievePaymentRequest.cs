namespace Armut.Iyzipay.Request
{
   public class RetrievePaymentRequest : BaseRequest
    {
        public string PaymentId { get; set; }
        public string PaymentConversationId { get; set; }

        public override string ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPKIRequestString())
                .Append("paymentId", PaymentId)
                .Append("paymentConversationId", PaymentConversationId)             
                .GetRequestString();
        }
    }
}
