using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class SesionesConfigurations : IEntityTypeConfiguration<Sesion>
    {
        public void Configure(EntityTypeBuilder<Sesion> builder){
            
            builder.HasKey(x => x.Id); 
            builder.Property(x => x.Id).UseIdentityColumn(); 
            builder.Property(x => x.CedulaUsuario).IsRequired(); 
            builder.Property(x => x.Token).HasMaxLength(227).IsRequired(); 

 
            builder.HasOne(x => x.UsuarioActual) 
                .WithMany() 
                .HasForeignKey(x => x.CedulaUsuario); 
            

            builder
                .ToTable("Sesiones");
        }
        
    }
}