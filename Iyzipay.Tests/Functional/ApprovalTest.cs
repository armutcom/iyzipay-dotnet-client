using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class ApprovalTest : BaseTest
    {
        [Test]
        public async Task Should_Approve_Payment_Item()
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

            Approval approval = await Approval.CreateAsync(approvalRequest, Options);

            Assert.AreEqual(paymentTransactionId, approval.PaymentTransactionId);
            Assert.AreEqual(Locale.TR.ToString(), payment.Locale);
            Assert.AreEqual(Status.SUCCESS.ToString(), payment.Status);
            Assert.NotNull(payment.SystemTime);
            Assert.Null(payment.ErrorCode);
            Assert.Null(payment.ErrorMessage);
            Assert.Null(payment.ErrorGroup);
        }
    }
}
