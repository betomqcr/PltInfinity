namespace InfintyHibotPlt.Datos.Models
{
    public class Conversation
    {
        public string contactName {  get; set; }
        public string contactPhoneWA { get; set; }
        public string idItemInfinity { get; set; }
        public string agente { get; set; }
        public string agenteEmail { get; set; }
        public string estado { get; set; }
        public List<Messages> messages {  get; set; }
        public string typing { get; set; }
    }
}
