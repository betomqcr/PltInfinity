using System.Buffers.Text;

namespace InfintyHibotPlt.Datos.Models
{
    public class Messages
    {
        public long idMessages {  get; set; }
        public string content { get; set; }
        public string personContent { get; set; }
        public DateTime created { get; set; }
        public string idHibotMessages { get; set; }
        public string media { get; set; }
        public string mediaType { get; set; }

    }
}
