using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class ApiTest : BaseTest
    {
        [Test]
        public async Task Should_Test_Api()
        {
            IyzipayResource iyzipayResource = await Model.ApiTest.RetrieveAsync(Options);

            PrintResponse(iyzipayResource);

            Assert.AreEqual(Status.SUCCESS.ToString(), iyzipayResource.Status);
            Assert.AreEqual(Locale.TR.ToString(), iyzipayResource.Locale);
            Assert.NotNull(iyzipayResource.SystemTime);
            Assert.Null(iyzipayResource.ErrorCode);
            Assert.Null(iyzipayResource.ErrorMessage);
            Assert.Null(iyzipayResource.ErrorGroup);
        }
    }
}
