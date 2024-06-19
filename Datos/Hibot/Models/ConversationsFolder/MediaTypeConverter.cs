using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    internal class MediaTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(MediaType) || t == typeof(MediaType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "IMAGE":
                    return MediaType.Image;
                case "STICKER":
                    return MediaType.Sticker;
                case "VIDEO":
                    return MediaType.Video;
            }
            throw new Exception("Cannot unmarshal type MediaType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (MediaType)untypedValue;
            switch (value)
            {
                case MediaType.Image:
                    serializer.Serialize(writer, "IMAGE");
                    return;
                case MediaType.Sticker:
                    serializer.Serialize(writer, "STICKER");
                    return;
                case MediaType.Video:
                    serializer.Serialize(writer, "VIDEO");
                    return;
            }
            throw new Exception("Cannot marshal type MediaType");
        }

        public static readonly MediaTypeConverter Singleton = new MediaTypeConverter();
    }
}
