using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace InfintyHibotPlt.Datos.Models.settings
{
    public class MessagesConfig : IEntityTypeConfiguration<Messages>
    {
        public void Configure(EntityTypeBuilder<Messages> builder)
        {
            builder.HasKey(e => e.idMessages);
            builder.Property(e => e.content)
                .IsRequired();
            builder.Property(e => e.created).IsRequired();
            builder.Property(e => e.personContent)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.idHibotMessages).IsRequired();
            builder.Property(e => e.mediaType).IsRequired();
            builder.Property(e => e.media).IsRequired();
            builder.Property(e=> e.idConversation).IsRequired();
            
        }
    }
}
