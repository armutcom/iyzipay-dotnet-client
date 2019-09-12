using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class BkmTest : BaseTest
    {
        [Test]
        public async Task Should_Initialize_Bkm()
        {
            CreateBkmInitializeRequest request = CreateBkmInitializeRequestBuilder.Create()
                .Price("1")
                .CallbackUrl("https://www.merchant.com/callback")
                .Build();

            BkmInitialize bkmInitialize = await BkmInitialize.CreateAsync(request, Options);

            PrintResponse(request);

            Assert.NotNull(bkmInitialize.HtmlContent);
            Assert.NotNull(bkmInitialize.Token);
            Assert.True(bkmInitialize.HtmlContent.Contains(bkmInitialize.Token));
        }
    }
}
