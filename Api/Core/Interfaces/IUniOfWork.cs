using Core.Interfaces.Repositorios;
namespace Core.Interfaces;

public interface IUnitOfWork : IDisposable
    {
        IUsuariosRepository UsuarioRepository { get; }
        ICuentasRepository CuentasRepository { get; }
        ICuotasRepository CuotasRepository { get; }
        IMovimientosRepository MovimientosRepository { get; }
        IPrestamosRepository PrestamosRepository { get; }
        ITasasRepository TasasRepository { get; }
        ITipoMovimientoRepository TipoMovimientoRepository { get; }
        IArchivosRepository ArchivosRepository { get; }
        ISesionesRepository SesionRepository { get; }
        IArchivosPrestamosRepository ArchivosPrestasmosRepository { get; }
        ITipoArchivosRepository TipoArchivosRepository { get; }

        Task<int> CommitAsync();
    }