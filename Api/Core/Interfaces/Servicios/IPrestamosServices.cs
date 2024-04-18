using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface IPrestamosService 
    {
         Task<Prestamos> GetPrestamoById(int id);
        Task<IEnumerable<Prestamos>> GetAll();
        Task<Prestamos> CreatePrestamo(Prestamos newPrestamo);
        Task<Prestamos> UpdatePrestamo(int prestamoToBeUpdatedId, Prestamos newPrestamoValues);
    }
}