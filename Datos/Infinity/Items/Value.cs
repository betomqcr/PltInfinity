using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Items
{
    public partial class Value
    {
        [JsonProperty("attribute_id")]
        public Guid AttributeId { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
