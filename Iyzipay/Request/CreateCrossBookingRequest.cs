namespace Armut.Iyzipay.Request
{
    public class CreateCrossBookingRequest : BaseRequest
    {
        public string SubMerchantKey { get; set; }
        public string Price { get; set; }
        public string Reason { get; set; }
        public string Currency { get; set; }

        public override string ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPKIRequestString())
                .Append("subMerchantKey", SubMerchantKey)
                .AppendPrice("price", Price)
                .Append("reason", Reason)
                .Append("currency", Currency)
                .GetRequestString();
        }
    }
}
