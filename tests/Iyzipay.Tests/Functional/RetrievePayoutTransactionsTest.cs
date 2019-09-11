using System.Threading.Tasks;
using Armut.Iyzipay.Model;
using Armut.Iyzipay.Request;
using NUnit.Framework;

namespace Armut.Iyzipay.Tests.Functional
{
    public class RetrievePayoutTransactionsTest : BaseTest
    {
        [Test]
        public async Task Should_Retrieve_Payout_Completed_Transactions()
        {
            RetrieveTransactionsRequest request = new RetrieveTransactionsRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Date = "2016-01-22 19:13:00"
            };

            PayoutCompletedTransactionList payoutCompletedTransactionList = await PayoutCompletedTransactionList.RetrieveAsync(request, Options);

            PrintResponse(payoutCompletedTransactionList);

            Assert.AreEqual(Status.SUCCESS.ToString(), payoutCompletedTransactionList.Status);
            Assert.AreEqual(Locale.TR.ToString(), payoutCompletedTransactionList.Locale);
            Assert.AreEqual("123456789", payoutCompletedTransactionList.ConversationId);
            Assert.NotNull(payoutCompletedTransactionList.SystemTime);
            Assert.Null(payoutCompletedTransactionList.ErrorCode);
            Assert.Null(payoutCompletedTransactionList.ErrorGroup);
            Assert.Null(payoutCompletedTransactionList.ErrorMessage);
        }

        [Test]
        public async Task Should_Retrieve_Bounced_Bank_Transfers()
        {
            RetrieveTransactionsRequest request = new RetrieveTransactionsRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = "123456789",
                Date = "2016-01-22 19:13:00"
            };

            BouncedBankTransferList bouncedBankTransferList = await BouncedBankTransferList.RetrieveAsync(request, Options);

            PrintResponse(bouncedBankTransferList);

            Assert.AreEqual(Status.SUCCESS.ToString(), bouncedBankTransferList.Status);
            Assert.AreEqual(Locale.TR.ToString(), bouncedBankTransferList.Locale);
            Assert.AreEqual("123456789", bouncedBankTransferList.ConversationId);
            Assert.NotNull(bouncedBankTransferList.SystemTime);
            Assert.Null(bouncedBankTransferList.ErrorCode);
            Assert.Null(bouncedBankTransferList.ErrorGroup);
            Assert.Null(bouncedBankTransferList.ErrorMessage);
        }
    }
}
