﻿namespace InfintyHibotPlt.Datos.Models
{
    public class Conversation
    {
        public long idConversation { get; set; }
        public string contactName {  get; set; }
        public string contactPhoneWA { get; set; }
        public string idItemInfinity { get; set; }
        public string agente { get; set; }
        public string agenteEmail { get; set; }
        public string estado { get; set; }
        public string typing { get; set; }        
        public string idHibotConversation {  get; set; }
        public string clinica { get; set; }
        public DateTimeOffset closed { get; set; }
        public DateTimeOffset create { get; set; }
        public DateTimeOffset assigend { get; set; }
        public List<Messages> messages { get; set; }
    }
}
