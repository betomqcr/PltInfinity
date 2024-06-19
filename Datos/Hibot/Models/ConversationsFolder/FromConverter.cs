using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    internal class FromConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(From) || t == typeof(From?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "AGENT":
                    return From.Agent;
                case "BOT":
                    return From.Bot;
                case "CONTACT":
                    return From.Contact;
            }
            throw new Exception("Cannot unmarshal type From");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (From)untypedValue;
            switch (value)
            {
                case From.Agent:
                    serializer.Serialize(writer, "AGENT");
                    return;
                case From.Bot:
                    serializer.Serialize(writer, "BOT");
                    return;
                case From.Contact:
                    serializer.Serialize(writer, "CONTACT");
                    return;
            }
            throw new Exception("Cannot marshal type From");
        }

        public static readonly FromConverter Singleton = new FromConverter();
    }
}
