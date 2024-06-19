using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace InfintyHibotPlt.Datos.Models.settings
{
    public class BitacoraConfig : IEntityTypeConfiguration<Bitacora>
    {
        public void Configure(EntityTypeBuilder<Bitacora> builder)
        {
            builder.HasKey(e => e.idBitacora);
            builder.Property(e => e.jsonEntrada)
                .IsRequired();
            builder.Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.idConversation)
                .IsRequired();
        }
    }
}
