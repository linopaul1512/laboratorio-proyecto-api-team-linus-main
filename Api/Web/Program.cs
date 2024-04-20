using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Core.Servicios;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Services.Services;
using System.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Gracosoft .NET CORe",
        Description = "Aplicación de Bank DavNo",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Lino y David ",
            Url = new Uri("https://github.com/G3-Graco/laboratorio-proyecto-api-team-linus.git")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
      
    });

        // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddControllers();


builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IArchivosRepository), typeof(ArchivosRepository));
builder.Services.AddScoped(typeof(ICuentasRepository), typeof(CuentasRepository));
builder.Services.AddScoped(typeof(ICuotasRepository), typeof(CuotasRepository));
builder.Services.AddScoped(typeof(IMovimientosRepository), typeof(MovimientosRepository));
builder.Services.AddScoped(typeof(IPrestamosRepository), typeof(PrestamosRepository));
builder.Services.AddScoped(typeof(ISesionesRepository), typeof(SesionesRepository));
builder.Services.AddScoped(typeof(ITasasRepository), typeof(TasasRepository));
builder.Services.AddScoped(typeof(ITipoMovimientoRepository), typeof(TipoMovimientoRepository));
builder.Services.AddScoped(typeof(IUsuariosRepository), typeof(UsuariosRepository));
builder.Services.AddScoped(typeof(IArchivosPrestamosRepository), typeof(ArchivosPrestamosRepository));



builder.Services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
builder.Services.AddScoped(typeof(IArchivosService), typeof(ArchivoService));
builder.Services.AddScoped(typeof(ICuentasService), typeof(CuentaService));
builder.Services.AddScoped(typeof(ICuotasService), typeof(CuotaService));
builder.Services.AddScoped(typeof(IMovimientosService), typeof(MovimientoService));
builder.Services.AddScoped(typeof(IPrestamosService), typeof(PrestamoService));
builder.Services.AddScoped(typeof(ISesionService), typeof(SesionService));
builder.Services.AddScoped(typeof(ITasasService), typeof(TasaService));
builder.Services.AddScoped(typeof(ITipoArchivosService), typeof(TipoArchivoService));
builder.Services.AddScoped(typeof(ITipoMovimientoService), typeof(TipoMovimientoService));
builder.Services.AddScoped(typeof(IArchivosPrestamosRepository), typeof(ArchivosPrestamosRepository));


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseHttpsRedirection();


app.MapControllers();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();




            





app.Run();

