namespace InfintyHibotPlt.Datos.Models
{
    public class Entrada
    {
        public long idEntrada {  get; set; }
        public string idChat {  get; set; }
        public string JsonEntrada { get; set; }
        public DateTimeOffset fechaEntrada { get; set; }
    }
}
