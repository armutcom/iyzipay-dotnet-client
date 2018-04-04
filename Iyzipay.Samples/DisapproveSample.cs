using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class DisapproveSample : Sample
    {
        [Test]
        public async Task Should_Disapprove_Payment_Item()
        {
            CreateApprovalRequest request = new CreateApprovalRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                PaymentTransactionId = "1"
            };

            Disapproval disapproval = await Disapproval.CreateAsync(request, Options);

            PrintResponse(disapproval);

            Assert.AreEqual(Status.SUCCESS.ToString(), disapproval.Status);
            Assert.AreEqual(Locale.TR.ToString(), disapproval.Locale);
            Assert.AreEqual("123456789", disapproval.ConversationId);
            Assert.IsNotNull(disapproval.SystemTime);
            Assert.IsNull(disapproval.ErrorCode);
            Assert.IsNull(disapproval.ErrorMessage);
            Assert.IsNull(disapproval.ErrorGroup);
        }
    }
}
