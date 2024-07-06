using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public partial class ContactFields
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("Clinica", NullValueHandling = NullValueHandling.Ignore)]
        public string Clinica { get; set; }
    }
}
