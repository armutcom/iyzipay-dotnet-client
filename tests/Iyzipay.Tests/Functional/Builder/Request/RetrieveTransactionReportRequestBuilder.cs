using Armut.Iyzipay.Request.V2;
using System;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public class RetrieveTransactionReportRequestBuilder : BaseRequestBuilderV2<RetrieveTransactionReportRequest>
    {
        public static RetrieveTransactionReportRequestBuilder Create()
        {
            return new RetrieveTransactionReportRequestBuilder();
        }

        public override RetrieveTransactionReportRequest Build()
        {
            return new RetrieveTransactionReportRequest
            {
                ConversationId = "123456789",
                TransactionDate = "2018-09-09",
                Page = 1
            };
        }
    }
}