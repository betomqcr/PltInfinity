using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InfintyHibotPlt.Datos.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Aqui empieza el armado de la tabla de Conversacion 

            

            //Aqui empieza el armado de los mensajes de la conversacion

            
            

            //Aqui empieza el armado de la bitacora

            


        }

        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Bitacora> Bitacora { get; set; }
    }
}
