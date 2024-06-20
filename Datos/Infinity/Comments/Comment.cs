using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Comments
{
    public partial class Comment
    {
        [JsonProperty("text")]
        public string Text { get; set; }
        public static Comment FromJson(string json) => JsonConvert.DeserializeObject<Comment>(json, InfintyHibotPlt.Datos.Infinity.Comments.Converter.Settings);

    }
}
