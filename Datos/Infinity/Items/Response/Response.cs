using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Items.Response
{
    public partial class Response
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("folder_id")]
        public string FolderId { get; set; }

        [JsonProperty("parent_id")]
        public object ParentId { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("sort_order")]
        public long SortOrder { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        public static Response FromJson(string json) => JsonConvert.DeserializeObject<Response>(json, InfintyHibotPlt.Datos.Infinity.Items.Response.Converter.Settings);

    }
}
