using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Attachaments.Response
{
    public partial class ResponseAttach
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }

        [JsonProperty("original_name")]
        public string OriginalName { get; set; }

        [JsonProperty("filesize")]
        public long Filesize { get; set; }

        [JsonProperty("thumb")]
        public object Thumb { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("team_id")]
        public long TeamId { get; set; }

        [JsonProperty("deleted_at")]
        public object DeletedAt { get; set; }

        [JsonProperty("checked_at")]
        public object CheckedAt { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }

        [JsonProperty("basename")]
        public string Basename { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        public static ResponseAttach FromJson(string json) => JsonConvert.DeserializeObject<ResponseAttach>(json, InfintyHibotPlt.Datos.Infinity.Attachaments.Response.Converter.Settings);

    }
}
