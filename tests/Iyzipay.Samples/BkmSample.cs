using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class BkmSample : Sample
    {
        [Test]
        public async Task Should_Initialize_Bkm()
        {
            CreateBkmInitializeRequest request = new CreateBkmInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "1",
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

            BkmInitialize bkmInitialize = await BkmInitialize.CreateAsync(request, Options);

            PrintResponse(bkmInitialize);

            Assert.AreEqual(Status.SUCCESS.ToString(), bkmInitialize.Status);
            Assert.AreEqual(Locale.TR.ToString(), bkmInitialize.Locale);
            Assert.AreEqual("123456789", bkmInitialize.ConversationId);
            Assert.IsNotNull(bkmInitialize.SystemTime);
            Assert.IsNull(bkmInitialize.ErrorCode);
            Assert.IsNull(bkmInitialize.ErrorMessage);
            Assert.IsNull(bkmInitialize.ErrorGroup);
            Assert.IsNotNull(bkmInitialize.HtmlContent);
        }

        [Test]
        public async Task Should_Retrieve_Bkm_Result()
        {
            RetrieveBkmRequest request = new RetrieveBkmRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Token = "token"
            };

            Bkm bkm = await Bkm.RetrieveAsync(request, Options);

            PrintResponse(bkm);

            Assert.AreEqual(Status.SUCCESS.ToString(), bkm.Status);
            Assert.AreEqual(Locale.TR.ToString(), bkm.Locale);
            Assert.AreEqual("123456789", bkm.ConversationId);
            Assert.IsNotNull(bkm.SystemTime);
            Assert.IsNull(bkm.ErrorCode);
            Assert.IsNull(bkm.ErrorMessage);
            Assert.IsNull(bkm.ErrorGroup);
        }
    }
}
