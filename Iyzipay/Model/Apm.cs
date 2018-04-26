using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class Apm : ApmResource
    {
        private const string ApmCreateUrl = "/payment/apm/initialize";
        private const string ApmRetrieveUrl = "/payment/apm/retrieve";

        public static Apm Create(CreateApmInitializeRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<Apm>(options.BaseUrl + ApmCreateUrl, GetHttpHeaders(request, options), request);
        }

        public static Apm Retrieve(RetrieveApmRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<Apm>(options.BaseUrl + ApmRetrieveUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Apm> CreateAsync(CreateApmInitializeRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<Apm>(options.BaseUrl + ApmCreateUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<Apm> RetrieveAsync(RetrieveApmRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<Apm>(options.BaseUrl + ApmRetrieveUrl, GetHttpHeaders(request, options), request);
        }
    }
}
