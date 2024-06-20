using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfintyHibotPlt.Datos.Models.settings
{
    public class ImagenesConfig : IEntityTypeConfiguration<Imagenes>
    {
        public void Configure(EntityTypeBuilder<Imagenes> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e=>e.Id).IsRequired();
            builder.Property(e => e.Archivo).IsRequired();
            builder.Property(e => e.messagesidMessages).IsRequired();
        }
    }
}
