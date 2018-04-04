using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class DisapproveTest : BaseTest
    {
        [Test]
        public async Task Should_Disapprove_Payment()
        {
            CreateSubMerchantRequest request = CreateSubMerchantRequestBuilder.Create()
                .PersonalSubMerchantRequest()
                .Build();

            SubMerchant subMerchant = await SubMerchant.CreateAsync(request, Options);

            CreatePaymentRequest paymentRequest = CreatePaymentRequestBuilder.Create()
                .MarketplacePayment(subMerchant.SubMerchantKey)
                .Build();

            Payment payment = await Payment.CreateAsync(paymentRequest, Options);

            string paymentTransactionId = payment.PaymentItems[0].PaymentTransactionId;

            CreateApprovalRequest approvalRequest = CreateApprovalRequestBuilder.Create()
                .PaymentTransactionId(paymentTransactionId)
                .Build();

            await Approval.CreateAsync(approvalRequest, Options);

            Disapproval disapproval = await Disapproval.CreateAsync(approvalRequest, Options);

            PrintResponse(disapproval);

            Assert.AreEqual(paymentTransactionId, disapproval.PaymentTransactionId);
            Assert.AreEqual(Status.SUCCESS.ToString(), disapproval.Status);
            Assert.AreEqual(Locale.TR.ToString(), disapproval.Locale);
            Assert.NotNull(disapproval.SystemTime);
            Assert.Null(disapproval.ErrorCode);
            Assert.Null(disapproval.ErrorMessage);
            Assert.Null(disapproval.ErrorGroup);
        }
    }
}
