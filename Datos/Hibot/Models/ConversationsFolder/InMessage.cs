using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public partial class InMessage
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Created { get; set; }

        [JsonProperty("sender")]
        public string Sender { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("from")]
        public From From { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }

        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("errorDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorDescription { get; set; }

        [JsonProperty("media", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Media { get; set; }

        [JsonProperty("mediaType", NullValueHandling = NullValueHandling.Ignore)]
        public MediaType? MediaType { get; set; }

        [JsonProperty("createdpub", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Createdpub { get; set; }
    }
}
