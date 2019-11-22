using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public sealed class CreateApprovalRequestBuilder : BaseRequestBuilder<CreateApprovalRequest>
    {
        private string _paymentTransactionId;

        private CreateApprovalRequestBuilder()
        {
        }

        public static CreateApprovalRequestBuilder Create()
        {
            return new CreateApprovalRequestBuilder();
        }


        public CreateApprovalRequestBuilder PaymentTransactionId(string paymentTransactionId)
        {
            _paymentTransactionId = paymentTransactionId;
            return this;
        }

        public override CreateApprovalRequest Build()
        {
            CreateApprovalRequest createApprovalRequest = new CreateApprovalRequest
            {
                Locale = Locale,
                ConversationId = ConversationId,
                PaymentTransactionId = _paymentTransactionId
            };
            return createApprovalRequest;
        }
    }
}
