using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface ITasasService
    {
        Task<Tasas> GetTasaById(int id);
        Task<IEnumerable<Tasas>> GetAll();
        Task<Tasas> CreateTasa(Tasas newArchivo);
        Task<Tasas> UpdateTasa(int tasaToBeUpdatedId, Tasas newTasaValues);
    }
}