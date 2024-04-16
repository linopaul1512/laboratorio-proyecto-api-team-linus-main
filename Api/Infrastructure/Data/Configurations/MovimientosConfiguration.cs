using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class MovimientosConfiguration : IEntityTypeConfiguration<Movimientos>
    {
        public void Configure(EntityTypeBuilder<Movimientos> builder){
            
            builder
                .HasKey(x => x.IDMovimiento);

            builder
                .Property(x => x.IDMovimiento)
                .IsRequired()
                .HasMaxLength(35); 
                        
            builder.HasOne(x => x.Tipo) 
                .WithMany() 
                .HasForeignKey(x => x.IDMovimiento); 

            builder.Property(x => x.Fecha).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Monto).IsRequired().HasMaxLength(35);  
       


            builder
                .ToTable("Movimientos");
        }
        
    }

}