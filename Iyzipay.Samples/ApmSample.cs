using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class ApmSample : Sample
    {
        [Test]
        public async Task Should_Initialize_Apm_Payment()
        {
            CreateApmInitializeRequest request = new CreateApmInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.EUR.ToString(),
                CountryCode = "DE",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                AccountHolderName = "success",
                MerchantCallbackUrl = "https://www.merchant.com/callback",
                MerchantErrorUrl = "https://www.merchant.com/error",
                MerchantNotificationUrl = "https://www.merchant.com/notification",
                ApmType = ApmType.SOFORT.ToString()
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
                Price = "0.3"
            };
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem
            {
                Id = "BI102",
                Name = "Game code",
                Category1 = "Game",
                Category2 = "Online Game Items",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = "0.5"
            };
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem
            {
                Id = "BI103",
                Name = "Usb",
                Category1 = "Electronics",
                Category2 = "Usb / Cable",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "0.2"
            };
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            var apmInitialize = await Apm.CreateAsync(request, Options);

            PrintResponse(apmInitialize);

            Assert.AreEqual(Status.SUCCESS.ToString(), apmInitialize.Status);
            Assert.AreEqual(Locale.TR.ToString(), apmInitialize.Locale);
            Assert.AreEqual("123456789", apmInitialize.ConversationId);
            Assert.IsNotNull(apmInitialize.SystemTime);
            Assert.IsNull(apmInitialize.ErrorCode);
            Assert.IsNull(apmInitialize.ErrorMessage);
            Assert.IsNull(apmInitialize.ErrorGroup);
        }

        [Test]
        public async Task Should_Retrieve_Apm_Result()
        {
            RetrieveApmRequest request = new RetrieveApmRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                PaymentId = "1"
            };

            Apm retrieve = await Apm.RetrieveAsync(request, Options);

            PrintResponse(retrieve);

            Assert.AreEqual(Status.SUCCESS.ToString(), retrieve.Status);
            Assert.AreEqual(Locale.TR.ToString(), retrieve.Locale);
            Assert.AreEqual("123456789", retrieve.ConversationId);
        }
    }
}
