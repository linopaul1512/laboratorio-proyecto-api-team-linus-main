using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface IMovimientosService
    {
        Task<Movimientos> GetMovimientoById(int id);    
        Task<IEnumerable<Movimientos>> GetAll();
        Task<Movimientos> CreateMovimiento(Movimientos newMovimiento);
        Task<Movimientos> UpdateMovimiento(int movimientoToBeUpdatedId, Movimientos newMovimientoValues);
    }
}