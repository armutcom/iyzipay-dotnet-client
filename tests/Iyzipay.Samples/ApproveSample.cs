using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class ApproveSample : Sample
    {
        [Test]
        public async Task Should_Approve_Payment_Item()
        {
            CreateApprovalRequest request = new CreateApprovalRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                PaymentTransactionId = "1"
            };

            Approval approval = await Approval.CreateAsync(request, Options);

            PrintResponse(approval);

            Assert.AreEqual(Status.SUCCESS.ToString(), approval.Status);
            Assert.AreEqual(Locale.TR.ToString(), approval.Locale);
            Assert.AreEqual("123456789", approval.ConversationId);
            Assert.IsNotNull(approval.SystemTime);
            Assert.IsNull(approval.ErrorCode);
            Assert.IsNull(approval.ErrorMessage);
            Assert.IsNull(approval.ErrorGroup);
        }
    }
}
