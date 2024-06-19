using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    internal class StatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Status) || t == typeof(Status?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "DELIVERED":
                    return Status.Delivered;
                case "PENDING":
                    return Status.Pending;
                case "SENT":
                    return Status.Sent;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Status)untypedValue;
            switch (value)
            {
                case Status.Delivered:
                    serializer.Serialize(writer, "DELIVERED");
                    return;
                case Status.Pending:
                    serializer.Serialize(writer, "PENDING");
                    return;
                case Status.Sent:
                    serializer.Serialize(writer, "SENT");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly StatusConverter Singleton = new StatusConverter();
    }
}
