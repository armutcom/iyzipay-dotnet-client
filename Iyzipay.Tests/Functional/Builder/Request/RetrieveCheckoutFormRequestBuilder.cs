using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public sealed class RetrieveCheckoutFormRequestBuilder : BaseRequestBuilder<RetrieveCheckoutFormRequest>
    {
        private string _token;

        private RetrieveCheckoutFormRequestBuilder()
        {
        }

        public static RetrieveCheckoutFormRequestBuilder Create()
        {
            return new RetrieveCheckoutFormRequestBuilder();
        }

        public RetrieveCheckoutFormRequestBuilder Token(string token)
        {
            _token = token;
            return this;
        }

        public override RetrieveCheckoutFormRequest Build()
        {
            RetrieveCheckoutFormRequest retrieveCheckoutFormRequest = new RetrieveCheckoutFormRequest
            {
                Locale = Locale,
                ConversationId = ConversationId,
                Token = _token
            };
            return retrieveCheckoutFormRequest;
        }
    }
}
