using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Interfaces.Servicios
{
    public interface ICuotasService 
    {
                
        Task<Cuotas> GetCuotaById(int id);
        Task<IEnumerable<Cuotas>> GetAll();
        Task<Cuotas> CreateCuota(Cuotas newCuotaso);
        Task<Cuotas> UpdateCuota(int cuotaToBeUpdatedId, Cuotas newCuotaValues);
    }
}