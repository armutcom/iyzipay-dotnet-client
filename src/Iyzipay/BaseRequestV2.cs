using Newtonsoft.Json;

namespace Armut.Iyzipay
{
    public class BaseRequestV2
    {
        [JsonIgnore]
        public string ConversationId { get; set; }
    }
}