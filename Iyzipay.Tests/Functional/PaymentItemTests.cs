using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Builder;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class PaymentItemTests : BaseTest
    {
        [Test]
        public async Task Should_Update_Payment_Item()
        {
            CreateSubMerchantRequest createSubMerchantRequest = CreateSubMerchantRequestBuilder.Create()
                .PersonalSubMerchantRequest()
                .Build();

            SubMerchant subMerchant = await SubMerchant.CreateAsync(createSubMerchantRequest, Options);
            string subMerchantKey = subMerchant.SubMerchantKey;

            CreatePaymentRequest request = CreatePaymentRequestBuilder
                .Create()
                .MarketplacePayment(subMerchantKey, "0.4", "0.3")
                .Price("0.4")
                .PaidPrice("0.4")
                .Build();

            Payment payment = await Payment.CreateAsync(request, Options);

            UpdatePaymentItemRequest updateRequest = new UpdatePaymentItemRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = payment.ConversationId,
                SubMerchantKey = subMerchantKey,
                PaymentTransactionId = payment.PaymentItems?[0]?.PaymentTransactionId,
                SubMerchantPrice = "0.23"
            };

            PaymentItem paymentItem = await PaymentItem.UpdateAsync(updateRequest, Options);

            PrintResponse(paymentItem);

            Assert.NotNull(paymentItem);
            Assert.NotNull(paymentItem.Locale);
            Assert.NotNull(paymentItem.ConversationId);
            Assert.NotNull(paymentItem.SubMerchantKey);
            Assert.NotNull(paymentItem.PaymentTransactionId);
            Assert.NotNull(paymentItem.SubMerchantPrice);
            Assert.AreEqual(Status.SUCCESS.ToString(), paymentItem.Status);
            Assert.AreEqual(Locale.TR.ToString(), paymentItem.Locale);
            Assert.AreEqual(updateRequest.ConversationId, paymentItem.ConversationId);
            Assert.AreEqual(updateRequest.SubMerchantKey, paymentItem.SubMerchantKey);
            Assert.AreEqual(updateRequest.PaymentTransactionId, paymentItem.PaymentTransactionId);
            Assert.AreEqual(updateRequest.SubMerchantPrice, paymentItem.SubMerchantPrice);
        }

        [Test]
        public async Task Should_Update_Payment_Item_When_Price_Does_Not_Have_Dot()
        {
            CreateSubMerchantRequest createSubMerchantRequest = CreateSubMerchantRequestBuilder.Create()
                .PersonalSubMerchantRequest()
                .Build();

            SubMerchant subMerchant = await SubMerchant.CreateAsync(createSubMerchantRequest, Options);
            string subMerchantKey = subMerchant.SubMerchantKey;
            
            CreatePaymentRequest request = CreatePaymentRequestBuilder
                .Create()
                .MarketplacePayment(subMerchantKey, "40", "30")
                .Price("40")
                .PaidPrice("40")
                .Build();

            Payment payment = await Payment.CreateAsync(request, Options);

            UpdatePaymentItemRequest updateRequest = new UpdatePaymentItemRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = payment.ConversationId,
                SubMerchantKey = subMerchantKey,
                PaymentTransactionId = payment.PaymentItems?[0]?.PaymentTransactionId,
                SubMerchantPrice = "25"
            };

            PaymentItem paymentItem = await PaymentItem.UpdateAsync(updateRequest, Options);

            PrintResponse(paymentItem);

            Assert.NotNull(paymentItem);
            Assert.NotNull(paymentItem.Locale);
            Assert.NotNull(paymentItem.ConversationId);
            Assert.NotNull(paymentItem.SubMerchantKey);
            Assert.NotNull(paymentItem.PaymentTransactionId);
            Assert.NotNull(paymentItem.SubMerchantPrice);
            Assert.AreEqual(Status.SUCCESS.ToString(), paymentItem.Status);
            Assert.AreEqual(Locale.TR.ToString(), paymentItem.Locale);
            Assert.AreEqual(updateRequest.ConversationId, paymentItem.ConversationId);
            Assert.AreEqual(updateRequest.SubMerchantKey, paymentItem.SubMerchantKey);
            Assert.AreEqual(updateRequest.PaymentTransactionId, paymentItem.PaymentTransactionId);
            Assert.AreEqual(updateRequest.SubMerchantPrice, paymentItem.SubMerchantPrice);
        }

        [Test]
        public async Task Should_Not_Update_Payment_Item_When_TransactionId_Is_Wrong()
        {
            CreateSubMerchantRequest createSubMerchantRequest = CreateSubMerchantRequestBuilder.Create()
                .PersonalSubMerchantRequest()
                .Build();

            SubMerchant subMerchant = await SubMerchant.CreateAsync(createSubMerchantRequest, Options);
            string subMerchantKey = subMerchant.SubMerchantKey;
            
            CreatePaymentRequest request = CreatePaymentRequestBuilder
                .Create()
                .MarketplacePayment(subMerchantKey, "40", "30")
                .Price("40")
                .PaidPrice("40")
                .Build();

            Payment payment = await Payment.CreateAsync(request, Options);

            UpdatePaymentItemRequest updateRequest = new UpdatePaymentItemRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = payment.ConversationId,
                SubMerchantKey = subMerchantKey,
                PaymentTransactionId = "1",
                SubMerchantPrice = "25"
            };

            PaymentItem paymentItem = await PaymentItem.UpdateAsync(updateRequest, Options);

            PrintResponse(paymentItem);

            Assert.NotNull(paymentItem);
            Assert.AreEqual(Status.FAILURE.ToString(), paymentItem.Status);
        }
    }
}
