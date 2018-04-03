using System;

namespace Armut.Iyzipay.Request
{
   public class RetrievePaymentRequest : BaseRequest
    {
        public String PaymentId { get; set; }
        public String PaymentConversationId { get; set; }

        public override String ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPKIRequestString())
                .Append("paymentId", PaymentId)
                .Append("paymentConversationId", PaymentConversationId)             
                .GetRequestString();
        }
    }
}
