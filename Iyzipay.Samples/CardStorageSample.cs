using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class CardStorageSample : Sample
    {
        [Test]
        public async Task Should_Create_User_And_Add_Card()
        {
            CreateCardRequest request = new CreateCardRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Email = "email@email.com",
                ExternalId = "external id"
            };

            CardInformation cardInformation = new CardInformation
            {
                CardAlias = "card alias",
                CardHolderName = "John Doe",
                CardNumber = "5528790000000008",
                ExpireMonth = "12",
                ExpireYear = "2030"
            };
            request.Card = cardInformation;

            Card card =  await Card.CreateAsync(request, Options);

            PrintResponse(card);

            Assert.AreEqual(Status.SUCCESS.ToString(), card.Status);
            Assert.AreEqual(Locale.TR.ToString(), card.Locale);
            Assert.AreEqual("123456789", card.ConversationId);
            Assert.IsNotNull(card.SystemTime);
            Assert.IsNull(card.ErrorCode);
            Assert.IsNull(card.ErrorMessage);
            Assert.IsNull(card.ErrorGroup);
            Assert.AreEqual("552879", card.BinNumber);
            Assert.AreEqual("card alias", card.CardAlias);
            Assert.AreEqual("CREDIT_CARD", card.CardType);
            Assert.AreEqual("MASTER_CARD", card.CardAssociation);
            Assert.AreEqual("Paraf", card.CardFamily);
            Assert.AreEqual("Halk Bankası", card.CardBankName);
            Assert.AreEqual(12, card.CardBankCode);
            Assert.IsNotNull(card.CardUserKey);
            Assert.IsNotNull(card.CardToken);
            Assert.AreEqual("email@email.com", card.Email);
            Assert.AreEqual("external id", card.ExternalId);
        }

        [Test]
        public async Task Should_Create_Card()
        {
            CreateCardRequest request = new CreateCardRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                CardUserKey = "card user key"
            };

            CardInformation cardInformation = new CardInformation
            {
                CardAlias = "card alias",
                CardHolderName = "John Doe",
                CardNumber = "5528790000000008",
                ExpireMonth = "12",
                ExpireYear = "2030"
            };
            request.Card = cardInformation;

            Card card = await Card.CreateAsync(request, Options);

            PrintResponse(card);

            Assert.AreEqual(Status.SUCCESS.ToString(), card.Status);
            Assert.AreEqual(Locale.TR.ToString(), card.Locale);
            Assert.AreEqual("123456789", card.ConversationId);
            Assert.IsNotNull(card.SystemTime);
            Assert.IsNull(card.ErrorCode);
            Assert.IsNull(card.ErrorMessage);
            Assert.IsNull(card.ErrorGroup);
            Assert.AreEqual("552879", card.BinNumber);
            Assert.AreEqual("card alias", card.CardAlias);
            Assert.AreEqual("CREDIT_CARD", card.CardType);
            Assert.AreEqual("MASTER_CARD", card.CardAssociation);
            Assert.AreEqual("Paraf", card.CardFamily);
            Assert.AreEqual("Halk Bankası", card.CardBankName);
            Assert.AreEqual(12, card.CardBankCode);
            Assert.IsNotNull(card.CardUserKey);
            Assert.IsNotNull(card.CardToken);
            Assert.IsNull(card.Email);
            Assert.IsNull(card.ExternalId);
        }

        [Test]
        public async Task Should_Delete_Card()
        {
            DeleteCardRequest request = new DeleteCardRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                CardToken = "card token",
                CardUserKey = "card user key"
            };

            Card card = await Card.DeleteAsync(request, Options);

            PrintResponse(card);

            Assert.AreEqual(Status.SUCCESS.ToString(), card.Status);
            Assert.AreEqual(Locale.TR.ToString(), card.Locale);
            Assert.AreEqual("123456789", card.ConversationId);
            Assert.IsNotNull(card.SystemTime);
            Assert.IsNull(card.ErrorCode);
            Assert.IsNull(card.ErrorMessage);
            Assert.IsNull(card.ErrorGroup);
            Assert.IsNull(card.BinNumber);
            Assert.IsNull(card.CardAlias);
            Assert.IsNull(card.CardType);
            Assert.IsNull(card.CardAssociation);
            Assert.IsNull(card.CardFamily);
            Assert.IsNull(card.CardBankName);
            Assert.IsNull(card.CardBankCode);
            Assert.IsNull(card.CardUserKey);
            Assert.IsNull(card.CardToken);
            Assert.IsNull(card.Email);
            Assert.IsNull(card.ExternalId);
        }

        [Test]
        public async Task Should_Retrieve_Cards()
        {
            RetrieveCardListRequest request = new RetrieveCardListRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                CardUserKey = "card user key"
            };

            CardList cardList = await CardList.RetrieveAsync(request, Options);

            PrintResponse(cardList);

            Assert.AreEqual(Status.SUCCESS.ToString(), cardList.Status);
            Assert.AreEqual(Locale.TR.ToString(), cardList.Locale);
            Assert.AreEqual("123456789", cardList.ConversationId);
            Assert.IsNotNull(cardList.SystemTime);
            Assert.IsNull(cardList.ErrorCode);
            Assert.IsNull(cardList.ErrorMessage);
            Assert.IsNull(cardList.ErrorGroup);
            Assert.IsNotNull(cardList.CardDetails);
            Assert.IsNotEmpty(cardList.CardDetails);
            Assert.IsNotNull(cardList.CardUserKey);
        }
    }
}
