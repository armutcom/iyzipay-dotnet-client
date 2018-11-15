using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Builder;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using Armut.Iyzipay.Tests.Functional.Util;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class PaymentTest : BaseTest
    {
        [Test]
        public async Task Should_Create_Listing_Payment()
        {
            CreatePaymentRequest request = CreatePaymentRequestBuilder.Create()
                .StandardListingPayment()
                .Build();

            Payment payment = await Payment.CreateAsync(request, Options);

            PrintResponse(payment);

            Assert.Null(payment.ConnectorName);
            Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.NotNull(payment.SystemTime);
            Assert.Null(payment.ErrorCode);
            Assert.Null(payment.ErrorMessage);
            Assert.Null(payment.ErrorGroup);
            Assert.NotNull(payment.PaymentId);
            Assert.NotNull(payment.BasketId);
            Assert.AreEqual("1", payment.Price);
            Assert.AreEqual("1.1", payment.PaidPrice);
            Assert.AreEqual("0.02887500", payment.IyziCommissionRateAmount);
            Assert.AreEqual("0.25000000", payment.IyziCommissionFee);
            Assert.AreEqual("10.00000000", payment.MerchantCommissionRate);
            Assert.AreEqual("0.1", payment.MerchantCommissionRateAmount);
            Assert.AreEqual(0.028875, payment.IyziCommissionRateAmount.ParseDouble());
            Assert.AreEqual(0.25, payment.IyziCommissionFee.ParseDouble());
            Assert.AreEqual(10, payment.MerchantCommissionRate.ParseDouble());
            AssertDecimal.AreEqual(0.02887500M, payment.IyziCommissionRateAmount.ParseDecimal());
            AssertDecimal.AreEqual(0.25000000M, payment.IyziCommissionFee.ParseDecimal());
            AssertDecimal.AreEqual(10.00000000M, payment.MerchantCommissionRate.ParseDecimal());
        }

        [Test]
        public async Task Should_Create_Marketplace_Payment()
        {
            CreateSubMerchantRequest createSubMerchantRequest = CreateSubMerchantRequestBuilder.Create()
                .PersonalSubMerchantRequest()
                .Build();

            SubMerchant subMerchant = await SubMerchant.CreateAsync(createSubMerchantRequest, Options);

            string subMerchantKey = subMerchant.SubMerchantKey;
            CreatePaymentRequest request = CreatePaymentRequestBuilder.Create()
                .MarketplacePayment(subMerchantKey)
                .Build();

            Payment payment = await Payment.CreateAsync(request, Options);

            PrintResponse(payment);

            Assert.Null(payment.ConnectorName);
            Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.NotNull(payment.SystemTime);
            Assert.Null(payment.ErrorCode);
            Assert.Null(payment.ErrorMessage);
            Assert.Null(payment.ErrorGroup);
            Assert.NotNull(payment.PaymentId);
            Assert.NotNull(payment.BasketId);
            Assert.AreEqual("1", payment.Price);
            Assert.AreEqual("1.1", payment.PaidPrice);
            Assert.AreEqual("0.02887500", payment.IyziCommissionRateAmount);
            Assert.AreEqual("0.25000000", payment.IyziCommissionFee);
            Assert.AreEqual("10.00000000", payment.MerchantCommissionRate);
            Assert.AreEqual("0.1", payment.MerchantCommissionRateAmount);
            Assert.AreEqual(0.028875, payment.IyziCommissionRateAmount.ParseDouble());
            Assert.AreEqual(0.25, payment.IyziCommissionFee.ParseDouble());
            Assert.AreEqual(10, payment.MerchantCommissionRate.ParseDouble());
            AssertDecimal.AreEqual(0.02887500M, payment.IyziCommissionRateAmount.ParseDecimal());
            AssertDecimal.AreEqual(0.25000000M, payment.IyziCommissionFee.ParseDecimal());
            AssertDecimal.AreEqual(10.00000000M, payment.MerchantCommissionRate.ParseDecimal());
            Assert.AreEqual(1, payment.Installment);
        }

        //[Test]
        //public async Task Should_Create_Payment_With_Registered_Card()
        //{
        //    string externalUserId = RandomGenerator.RandomId;
        //    CardInformation cardInformation = CardInformationBuilder.Create()
        //        .Build();

        //    CreateCardRequest cardRequest = CreateCardRequestBuilder.Create()
        //        .Card(cardInformation)
        //        .ExternalId(externalUserId)
        //        .Email("email@email.com")
        //        .Build();

        //    Card card = await Card.CreateAsync(cardRequest, Options);

        //    PaymentCard paymentCard = PaymentCardBuilder.Create()
        //        .CardUserKey(card.CardUserKey)
        //        .CardToken(card.CardToken)
        //        .Build();

        //    CreatePaymentRequest request = CreatePaymentRequestBuilder.Create()
        //        .StandardListingPayment()
        //        .PaymentCard(paymentCard)
        //        .Build();

        //    Payment payment = await Payment.CreateAsync(request, Options);

        //    PrintResponse(payment);

        //    Assert.Null(payment.ConnectorName);
        //    Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
        //    Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
        //    Assert.NotNull(payment.SystemTime);
        //    Assert.AreEqual("123456789", payment.ConversationId);
        //    Assert.Null(payment.ErrorCode);
        //    Assert.Null(payment.ErrorMessage);
        //    Assert.Null(payment.ErrorGroup);
        //    Assert.NotNull(payment.PaymentId);
        //    Assert.NotNull(payment.BasketId);
        //    Assert.AreEqual("1", payment.Price);
        //    Assert.AreEqual("1.1", payment.PaidPrice);
        //    Assert.AreEqual("0.02887500", payment.IyziCommissionRateAmount);
        //    Assert.AreEqual("0.25000000", payment.IyziCommissionFee);
        //    Assert.AreEqual("10.00000000", payment.MerchantCommissionRate);
        //    Assert.AreEqual("0.1", payment.MerchantCommissionRateAmount);
        //    Assert.AreEqual(0.028875, payment.IyziCommissionRateAmount.ParseDouble());
        //    Assert.AreEqual(0.25, payment.IyziCommissionFee.ParseDouble());
        //    Assert.AreEqual(10, payment.MerchantCommissionRate.ParseDouble());
        //    AssertDecimal.AreEqual(0.02887500M, payment.IyziCommissionRateAmount.ParseDecimal());
        //    AssertDecimal.AreEqual(0.25000000M, payment.IyziCommissionFee.ParseDecimal());
        //    AssertDecimal.AreEqual(10.00000000M, payment.MerchantCommissionRate.ParseDecimal());
        //    Assert.AreEqual(1, payment.Installment);
        //}

        [Test]
        public async Task Should_Retrieve_Payment()
        {
            CreatePaymentRequest request = CreatePaymentRequestBuilder.Create()
                .StandardListingPayment()
                .Build();

            Payment createdPayment = await Payment.CreateAsync(request, Options);

            PrintResponse(createdPayment);

            RetrievePaymentRequest retrievePaymentRequest = new RetrievePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                PaymentId = createdPayment.PaymentId
            };

            Payment payment = await Payment.RetrieveAsync(retrievePaymentRequest, Options);

            Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.AreEqual(1, payment.Installment);
            Assert.AreEqual("123456789", payment.ConversationId);
            Assert.AreEqual(createdPayment.PaymentId, payment.PaymentId);
            Assert.NotNull(payment.SystemTime);
            Assert.Null(payment.ErrorCode);
            Assert.Null(payment.ErrorMessage);
            Assert.Null(payment.ErrorGroup);
            Assert.NotNull(payment.BasketId);
        }

        [Test]
        public async Task Should_Not_MakePayment_When_Price_And_PaidPrice_Are_Same()
        {
            CreateSubMerchantRequest createSubMerchantRequest = CreateSubMerchantRequestBuilder.Create()
                .PersonalSubMerchantRequest()
                .Build();

            SubMerchant subMerchant = await SubMerchant.CreateAsync(createSubMerchantRequest, Options);

            string subMerchantKey = subMerchant.SubMerchantKey;
            CreatePaymentRequest request = CreatePaymentRequestBuilder.Create()
                .MarketplacePaymentWithSamePrice(subMerchantKey)
                .Build();

            Payment payment = await Payment.CreateAsync(request, Options);

            Assert.AreEqual(Status.FAILURE.ToString(), payment.Status);
            Assert.NotNull(payment.ErrorCode);
            Assert.NotNull(payment.ErrorMessage);
        }
    }
}