using Core.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class TasasConfiguration : IEntityTypeConfiguration<Tasas>
    {
        public void Configure(EntityTypeBuilder<Tasas> builder){
            
            builder
                .HasKey(x => x.IDTasa);

            builder
                .Property(x => x.IDTasa)
                .IsRequired()
                .HasMaxLength(5); 
                        
            builder
                .Property(x => x.Porcentaje).IsRequired().HasMaxLength(35);

            
      


            builder
                .ToTable("Tasas");
        }
        
    }
}