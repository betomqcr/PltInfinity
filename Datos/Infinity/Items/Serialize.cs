using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Items
{
    public static class Serialize
    {
        public static string ToJson(this Item self) => JsonConvert.SerializeObject(self, InfintyHibotPlt.Datos.Infinity.Items.Converter.Settings);
    }
}
