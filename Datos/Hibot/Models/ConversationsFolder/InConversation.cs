using Newtonsoft.Json;
using System.Threading.Channels;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public partial class InConversation
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("created")]
        public DateTimeOffset Created { get; set; }

        [JsonProperty("assigned")]
        public DateTimeOffset Assigned { get; set; }

        [JsonProperty("closed")]
        public DateTimeOffset Closed { get; set; }

        [JsonProperty("typing")]
        public string Typing { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("fields")]
        public ConversationFields Fields { get; set; }

        [JsonProperty("contacts")]
        public List<Contact> Contacts { get; set; }

        [JsonProperty("messages")]
        public List<InMessage> Messages { get; set; }

        [JsonProperty("agent")]
        public Agent Agent { get; set; }

        [JsonProperty("client")]
        public Client Client { get; set; }

        [JsonProperty("project")]
        public Campaign Project { get; set; }

        [JsonProperty("campaign")]
        public Campaign Campaign { get; set; }

        [JsonProperty("channel")]
        public Channel Channel { get; set; }

        [JsonProperty("asa")]
        public float Asa { get; set; }

        [JsonProperty("creationAsa")]
        public float CreationAsa { get; set; }

        [JsonProperty("assignmentType")]
        public string AssignmentType { get; set; }
    }
}
