using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class RefundSample : Sample
    {
        [Test]
        public async Task Should_Refund()
        {
            CreateRefundRequest request = new CreateRefundRequest
            {
                ConversationId = "123456789",
                Locale = Locale.TR.ToString(),
                PaymentTransactionId = "1",
                Price = "0.5",
                Ip = "85.34.78.112",
                Currency = Currency.TRY.ToString()
            };

            Refund refund = await Refund.CreateAsync(request, Options);

            PrintResponse(refund);

            Assert.AreEqual(Status.SUCCESS.ToString(), refund.Status);
            Assert.AreEqual(Locale.TR.ToString(), refund.Locale);
            Assert.AreEqual("123456789", refund.ConversationId);
            Assert.IsNotNull(refund.SystemTime);
            Assert.IsNull(refund.ErrorCode);
            Assert.IsNull(refund.ErrorMessage);
            Assert.IsNull(refund.ErrorGroup);
        }

        [Test]
        public async Task Should_Refund_With_Reason_And_Description()
        {
            CreateRefundRequest request = new CreateRefundRequest
            {
                ConversationId = "123456789",
                Locale = Locale.TR.ToString(),
                PaymentTransactionId = "1",
                Price = "0.5",
                Ip = "85.34.78.112",
                Currency = Currency.TRY.ToString(),
                Reason = RefundReason.OTHER.ToString(),
                Description = "customer requested for default sample"
            };

            Refund refund = await Refund.CreateAsync(request, Options);

            PrintResponse(refund);

            Assert.AreEqual(Status.SUCCESS.ToString(), refund.Status);
            Assert.AreEqual(Locale.TR.ToString(), refund.Locale);
            Assert.AreEqual("123456789", refund.ConversationId);
            Assert.IsNotNull(refund.SystemTime);
            Assert.IsNull(refund.ErrorCode);
            Assert.IsNull(refund.ErrorMessage);
            Assert.IsNull(refund.ErrorGroup);
        }

    }
}
