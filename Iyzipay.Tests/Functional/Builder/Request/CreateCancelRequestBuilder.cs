using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Tests.Functional.Builder.Request
{
    public sealed class CreateCancelRequestBuilder : BaseRequestBuilder<CreateCancelRequest>
    {
        private string _paymentId;
        private string _ip = "85.34.78.112";

        private CreateCancelRequestBuilder()
        {
        }

        public static CreateCancelRequestBuilder Create()
        {
            return new CreateCancelRequestBuilder();
        }

        public CreateCancelRequestBuilder PaymentId(string paymentId)
        {
            _paymentId = paymentId;
            return this;
        }

        public CreateCancelRequestBuilder Ip(string ip)
        {
            _ip = ip;
            return this;
        }

        public override CreateCancelRequest Build()
        {
            CreateCancelRequest cancelRequest = new CreateCancelRequest
            {
                PaymentId = _paymentId,
                Ip = _ip
            };
            return cancelRequest;
        }
    }
}
