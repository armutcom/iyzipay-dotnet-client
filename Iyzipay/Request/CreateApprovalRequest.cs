using System;

namespace Armut.Iyzipay.Request
{
    public class CreateApprovalRequest : BaseRequest
    {
        public String PaymentTransactionId { get; set; }

        public override String ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPKIRequestString())
                .Append("paymentTransactionId", PaymentTransactionId)
                .GetRequestString();
        }
    }
}
