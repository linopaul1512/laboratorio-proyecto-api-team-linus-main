using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface ICuentasService 
    {
        Task<Cuentas> GetCuentaById(int id);
        Task<IEnumerable<Cuentas>> GetAll();
        Task<Cuentas> CreateCuenta(Cuentas newCuenta);
        Task<Cuentas> UpdateCuenta(int cuentasToBeUpdatedId, Cuentas newCuentaValues);
    }
}