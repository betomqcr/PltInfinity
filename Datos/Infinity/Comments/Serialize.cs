using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Comments
{
    public static class Serialize
    {
        public static string ToJson(this Comment self) => JsonConvert.SerializeObject(self, InfintyHibotPlt.Datos.Infinity.Comments.Converter.Settings);
    }
}
