using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public partial class ContactFields
    {
        [JsonProperty(PropertyName = "name", Required = Required.Default)]
        public string? Name { get; set; }

        [JsonProperty(PropertyName = "Clinica", Required = Required.Default)]
        public string? Clinica { get; set; }
    }
}
