using Armut.Iyzipay.Model;
using Armut.Iyzipay.Model.V2;
using Armut.Iyzipay.Request.V2;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class TransactionReportSample : Sample
    {
        [Test]
        public void Should_Retrieve_TransactionReport()
        {
            RetrieveTransactionReportRequest request = new RetrieveTransactionReportRequest
            {
                ConversationId = "123",
                TransactionDate = "2018-06-28",
                Page = 1
            };

            TransactionReport transactionReport = TransactionReport.Retrieve(request, Options);

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