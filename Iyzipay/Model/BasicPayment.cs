using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class BasicPayment : BasicPaymentResource
    {
        public static BasicPayment Create(CreateBasicPaymentRequest request, Options options)
        {
            return RestHttpClient.Create().Post<BasicPayment>(options.BaseUrl + "/payment/auth/basic", GetHttpHeaders(request, options), request);
        }
    }
}
