using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class InstallmentSample : Sample
    {
        [Test]
        public async Task Should_Retrieve_Installments()
        {
            RetrieveInstallmentInfoRequest request = new RetrieveInstallmentInfoRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                BinNumber = "554960",
                Price = "100"
            };

            InstallmentInfo installmentInfo = await InstallmentInfo.RetrieveAsync(request, Options);

            PrintResponse(installmentInfo);

            Assert.AreEqual(Status.SUCCESS.ToString(), installmentInfo.Status);
            Assert.AreEqual(Locale.TR.ToString(), installmentInfo.Locale);
            Assert.AreEqual("123456789", installmentInfo.ConversationId);
            Assert.IsNotNull(installmentInfo.SystemTime);
            Assert.IsNull(installmentInfo.ErrorCode);
            Assert.IsNull(installmentInfo.ErrorMessage);
            Assert.IsNull(installmentInfo.ErrorGroup);
            Assert.IsNotNull(installmentInfo.InstallmentDetails);
            Assert.IsNotEmpty(installmentInfo.InstallmentDetails);
        }
    }
}
