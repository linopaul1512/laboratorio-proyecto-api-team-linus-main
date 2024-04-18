using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class PrestamosConfiguration : IEntityTypeConfiguration<Prestamos>
    {
        public void Configure(EntityTypeBuilder<Prestamos> builder){
            
            builder
                .HasKey(x => x.IDPrestamo);

            builder.Property(x => x.IDPrestamo).IsRequired().HasMaxLength(35);

            builder.HasOne(x => x.Tasa) 
                .WithMany() 
                .HasForeignKey(x => x.IDTasa); 

            
            builder.HasOne(x => x.Cuenta) 
                .WithMany() 
                .HasForeignKey(x => x.IDCuenta); 

            builder.Property(x => x.FechaDeOperacion).IsRequired().HasMaxLength(35); 
            builder.Property(x => x.Monto).IsRequired().HasMaxLength(35);
            builder.Property(x => x.CantCuotas).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Estado).IsRequired().HasMaxLength(35);


            


            builder
                .ToTable("Prestamos");
        }
        
    }
}