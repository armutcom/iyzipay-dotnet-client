using Newtonsoft.Json;

namespace Armut.Iyzipay.Model
{
    public class BankTransfer
    {
        public string SubMerchantKey { get; set; }
        public string Iban { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string LegalCompanyTitle { get; set; }
        [JsonProperty(PropertyName= "marketplaceSubmerchantType")]
        public string MarketplaceSubMerchantType { get; set; }
    }
}
