using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface ISesionService
    {
        Task<Sesion> Login(int cedula, string contraseña);
        string Close_Sesion(Sesion sesion);
        bool Validate(string token);

        
     
    }
}
