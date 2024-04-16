using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TipoMovimientosConfiguration : IEntityTypeConfiguration<TipoMovimiento>
    {
        public void Configure(EntityTypeBuilder<TipoMovimiento> builder){
            
            builder
                .HasKey(x => x.IDTipo);

            builder
                .Property(x => x.IDTipo)
                .IsRequired()
                .HasMaxLength(35); 
                        
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(35);

            
      


            builder
                .ToTable("TipoMovimientos");
        }
        
    }
}