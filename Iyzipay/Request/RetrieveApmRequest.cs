namespace Armut.Iyzipay.Request
{
   public class RetrieveApmRequest : BaseRequest
    {
        public string PaymentId { get; set; }

        public override string ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPKIRequestString())
                .Append("paymentId", PaymentId)           
                .GetRequestString();
        }
    }
}
