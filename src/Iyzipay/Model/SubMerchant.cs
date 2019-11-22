using System.Threading.Tasks;
using Armut.Iyzipay.Request;

namespace Armut.Iyzipay.Model
{
    public class SubMerchant : IyzipayResource
    {
        private const string SubMerchantUrl = "/onboarding/submerchant";
        private const string SubMerchantRetrieveUrl = "/onboarding/submerchant/detail";

        public string Name { get; set; }
        public string Email { get; set; }
        public string GsmNumber { get; set; }
        public string Address { get; set; }
        public string Iban { get; set; }
        public string SwiftCode { get; set; }
        public string Currency { get; set; }
        public string TaxOffice { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string LegalCompanyTitle { get; set; }
        public string SubMerchantExternalId { get; set; }
        public string IdentityNumber { get; set; }
        public string TaxNumber { get; set; }
        public string SubMerchantType { get; set; }
        public string SubMerchantKey { get; set; }
        public string SettlementDescriptionTemplate { get; set; }

        public static SubMerchant Create(CreateSubMerchantRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<SubMerchant>(options.BaseUrl + SubMerchantUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<SubMerchant> CreateAsync(CreateSubMerchantRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<SubMerchant>(options.BaseUrl + SubMerchantUrl, GetHttpHeaders(request, options), request);
        }

        public static SubMerchant Update(UpdateSubMerchantRequest request, Options options)
        {
            return RestHttpClient.Instance.Put<SubMerchant>(options.BaseUrl + SubMerchantUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<SubMerchant> UpdateAsync(UpdateSubMerchantRequest request, Options options)
        {
            return await RestHttpClient.Instance.PutAsync<SubMerchant>(options.BaseUrl + SubMerchantUrl, GetHttpHeaders(request, options), request);
        }

        public static SubMerchant Retrieve(RetrieveSubMerchantRequest request, Options options)
        {
            return RestHttpClient.Instance.Post<SubMerchant>(options.BaseUrl + SubMerchantRetrieveUrl, GetHttpHeaders(request, options), request);
        }

        public static async Task<SubMerchant> RetrieveAsync(RetrieveSubMerchantRequest request, Options options)
        {
            return await RestHttpClient.Instance.PostAsync<SubMerchant>(options.BaseUrl + SubMerchantRetrieveUrl, GetHttpHeaders(request, options), request);
        }
    }
}
