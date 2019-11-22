using Armut.Iyzipay.Model;
using Armut.Iyzipay.Model.V2;
using Armut.Iyzipay.Request.V2;
using Armut.Iyzipay.Tests.Functional;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Armut.Iyzipay.Tests
{
    public class TransactionDetailTests: BaseTest
    {
        [Test]
        public async Task Should_Retrieve_TransactionDetail()
        {
            RetrieveTransactionDetailRequest request = RetrieveTransactionDetailRequestBuilder.Create().Build();

            TransactionDetail transactionDetail = await TransactionDetail.RetrieveAsync(request, Options);

            PrintResponse(transactionDetail);

            Assert.AreEqual(Status.SUCCESS.ToString(), transactionDetail.Status);
            Assert.AreEqual(0, transactionDetail.StatusCode);
            Assert.IsNotNull(transactionDetail.Payments);
            Assert.IsNotEmpty(transactionDetail.Payments);
            Assert.IsNull(transactionDetail.ConversationId);
            Assert.IsNotNull(transactionDetail.SystemTime);
            Assert.IsNull(transactionDetail.ErrorMessage);
        }
    }
}
