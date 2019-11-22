using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class ApiTestSample : Sample
    {
        [Test]
        public async Task Should_Test_Api()
        {
            IyzipayResource iyzipayResource = await ApiTest.RetrieveAsync(Options);

            PrintResponse(iyzipayResource);

            Assert.AreEqual(Status.SUCCESS.ToString(), iyzipayResource.Status);
            Assert.AreEqual(Locale.TR.ToString(), iyzipayResource.Locale);
            Assert.IsNotNull(iyzipayResource.SystemTime);
            Assert.IsNull(iyzipayResource.ErrorCode);
            Assert.IsNull(iyzipayResource.ErrorMessage);
            Assert.IsNull(iyzipayResource.ErrorGroup);
        }
    }
}
