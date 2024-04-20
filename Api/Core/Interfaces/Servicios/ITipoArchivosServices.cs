using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface ITipoArchivosService
    {
        
        Task<TipoArchivos> GetTipoArchivoById(int id);
        Task<IEnumerable<TipoArchivos>> GetAll();
        Task<TipoArchivos> CreateTipo(TipoArchivos newTipo);

    }
}