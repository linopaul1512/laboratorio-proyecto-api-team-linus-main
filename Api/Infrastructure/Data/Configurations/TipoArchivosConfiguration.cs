using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TipoArchivosConfiguration : IEntityTypeConfiguration<TipoArchivos>
    {
        public void Configure(EntityTypeBuilder<TipoArchivos> builder){
            
            builder
                .HasKey(x => x.IDTipoarch);

            builder
                .Property(x => x.IDTipoarch)
                .IsRequired()
                .HasMaxLength(2); 
                        
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(35);
            
      


            builder
                .ToTable("TipoArchivos");
        }
        
    }
}