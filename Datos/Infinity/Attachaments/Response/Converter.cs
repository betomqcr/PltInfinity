﻿using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;

namespace InfintyHibotPlt.Datos.Infinity.Attachaments.Response
{
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}