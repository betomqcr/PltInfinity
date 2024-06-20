using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Attachaments.Response
{
    public static class Serialize
    {
        public static string ToJson(this ResponseAttach self) => JsonConvert.SerializeObject(self, InfintyHibotPlt.Datos.Infinity.Attachaments.Response.Converter.Settings);

    }
}
