using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class PaymentSample : Sample
    {
        [Test]
        public async Task Should_Create_Payment()
        {
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = "B67832",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = "John Doe",
                CardNumber = "5528790000000008",
                ExpireMonth = "12",
                ExpireYear = "2030",
                Cvc = "123",
                RegisterCard = 0
            };
            request.PaymentCard = paymentCard;

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

            Payment payment = await Payment.CreateAsync(request, Options);

            PrintResponse(payment);

            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
            Assert.AreEqual("123456789", payment.ConversationId);
            Assert.IsNotNull(payment.SystemTime);
            Assert.IsNull(payment.ErrorCode);
            Assert.IsNull(payment.ErrorMessage);
            Assert.IsNull(payment.ErrorGroup);
        }

        [Test]
        public async Task Should_Create_Marketplace_Payment()
        {
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = "B67832",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardHolderName = "John Doe",
                CardNumber = "5528790000000008",
                ExpireMonth = "12",
                ExpireYear = "2020",
                Cvc = "123",
                RegisterCard = 0
            };
            request.PaymentCard = paymentCard;

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
                Price = "0.3",
                SubMerchantKey = "sub merchant key",
                SubMerchantPrice = "0.27"
            };
            basketItems.Add(firstBasketItem);

            BasketItem secondBasketItem = new BasketItem
            {
                Id = "BI102",
                Name = "Game code",
                Category1 = "Game",
                Category2 = "Online Game Items",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = "0.5",
                SubMerchantKey = "sub merchant key",
                SubMerchantPrice = "0.42"
            };
            basketItems.Add(secondBasketItem);

            BasketItem thirdBasketItem = new BasketItem
            {
                Id = "BI103",
                Name = "Usb",
                Category1 = "Electronics",
                Category2 = "Usb / Cable",
                ItemType = BasketItemType.PHYSICAL.ToString(),
                Price = "0.2",
                SubMerchantKey = "sub merchant key",
                SubMerchantPrice = "0.18"
            };
            basketItems.Add(thirdBasketItem);
            request.BasketItems = basketItems;

            Payment payment = await Payment.CreateAsync(request, Options);

            PrintResponse(payment);

            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
            Assert.AreEqual("123456789", payment.ConversationId);
            Assert.IsNotNull(payment.SystemTime);
            Assert.IsNull(payment.ErrorCode);
            Assert.IsNull(payment.ErrorMessage);
            Assert.IsNull(payment.ErrorGroup);
        }

        [Test]
        public async Task Should_Create_Payment_With_Registered_Card()
        {
            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                BasketId = "B67832",
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString()
            };

            PaymentCard paymentCard = new PaymentCard
            {
                CardUserKey = "card user key",
                CardToken = "card token"
            };
            request.PaymentCard = paymentCard;

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

            Payment payment = await Payment.CreateAsync(request, Options);

            PrintResponse(payment);

            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
            Assert.AreEqual("123456789", payment.ConversationId);
            Assert.IsNotNull(payment.SystemTime);
            Assert.IsNull(payment.ErrorCode);
            Assert.IsNull(payment.ErrorMessage);
            Assert.IsNull(payment.ErrorGroup);
        }

        [Test]
        public async Task Should_Retrieve_Payment_Result()
        {
            RetrievePaymentRequest request = new RetrievePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                PaymentId = "1",
                PaymentConversationId = "123456789"
            };

            Payment payment = await Payment.RetrieveAsync(request, Options);

            PrintResponse(payment);

            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
            Assert.AreEqual("123456789", payment.ConversationId);
            Assert.IsNotNull(payment.SystemTime);
            Assert.IsNull(payment.ErrorCode);
            Assert.IsNull(payment.ErrorMessage);
            Assert.IsNull(payment.ErrorGroup);
        }
    }
}
