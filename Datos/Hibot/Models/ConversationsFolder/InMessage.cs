using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public partial class InMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        //[JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        [JsonProperty(PropertyName = "created", Required = Required.Default)]
        public DateTimeOffset? Created { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        //[JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        [JsonProperty(PropertyName = "content", Required = Required.Default)]
        public string Content { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        //[JsonProperty("errorDescription", NullValueHandling = NullValueHandling.Ignore)]
        [JsonProperty(PropertyName = "errorDescription", Required = Required.Default)]
        public string? errorDescription { get; set; }

        //[JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        [JsonProperty(PropertyName = "media", Required = Required.Default)]
        public Uri? media { get; set; }

        //[JsonProperty("mediaType", NullValueHandling = NullValueHandling.Ignore)]
        [JsonProperty(PropertyName = "mediaType", Required = Required.Default)]
        public string? mediaType { get; set; }

        //[JsonProperty("createdpub", NullValueHandling = NullValueHandling.Ignore)]
        [JsonProperty(PropertyName = "createdpub", Required = Required.Default)]
        public DateTimeOffset? Createdpub { get; set; }
    }
}
