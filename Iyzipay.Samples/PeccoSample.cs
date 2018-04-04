using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class PeccoSample : Sample
    {
        [Test]
        public async Task Should_Initialize_Pecco()
        {
            CreatePeccoInitializeRequest request = new CreatePeccoInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "100000",
                PaidPrice = "120000",
                Currency = Currency.IRR.ToString(),
                BasketId = "B67832",
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = "https://www.merchant.com/callback"
            };

            Buyer buyer = new Buyer
            {
                Id = "BY789",
                Name = "John",
                Surname = "Doe",
                GsmNumber = "+905350000000",
                Email = "email@email.com",
                IdentityNumber = "74300864791",
                LastLoginDate = "2015-10-05 12:43:35",
                RegistrationDate = "2013-04-21 15:12:09",
                RegistrationAddress = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                Ip = "85.34.78.112",
                City = "Istanbul",
                Country = "Turkey",
                ZipCode = "34732"
            };
            request.Buyer = buyer;

            Address shippingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem firstBasketItem = new BasketItem
            {
                Id = "BI101",
                Name = "Binocular",
                Category1 = "Collectibles",
                Category2 = "Accessories",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "30000"
            };
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem
            {
                Id = "BI102",
                Name = "Game code",
                Category1 = "Game",
                Category2 = "Online Game Items",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = "50000"
            };
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem
            {
                Id = "BI103",
                Name = "Usb",
                Category1 = "Electronics",
                Category2 = "Usb / Cable",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "20000"
            };
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            PeccoInitialize peccoInitialize = await PeccoInitialize.CreateAsync(request, Options);

            PrintResponse(peccoInitialize);

            Assert.AreEqual(Status.SUCCESS.ToString(), peccoInitialize.Status);
            Assert.AreEqual(Locale.TR.ToString(), peccoInitialize.Locale);
            Assert.AreEqual("123456789", peccoInitialize.ConversationId);
            Assert.IsNotNull(peccoInitialize.SystemTime);
            Assert.IsNull(peccoInitialize.ErrorCode);
            Assert.IsNull(peccoInitialize.ErrorMessage);
            Assert.IsNull(peccoInitialize.ErrorGroup);
            Assert.IsNotNull(peccoInitialize.HtmlContent);
        }

        [Test]
        public async Task Should_Create_Pecco_Payment()
        {
            CreatePeccoPaymentRequest request = new CreatePeccoPaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Token = "token"
            };

            PeccoPayment peccoPayment = await PeccoPayment.CreateAsync(request, Options);

            PrintResponse(peccoPayment);

            Assert.AreEqual(Status.SUCCESS.ToString(), peccoPayment.Status);
            Assert.AreEqual(Locale.TR.ToString(), peccoPayment.Locale);
            Assert.AreEqual("123456789", peccoPayment.ConversationId);
            Assert.IsNotNull(peccoPayment.SystemTime);
            Assert.IsNull(peccoPayment.ErrorCode);
            Assert.IsNull(peccoPayment.ErrorMessage);
            Assert.IsNull(peccoPayment.ErrorGroup);
        }
    }
}
