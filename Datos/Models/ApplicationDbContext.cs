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

            modelBuilder.Entity<Conversation>().HasKey(e => e.idConversation);
            modelBuilder.Entity<Conversation>().Property(e => e.contactName)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Conversation>().Property(e => e.idItemInfinity).IsRequired();
            modelBuilder.Entity<Conversation>().Property(e => e.typing).IsRequired();
            modelBuilder.Entity<Conversation>().Property(e => e.agente).IsRequired();
            modelBuilder.Entity<Conversation>().Property(e => e.agenteEmail).IsRequired();
            modelBuilder.Entity<Conversation>().Property(e => e.typing).IsRequired();
            modelBuilder.Entity<Conversation>().Property(e => e.contactPhoneWA)
                .IsRequired()
                .HasMaxLength(20);
            modelBuilder.Entity<Conversation>().Property(e => e.estado).IsRequired();
            modelBuilder.Entity<Conversation>().Property(e => e.idHibotConversation).IsRequired();

            //Aqui empieza el armado de los mensajes de la conversacion

            modelBuilder.Entity<Messages>().HasKey(e => e.idMessages);
            modelBuilder.Entity<Messages>().Property(e => e.content)
                .IsRequired();
            modelBuilder.Entity<Messages>().Property(e => e.created).IsRequired();
            modelBuilder.Entity<Messages>().Property(e => e.personContent)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Messages>().Property(e => e.idHibotMessages).IsRequired();
            modelBuilder.Entity<Messages>().Property(e => e.mediaType).IsRequired();
            modelBuilder.Entity<Messages>().Property(e => e.media).IsRequired();
            

            //Aqui empieza el armado de la bitacora

            modelBuilder.Entity<Bitacora>().HasKey(e => e.idBitacora);
            modelBuilder.Entity<Bitacora>().Property(e => e.jsonEntrada)
                .IsRequired();
            modelBuilder.Entity<Bitacora>().Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Bitacora>().Property(e => e.idConversation)
                .IsRequired();


        }

        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Bitacora> Bitacora { get; set; }
    }
}
