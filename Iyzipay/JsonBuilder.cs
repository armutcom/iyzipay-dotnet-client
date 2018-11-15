using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Armut.Iyzipay
{
    public class JsonBuilder
    {
        public static string SerializeToJsonString(BaseRequest request)
        {
            return JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static string SerializeToJsonString(BaseRequestV2 request)
        {
            return JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static StringContent ToJsonString(BaseRequest request)
        {
            return new StringContent(SerializeToJsonString(request), Encoding.Unicode, "application/json");
        }

        public static StringContent ToJsonString(BaseRequestV2 request)
        {
            return new StringContent(SerializeToJsonString(request), Encoding.Unicode, "application/json");
        }
    }
}
