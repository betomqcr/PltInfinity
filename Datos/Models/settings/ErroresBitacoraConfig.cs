using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfintyHibotPlt.Datos.Models.settings
{
    public class ErroresBitacoraConfig : IEntityTypeConfiguration<ErroresBitacora>
    {
        public void Configure(EntityTypeBuilder<ErroresBitacora> builder)
        {
            builder.HasKey(e => e.idError);
            builder.Property(e => e.menssageError).IsRequired();
            builder.Property(e=>e.Fecha).IsRequired();
        }
    }
}
