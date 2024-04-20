using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface IArchivosPrestamosServices 
    {
        Task<Archivos_Prestamos> GetInterById(int id);
        Task<IEnumerable<Archivos_Prestamos>> GetAll();
        Task<Archivos_Prestamos> CreateInter(Archivos newArchivo);

    }
}