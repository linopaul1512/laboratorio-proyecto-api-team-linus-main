using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface ITipoMovimientoService
    {
        
        Task<TipoMovimiento> GetTipoByName(string nombre);
        Task<IEnumerable<TipoMovimiento>> GetAll();
        Task<TipoMovimiento> CreateTipo(TipoMovimiento newTipo);
        Task<TipoMovimiento> UpdateTasa(int tipoToBeUpdatedId, TipoMovimiento newTipoValues);
    }
}