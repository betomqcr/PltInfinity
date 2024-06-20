using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Attachaments
{
    public static class Serialize
    {
        public static string ToJson(this Attachament self) => JsonConvert.SerializeObject(self, InfintyHibotPlt.Datos.Infinity.Attachaments.Converter.Settings);
    }
}
