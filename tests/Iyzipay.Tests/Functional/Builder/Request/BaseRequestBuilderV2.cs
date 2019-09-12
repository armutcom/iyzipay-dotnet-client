namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public abstract class BaseRequestBuilderV2<TRequest> where TRequest : BaseRequestV2
    {
        public abstract TRequest Build();
    }
}