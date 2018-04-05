using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using Armut.Iyzipay.Tests.Functional.Util;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class CancelTest : BaseTest
    {
        [Test]
        public async Task Should_Cancel_Payment()
        {
            CreatePaymentRequest paymentRequest = CreatePaymentRequestBuilder.Create()
                .StandardListingPayment()
                .Build();

            Payment payment = await Payment.CreateAsync(paymentRequest, Options);

            CreateCancelRequest cancelRequest = CreateCancelRequestBuilder.Create()
                .PaymentId(payment.PaymentId)
                .Build();

            Cancel cancel = await Cancel.CreateAsync(cancelRequest, Options);

            PrintResponse(cancel);

            Assert.AreEqual(Locale.TR.ToString(), cancel.Locale);
            Assert.AreEqual(Status.SUCCESS.ToString(), cancel.Status);
            Assert.AreEqual(payment.PaymentId, cancel.PaymentId);
            Assert.AreEqual("1.10000000", cancel.Price);
            Assert.AreEqual(1.1, cancel.Price.ParseDouble());
            AssertDecimal.AreEqual(1.10000000M , cancel.Price.ParseDecimal());
            Assert.AreEqual(Currency.TRY.ToString(), cancel.Currency);
            Assert.NotNull(cancel.SystemTime);
            Assert.Null(cancel.ErrorCode);
            Assert.Null(cancel.ErrorMessage);
            Assert.Null(cancel.ErrorGroup);
        }

        [Test]
        public async Task Should_Cancel_Fraudulent_Payment()
        {
            CreatePaymentRequest paymentRequest = CreatePaymentRequestBuilder.Create()
                .StandardListingPayment()
                .Build();

            Payment payment = await Payment.CreateAsync(paymentRequest, Options);

            CreateCancelRequest cancelRequest = CreateCancelRequestBuilder.Create()
                .PaymentId(payment.PaymentId)
                .Build();

            cancelRequest.Reason = RefundReason.FRAUD.ToString();
            cancelRequest.Description = "stolen card request with 11000 try payment for default sample";

            Cancel cancel = await Cancel.CreateAsync(cancelRequest, Options);

            PrintResponse(cancel);

            Assert.AreEqual(Locale.TR.ToString(), cancel.Locale);
            Assert.AreEqual(Status.SUCCESS.ToString(), cancel.Status);
            Assert.AreEqual(payment.PaymentId, cancel.PaymentId);
            Assert.AreEqual("1.10000000", cancel.Price);
            Assert.AreEqual(1.1, cancel.Price.ParseDouble());
            AssertDecimal.AreEqual(1.10000000M, cancel.Price.ParseDecimal());
            Assert.AreEqual(Currency.TRY.ToString(), cancel.Currency);
            Assert.NotNull(cancel.SystemTime);
            Assert.Null(cancel.ErrorCode);
            Assert.Null(cancel.ErrorMessage);
            Assert.Null(cancel.ErrorGroup);
        }
    }
}
