using Armut.Iyzipay.Model;
using Armut.Iyzipay.Model.V2;
using Armut.Iyzipay.Request.V2;
using Armut.Iyzipay.Tests.Functional.Builder.Request;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Armut.Iyzipay.Tests.Functional
{
    public class TransactionReportTest : BaseTest
    {
        [Test]
        public async Task Should_Retrieve_TransactionReport()
        {
            RetrieveTransactionReportRequest request = RetrieveTransactionReportRequestBuilder.Create().Build();

            TransactionReport transactionReport = await TransactionReport.RetrieveAsync(request, Options);

            PrintResponse(transactionReport);

            Assert.AreEqual(Status.SUCCESS.ToString(), transactionReport.Status);
            Assert.AreEqual(200, transactionReport.StatusCode);
            Assert.AreEqual("123", transactionReport.ConversationId);
            Assert.AreEqual(1, transactionReport.CurrentPage);
            Assert.IsNotNull(transactionReport.TotalPageCount);
            Assert.IsNotNull(transactionReport.SystemTime);
            Assert.IsNull(transactionReport.ErrorMessage);
        }
    }
}