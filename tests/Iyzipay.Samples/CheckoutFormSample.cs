using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class CheckoutFormSample : Sample
    {
        [Test]
        public async Task Should_Initialize_Checkout_Form()
        {
            CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Price = "1",
                PaidPrice = "1.2",
                Currency = Currency.TRY.ToString(),
                BasketId = "B67832",
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                CallbackUrl = "https://www.merchant.com/callback"
            };

            List<int> enabledInstallments = new List<int> {2, 3, 6, 9};
            request.EnabledInstallments = enabledInstallments;

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

            CheckoutFormInitialize checkoutFormInitialize = await CheckoutFormInitialize.CreateAsync(request, Options);

            PrintResponse(checkoutFormInitialize);

            Assert.AreEqual(Status.SUCCESS.ToString(), checkoutFormInitialize.Status);
            Assert.AreEqual(Locale.TR.ToString(), checkoutFormInitialize.Locale);
            Assert.AreEqual("123456789", checkoutFormInitialize.ConversationId);
            Assert.IsNotNull(checkoutFormInitialize.SystemTime);
            Assert.IsNull(checkoutFormInitialize.ErrorCode);
            Assert.IsNull(checkoutFormInitialize.ErrorMessage);
            Assert.IsNull(checkoutFormInitialize.ErrorGroup);
            Assert.IsNotNull(checkoutFormInitialize.CheckoutFormContent);
            Assert.IsNotNull(checkoutFormInitialize.PaymentPageUrl);
        }

        [Test]
        public async Task Should_Retrieve_Checkout_Form_Result()
        {
            RetrieveCheckoutFormRequest request = new RetrieveCheckoutFormRequest
            {
                ConversationId = "123456789",
                Token = "token"
            };

            CheckoutForm checkoutForm = await CheckoutForm.RetrieveAsync(request, Options);

            PrintResponse(checkoutForm);

            Assert.AreEqual(Status.SUCCESS.ToString(), checkoutForm.Status);
            Assert.AreEqual(Locale.TR.ToString(), checkoutForm.Locale);
            Assert.AreEqual("123456789", checkoutForm.ConversationId);
            Assert.IsNotNull(checkoutForm.SystemTime);
            Assert.IsNull(checkoutForm.ErrorCode);
            Assert.IsNull(checkoutForm.ErrorMessage);
            Assert.IsNull(checkoutForm.ErrorGroup);
        }
    }
}
