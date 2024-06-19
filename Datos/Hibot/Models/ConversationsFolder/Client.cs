using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public partial class Client
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slaOptimo")]
        public long SlaOptimo { get; set; }

        [JsonProperty("slaBajo")]
        public long SlaBajo { get; set; }
    }
}
