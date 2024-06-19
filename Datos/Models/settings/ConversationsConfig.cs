using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace InfintyHibotPlt.Datos.Models.settings
{
    public class ConversationsConfig : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.HasKey(e => e.idConversation);
            builder.Property(e => e.contactName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(e=> e.idItemInfinity).IsRequired(false).HasMaxLength(200);
            builder.Property(e => e.typing).IsRequired();
            builder.Property(e => e.agente).IsRequired().HasMaxLength(200);
            builder.Property(e => e.agenteEmail).IsRequired();
            builder.Property(e => e.typing).IsRequired();
            builder.Property(e => e.contactPhoneWA)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(e => e.estado).IsRequired();
            builder.Property(e => e.idHibotConversation).IsRequired().HasMaxLength(200);
            builder.Property(e=> e.create).IsRequired();
            builder.Property(e => e.assigend).IsRequired();
            builder.Property(e => e.closed).IsRequired();
        }
    }
}
