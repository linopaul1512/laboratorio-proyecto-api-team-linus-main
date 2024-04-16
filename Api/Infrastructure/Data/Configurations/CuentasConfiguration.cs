using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class CuentasConfiguration : IEntityTypeConfiguration<Cuentas>
    {
        public void Configure(EntityTypeBuilder<Cuentas> builder){
            
            builder
                .HasKey(x => x.IDCuenta);

            builder.Property(x => x.IDCuenta).IsRequired().HasMaxLength(35); 
            builder.Property(x => x.Saldo).IsRequired().HasMaxLength(35); 
            
            builder.HasOne(x => x.CIUsuario) 
                .WithMany() 
                .HasForeignKey(x => x.CI); 
            
      


            builder
                .ToTable("Cuentas");
        }
        
    }
}