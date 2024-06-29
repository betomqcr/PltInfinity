using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfintyHibotPlt.Datos.Models.settings
{
    public class EntradaConfig : IEntityTypeConfiguration<Entrada>
    {
        public void Configure(EntityTypeBuilder<Entrada> builder)
        {
            builder.HasKey(e => e.idEntrada);
            builder.Property(e => e.JsonEntrada)
                .IsRequired();
            builder.Property(e => e.idChat).HasMaxLength(50)
                .IsRequired();
        }
    }
}
