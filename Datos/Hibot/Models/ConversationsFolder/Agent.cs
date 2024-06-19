using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public partial class Agent
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
