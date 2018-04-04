using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public sealed class RetrieveBinNumberRequestBuilder : BaseRequestBuilder<RetrieveBinNumberRequest>
    {
        private string _binNumber;

        private RetrieveBinNumberRequestBuilder()
        {
        }

        public static RetrieveBinNumberRequestBuilder Create()
        {
            return new RetrieveBinNumberRequestBuilder();
        }

        public RetrieveBinNumberRequestBuilder BinNumber(string binNumber)
        {
            _binNumber = binNumber;
            return this;
        }

        public override RetrieveBinNumberRequest Build()
        {
            RetrieveBinNumberRequest retrieveBinNumberRequest = new RetrieveBinNumberRequest
            {
                Locale = Locale,
                ConversationId = ConversationId,
                BinNumber = _binNumber
            };
            return retrieveBinNumberRequest;
        }
    }
}
