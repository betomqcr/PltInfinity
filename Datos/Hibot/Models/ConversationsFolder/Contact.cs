using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public partial class Contact
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("account")]
        public string Account { get; set; }

        [JsonProperty("fields")]
        public ContactFields Fields { get; set; }

        [JsonProperty("tags")]
        public List<object> Tags { get; set; }
    }
}
