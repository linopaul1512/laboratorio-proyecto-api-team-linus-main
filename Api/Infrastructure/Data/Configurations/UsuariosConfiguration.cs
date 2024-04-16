using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder){
            
            builder
                .HasKey(x => x.CI);

            builder.Property(x => x.CI).IsRequired().HasMaxLength(35); 
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(35); 
            builder.Property(x => x.Apellido).IsRequired().HasMaxLength(35); 
            builder.Property(x => x.FechaDenacimiento).IsRequired().HasMaxLength(35); 
            builder.Property(x => x.Telefono).IsRequired().HasMaxLength(35);
            builder.Property(x => x.CorreoElectronico).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(35);
            builder.Property(x => x.Contraseña).IsRequired().HasMaxLength(35);
                    


            builder
                .ToTable("Usuarios");
        }
        
    }
}