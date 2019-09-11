using Armut.Iyzipay.Model;
using Armut.Iyzipay.Model.V2;
using Armut.Iyzipay.Request.V2;
using NUnit.Framework;

namespace Armut.Iyzipay.Samples
{
    public class RetrieveTransactionDetailSample : Sample
    {
        [Test]
        public void Should_Retrieve_Transaction()
        {
            RetrieveTransactionDetailRequest request = new RetrieveTransactionDetailRequest()
            {
                PaymentConversationId = "payment123456789x"
            };

            TransactionDetail transactionDetail = TransactionDetail.Retrieve(request, Options);

            PrintResponse(transactionDetail);

            Assert.AreEqual(Status.SUCCESS.ToString(), transactionDetail.Status);
            Assert.IsNotNull(transactionDetail.SystemTime);
            Assert.IsNull(transactionDetail.ErrorMessage);
        }
    }
}
