using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Infrastructure.Repositories;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private CuentasRepository  _cuentaRepository;
        private CuotasRepository  _cuotarepository;
        private MovimientosRepository  _movimientoRepository;
        private PrestamosRepository  _prestamoRepository;
        private TipoMovimientoRepository  _tipomovimientoRepository;
        private TasasRepository  _tasaRepository;
        private UsuariosRepository _usuarioRepository;  
        private ArchivosRepository _archivoRepository;  
        private SesionesRepository _sesionRepository;
        private ArchivosPrestamosRepository _archivosprestamosRepositoy;
        private TipoArchivosRepository _tipotipoarchivosRepository;
        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public IUsuariosRepository UsuarioRepository => _usuarioRepository ??= new UsuariosRepository(_context);
        public ITasasRepository TasasRepository => _tasaRepository ??= new TasasRepository(_context);
        public ICuentasRepository CuentasRepository => _cuentaRepository ??= new CuentasRepository(_context);
        public ICuotasRepository CuotasRepository => _cuotarepository ??= new CuotasRepository(_context);
        public IMovimientosRepository MovimientosRepository => _movimientoRepository ??= new MovimientosRepository(_context);
        public IPrestamosRepository PrestamosRepository =>   _prestamoRepository ??= new PrestamosRepository(_context);
        public ITipoMovimientoRepository  TipoMovimientoRepository=> _tipomovimientoRepository  ??= new TipoMovimientoRepository(_context);
        public IArchivosRepository ArchivosRepository => _archivoRepository ??= new ArchivosRepository(_context);
        public ISesionesRepository SesionRepository => _sesionRepository ??= new SesionesRepository(_context);
        public IArchivosPrestamosRepository ArchivosPrestasmosRepository => _archivosprestamosRepositoy  ??= new ArchivosPrestamosRepository(_context);
        public ITipoArchivosRepository TipoArchivosRepository => _tipotipoarchivosRepository ??= new TipoArchivosRepository(_context);
        
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}