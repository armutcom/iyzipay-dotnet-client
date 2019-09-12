using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class PaymentItemSample : Sample
    {
        [Test]
        public async Task Should_Update_Payment_Item()
        {
            UpdatePaymentItemRequest request = new UpdatePaymentItemRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                SubMerchantKey = "subMerchantKey",
                PaymentTransactionId = "transactionId",
                SubMerchantPrice = "price"
            };

            PaymentItem paymentItem = await PaymentItem.UpdateAsync(request, Options);

            PrintResponse(paymentItem);

            Assert.AreEqual(Status.SUCCESS.ToString(), paymentItem.Status);
            Assert.AreEqual(Locale.TR.ToString(), paymentItem.Locale);
            Assert.AreEqual("123456789", paymentItem.ConversationId);
            Assert.IsNotNull(paymentItem.SystemTime);
            Assert.IsNull(paymentItem.ErrorCode);
            Assert.IsNull(paymentItem.ErrorMessage);
            Assert.IsNull(paymentItem.ErrorGroup);
        }
    }
}
