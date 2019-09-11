namespace Armut.Iyzipay.Request
{
    public class RetrieveInstallmentInfoRequest : BaseRequest
    {
        public string BinNumber { get; set; }
        public string Price { get; set; }

        public override string ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPKIRequestString())
                .Append("binNumber", BinNumber)
                .AppendPrice("price", Price)
                .GetRequestString();
        }
    }
}
