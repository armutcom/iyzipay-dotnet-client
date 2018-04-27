using System.Collections.Generic;
using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class InstallmentInfo : IyzipayResource
    {
        private const string InstallmentInfoUrl = "/payment/iyzipos/installment";

        public List<InstallmentDetail> InstallmentDetails { get; set; }

        public static InstallmentInfo Retrieve(RetrieveInstallmentInfoRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<InstallmentInfo>(options.BaseUrl + InstallmentInfoUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<InstallmentInfo> RetrieveAsync(RetrieveInstallmentInfoRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<InstallmentInfo>(options.BaseUrl + InstallmentInfoUrl, GetHttpHeaders(request, options), request);
        }
    }
}
