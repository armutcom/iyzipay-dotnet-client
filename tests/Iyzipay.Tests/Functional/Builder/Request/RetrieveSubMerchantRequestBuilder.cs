using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public sealed class RetrieveSubMerchantRequestBuilder : BaseRequestBuilder<RetrieveSubMerchantRequest>
    {
        private string _subMerchantExternalId;

        private RetrieveSubMerchantRequestBuilder()
        {
        }

        public static RetrieveSubMerchantRequestBuilder Create()
        {
            return new RetrieveSubMerchantRequestBuilder();
        }

        public RetrieveSubMerchantRequestBuilder SubMerchantExternalId(string subMerchantExternalId)
        {
            _subMerchantExternalId = subMerchantExternalId;
            return this;
        }

        public override RetrieveSubMerchantRequest Build()
        {
            RetrieveSubMerchantRequest retrieveSubMerchantRequest = new RetrieveSubMerchantRequest
            {
                Locale = Locale,
                ConversationId = ConversationId,
                SubMerchantExternalId = _subMerchantExternalId
            };
            return retrieveSubMerchantRequest;
        }
    }
}
