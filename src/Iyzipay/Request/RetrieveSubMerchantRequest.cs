namespace Armut.Iyzipay.Request
{
    public class RetrieveSubMerchantRequest : BaseRequest
    {
        public string SubMerchantExternalId { get; set; }

        public override string ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPKIRequestString())
                .Append("subMerchantExternalId", SubMerchantExternalId)
                .GetRequestString();
        }
    }
}
