namespace Armut.Iyzipay.Request
{
    public class RetrieveTransactionsRequest: BaseRequest
    {
        public string Date { get; set; }

        public override string ToPKIRequestString()
        {
            return ToStringRequestBuilder.NewInstance()
                .AppendSuper(base.ToPKIRequestString())
                .Append("date", Date)
                .GetRequestString();
        }
    }
}
