using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class PeccoTest : BaseTest
    {
        [Test]
        public async Task Should_Initialize_Pecco()
        {
            CreatePeccoInitializeRequest request = CreatePeccoInitializeRequestBuilder.Create()
                .CallbackUrl("https://www.merchant.com/callback")
                .PaymentGroup(PaymentGroup.LISTING.ToString())
                .Price("1")
                .PaidPrice("10")
                .Build();

            PeccoInitialize peccoInitialize = await PeccoInitialize.CreateAsync(request, Options);

            PrintResponse(peccoInitialize);

            Assert.AreEqual(Locale.TR.ToString(), peccoInitialize.Locale);
            Assert.AreEqual(Status.SUCCESS.ToString(), peccoInitialize.Status);
            Assert.NotNull(peccoInitialize.SystemTime);
            Assert.NotNull(peccoInitialize.HtmlContent);
            Assert.Null(peccoInitialize.ErrorCode);
            Assert.Null(peccoInitialize.ErrorMessage);
            Assert.Null(peccoInitialize.ErrorGroup);
        }

        /*
            This test needs manual payment from Pecco on sandbox environment. So it does not contain any assertions.
        */
        [Test]
        public async Task Should_Create_Pecco_Payment()
        {
            CreatePeccoInitializeRequest request = CreatePeccoInitializeRequestBuilder.Create()
                .CallbackUrl("https://www.merchant.com/callback")
                .PaymentGroup(PaymentGroup.LISTING.ToString())
                .Price("1")
                .PaidPrice("10")
                .Build();

            var peccoInitialize = await PeccoInitialize.CreateAsync(request, Options);

            string token = peccoInitialize.Token;

            CreatePeccoPaymentRequest peccoPaymentRequest = CreatePeccoPaymentRequestBuilder.Create()
                .Token(token)
                .Build();

            PeccoPayment peccoPayment = PeccoPayment.Create(peccoPaymentRequest, Options);

            PrintResponse(peccoPayment);
        }
    }
}
