using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Items
{
    internal class DataConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Data) || t == typeof(Data?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    return new Data { String = stringValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<Guid>>(reader);
                    return new Data { UuidArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Data");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Data)untypedValue;
            if (value.String != null)
            {
                serializer.Serialize(writer, value.String);
                return;
            }
            if (value.UuidArray != null)
            {
                serializer.Serialize(writer, value.UuidArray);
                return;
            }
            throw new Exception("Cannot marshal type Data");
        }

        public static readonly DataConverter Singleton = new DataConverter();
    }
}
