using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class PaymentItemTests : BaseTest
    {
        //[Test]
        public async Task Should_Update_Payment_Item()
        {
            CreateSubMerchantRequest createSubMerchantRequest = CreateSubMerchantRequestBuilder.Create()
                .PersonalSubMerchantRequest()
                .Build();

            SubMerchant subMerchant = await SubMerchant.CreateAsync(createSubMerchantRequest, Options);
            string subMerchantKey = subMerchant.SubMerchantKey;

            CreatePaymentRequest request = CreatePaymentRequestBuilder
                .Create()
                .MarketplacePayment(subMerchantKey)
                .Price("1")
                .PaidPrice("1")
                .Build();

            Payment payment = await Payment.CreateAsync(request, Options);

            UpdatePaymentItemRequest updateRequest = new UpdatePaymentItemRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = payment.ConversationId,
                SubMerchantKey = subMerchantKey,
                PaymentTransactionId = payment.PaymentId,
                SubMerchantPrice = "0.4"
            };

            PaymentItem paymentItem = await PaymentItem.UpdateAsync(updateRequest, Options);

            PrintResponse(paymentItem);
        }
    }
}
