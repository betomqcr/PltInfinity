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
            builder.Property(e => e.idItemInfinity).IsRequired();
            builder.Property(e => e.typing).IsRequired();
            builder.Property(e => e.agente).IsRequired();
            builder.Property(e => e.agenteEmail).IsRequired();
            builder.Property(e => e.typing).IsRequired();
            builder.Property(e => e.contactPhoneWA)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(e => e.estado).IsRequired();
            builder.Property(e => e.idHibotConversation).IsRequired();
        }
    }
}
