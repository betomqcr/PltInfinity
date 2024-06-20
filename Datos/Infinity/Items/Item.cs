using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Items
{
    public partial class Item
    {
        [JsonProperty("folder_id")]
        public string FolderId { get; set; }

        [JsonProperty("values")]
        public List<Value> Values { get; set; }

        public static Item FromJson(string json) => JsonConvert.DeserializeObject<Item>(json, InfintyHibotPlt.Datos.Infinity.Items.Converter.Settings);

    }
}
