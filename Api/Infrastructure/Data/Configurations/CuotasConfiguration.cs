using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CuotasConfiguration : IEntityTypeConfiguration<Cuotas>
    {
        public void Configure(EntityTypeBuilder<Cuotas> builder){
            
            builder
                .HasKey(x => x.IDCuota);

            builder
                .Property(x => x.IDCuota)
                .IsRequired()
                .HasMaxLength(35); 
                        
            builder.HasOne(x => x.Prestamo)
                .WithMany()
                .HasForeignKey(x => x.IDPrestamo);            
        

      


            builder
                .ToTable("Cuotas");
        }
        
    }
}