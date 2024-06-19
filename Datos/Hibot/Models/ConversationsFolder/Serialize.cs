using Newtonsoft.Json;

namespace InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder
{
    public static class Serialize
    {
        public static string ToJson(this Request self) => JsonConvert.SerializeObject(self, InfintyHibotPlt.Datos.Hibot.Models.ConversationsFolder.Converter.Settings);
    }
}
