﻿namespace InfintyHibotPlt.Datos.Models
{
    public class Imagenes
    {
        public long Id { get; set; }
        public DateTimeOffset fecha { get; set; }
        public byte[] Archivo { get; set; }
        public long messagesidMessages { get; set; }
        public Messages messages { get; set; }        
    }
}
