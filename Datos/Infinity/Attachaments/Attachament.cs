using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Attachaments
{
    public partial class Attachament
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        public static Attachament FromJson(string json) => JsonConvert.DeserializeObject<Attachament>(json, InfintyHibotPlt.Datos.Infinity.Attachaments.Converter.Settings);

    }
}
