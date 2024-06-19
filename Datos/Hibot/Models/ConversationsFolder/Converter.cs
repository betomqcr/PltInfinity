using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                FromConverter.Singleton,
                MediaTypeConverter.Singleton,
                StatusConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

    }
}
