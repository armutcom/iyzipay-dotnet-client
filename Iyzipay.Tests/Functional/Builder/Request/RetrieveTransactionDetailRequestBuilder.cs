using Armut.Iyzipay.Request.V2;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public class RetrieveTransactionDetailRequestBuilder : BaseRequestBuilderV2<RetrieveTransactionDetailRequest>
    {
        public static RetrieveTransactionDetailRequestBuilder Create()
        {
            return new RetrieveTransactionDetailRequestBuilder();
        }

        public override RetrieveTransactionDetailRequest Build()
        {
            return new RetrieveTransactionDetailRequest
            {
                ConversationId = "123456789",
                PaymentConversationId = "123456789"
            };
        }
    }
}
