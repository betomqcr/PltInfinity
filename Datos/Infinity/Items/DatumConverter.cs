using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Items
{
    internal class DatumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Datum) || t == typeof(Datum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new Datum { Integer = l };
                    }
                    Guid guid;
                    if (Guid.TryParse(stringValue, out guid))
                    {
                        return new Datum { Uuid = guid };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type Datum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Datum)untypedValue;
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            if (value.Uuid != null)
            {
                serializer.Serialize(writer, value.Uuid.Value.ToString("D", System.Globalization.CultureInfo.InvariantCulture));
                return;
            }
            throw new Exception("Cannot marshal type Datum");
        }

        public static readonly DatumConverter Singleton = new DatumConverter();
    }

}
