using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface ITasasService
    {
        Task<Tasas> GetTasaByPorcentaje(int id);

        Task<IEnumerable<Tasas>> GetAll();
        Task<Tasas> CreateTasa(Tasas newArchivo);
    }
}