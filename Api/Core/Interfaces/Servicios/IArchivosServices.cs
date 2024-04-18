using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface IArchivosService 
    {
        Task<Archivos> GetArchivoById(int id);
        Task<IEnumerable<Archivos>> GetAll();
        Task<Archivos> CreateArchivo(Archivos newArchivo);
        Task<Archivos> UpdateArchivo(int archivoToBeUpdatedId, Archivos newArchivoValues);

    }
}