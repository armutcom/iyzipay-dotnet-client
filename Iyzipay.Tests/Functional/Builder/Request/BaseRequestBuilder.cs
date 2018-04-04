namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public abstract class BaseRequestBuilder<TRequest> 
        where TRequest : RequestStringConvertible
    {
        protected string Locale { get; set; } = Model.Locale.TR.ToString();
        protected string ConversationId { get; set; } = "123456789";

        public abstract TRequest Build();
    }
}
