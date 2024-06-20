using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Infinity.Items.Response
{
        public static class Serialize
        {
            public static string ToJson(this Response self) => JsonConvert.SerializeObject(self, InfintyHibotPlt.Datos.Infinity.Items.Response.Converter.Settings);
        }
    
}
