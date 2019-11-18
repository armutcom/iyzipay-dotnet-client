using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class PayWithIyzicoSample : Sample
    {
        [Test]
        public async Task Should_Initialize_PayWithIyzico()
        {
            List<int> enabledInstallments = new List<int>();
            enabledInstallments.Add(2);
            enabledInstallments.Add(3);
            enabledInstallments.Add(6);
            enabledInstallments.Add(9);

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

            Address shippingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };

            Address billingAddress = new Address
            {
                ContactName = "Jane Doe",
                City = "Istanbul",
                Country = "Turkey",
                Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1",
                ZipCode = "34742"
            };

            List<BasketItem> basketItems = new List<BasketItem>
            {
                 new BasketItem
                {
                    Id = "BI101",
                    Name = "Binocular",
                    Category1 = "Collectibles",
                    Category2 = "Accessories",
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = "0.3"
                },
                 new BasketItem
                {
                    Id = "BI102",
                    Name = "Game code",
                    Category1 = "Game",
                    Category2 = "Online Game Items",
                    ItemType = BasketItemType.VIRTUAL.ToString(),
                    Price = "0.5"
                },
                  new BasketItem
                {
                    Id = "BI103",
                    Name = "Usb",
                    Category1 = "Electronics",
                    Category2 = "Usb / Cable",
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = "0.2"
                }
            };

            CreatePayWithIyzicoInitializeRequest request = new CreatePayWithIyzicoInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.TRY.ToString(),
                BasketId = "B67832",
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = "https://www.merchant.com/callback",
                EnabledInstallments = enabledInstallments,
                Buyer = buyer,
                ShippingAddress = shippingAddress,
                BillingAddress = billingAddress,
                BasketItems = basketItems
            };

            PayWithIyzicoInitialize payWithIyzicoInitialize = await PayWithIyzicoInitialize.CreateAsync(request, Options);

            PrintResponse<PayWithIyzicoInitialize>(payWithIyzicoInitialize);

            Assert.AreEqual(Status.SUCCESS.ToString(), payWithIyzicoInitialize.Status);
            Assert.AreEqual(Locale.TR.ToString(), payWithIyzicoInitialize.Locale);
            Assert.AreEqual("123456789", payWithIyzicoInitialize.ConversationId);
            Assert.IsNotNull(payWithIyzicoInitialize.SystemTime);
            Assert.IsNull(payWithIyzicoInitialize.ErrorCode);
            Assert.IsNull(payWithIyzicoInitialize.ErrorMessage);
            Assert.IsNull(payWithIyzicoInitialize.ErrorGroup);
            Assert.IsNotNull(payWithIyzicoInitialize.CheckoutFormContent);
            Assert.IsNotNull(payWithIyzicoInitialize.PayWithIyzicoPageUrl);
        }

        [Test]
        public async Task Should_Retrieve_PayWithIyzico_Result()
        {
            RetrievePayWithIyzicoRequest request = new RetrievePayWithIyzicoRequest
            {
                ConversationId = "123456789",
                Token = "cb3f2681-e397-473a-931c-2567fd235627"
            };

            PayWithIyzico payWithIyzicoResult = await PayWithIyzico.RetrieveAsync(request, Options);

            PrintResponse<PayWithIyzico>(payWithIyzicoResult);

            Assert.AreEqual(Status.SUCCESS.ToString(), payWithIyzicoResult.Status);
            Assert.AreEqual(Locale.TR.ToString(), payWithIyzicoResult.Locale);
            Assert.AreEqual("123456789", payWithIyzicoResult.ConversationId);
            Assert.IsNotNull(payWithIyzicoResult.SystemTime);
            Assert.IsNull(payWithIyzicoResult.ErrorCode);
            Assert.IsNull(payWithIyzicoResult.ErrorMessage);
            Assert.IsNull(payWithIyzicoResult.ErrorGroup);
        }
    }
}

