using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class ArchivosConfiguration : IEntityTypeConfiguration<Archivos>
    {
        public void Configure(EntityTypeBuilder<Archivos> builder){
            
            builder
                .HasKey(x => x.IDArchivo);

            builder
                .Property(x => x.IDArchivo)
                .IsRequired()
                .HasMaxLength(10); 

            builder
                .Property(x => x.Documento)
                .IsRequired()
                .HasMaxLength(300); 

            
            builder.HasOne(x => x.Prestamo)
                .WithMany()
                .HasForeignKey(x => x.IDPrestamo);       


            builder.HasOne(x => x.TipoArchivo)
                .WithMany()
                .HasForeignKey(x => x.IDTipoarch);       
        


            builder
                .ToTable("Archivos");
        }
        
    }
}