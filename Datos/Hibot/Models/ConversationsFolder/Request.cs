using InfintyHibotPlt.Datos.Models;
using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public partial class Request
    {
        [JsonProperty("messages")]
        public List<object> Messages { get; set; }

        [JsonProperty("conversations")]
        public List<InConversation> Conversations { get; set; }

        [JsonProperty("acks")]
        public List<object> Acks { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("_IMTMETHOD_")]
        //[JsonProperty(PropertyName = "_IMTMETHOD_", Required = Required.Default)]
        public string _Imtmethod_ { get; set; }

        public static Request FromJson(string json) => JsonConvert.DeserializeObject<Request>(json, InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder.Converter.Settings);
    }
}
