using Core.Entidades;
using Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios {get;set;}
        public DbSet<Archivos> Archivos {get;set;}
        public DbSet<Cuentas> Cuentas {get;set;}
        public DbSet<Cuotas> Cuotasuotas {get;set;}
        public DbSet<Movimientos> Movimientos {get;set;}
        public DbSet<Prestamos> Prestamos {get;set;}
        public DbSet<Tasas> Tasas {get;set;}
        public DbSet<TipoMovimiento> TipoMovimientos {get;set;}
        public DbSet<Sesion> Sesiones {get;set;}


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

      

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UsuariosConfiguration());
            builder.ApplyConfiguration(new CuentasConfiguration());
            builder.ApplyConfiguration(new CuotasConfiguration());
            builder.ApplyConfiguration(new TipoMovimientosConfiguration());
            builder.ApplyConfiguration(new MovimientosConfiguration());
            builder.ApplyConfiguration(new PrestamosConfiguration());
            builder.ApplyConfiguration(new TasasConfiguration());
            builder.ApplyConfiguration(new SesionesConfigurations());
        }
    }
}