using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public sealed class CreateCardRequestBuilder : BaseRequestBuilder<CreateCardRequest>
    {
        private string _email;
        private string _cardUserKey;
        private CardInformation _card;
        private string _externalId;

        private CreateCardRequestBuilder()
        {
        }

        public static CreateCardRequestBuilder Create()
        {
            return new CreateCardRequestBuilder();
        }

        public CreateCardRequestBuilder ExternalId(string externalId)
        {
            _externalId = externalId;
            return this;
        }

        public CreateCardRequestBuilder Email(string email)
        {
            _email = email;
            return this;
        }

        public CreateCardRequestBuilder CardUserKey(string cardUserKey)
        {
            _cardUserKey = cardUserKey;
            return this;
        }

        public CreateCardRequestBuilder Card(CardInformation card)
        {
            _card = card;
            return this;
        }

        public override CreateCardRequest Build()
        {
            CreateCardRequest createCardRequest = new CreateCardRequest
            {
                Locale = Locale,
                ConversationId = ConversationId,
                ExternalId = _externalId,
                Email = _email,
                CardUserKey = _cardUserKey,
                Card = _card
            };
            return createCardRequest;
        }
    }
}
