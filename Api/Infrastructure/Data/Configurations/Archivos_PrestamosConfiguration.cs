using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class Archivos_PrestamosConfiguration : IEntityTypeConfiguration<Archivos_Prestamos>
    {
        public void Configure(EntityTypeBuilder<Archivos_Prestamos> builder){
            
            builder
                .HasKey(x => x.IDArchpres);

            builder
                .Property(x => x.IDArchpres)
                .IsRequired()
                .HasMaxLength(10); 

             

            
            builder.HasOne(x => x.Prestamo)
                .WithMany()
                .HasForeignKey(x => x.IDPrestamo);       


            builder.HasOne(x => x.Archivo)
                .WithMany()
                .HasForeignKey(x => x.IDArchivo);       
        


            builder
                .ToTable("Archivos_Prestamos");
        }
        
    }
}