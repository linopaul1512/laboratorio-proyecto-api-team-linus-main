using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
     public class SesionesRepository : BaseRepository<Sesion>, ISesionesRepository
    {
        public SesionesRepository(AppDbContext context) : base(context)
        {
        }

        public string Close_Sesion(Sesion sesion)
        {
            throw new NotImplementedException();
        }

        public Task<Sesion> Login(int cedula, string contraseña)
        {
            throw new NotImplementedException();
        }

        public bool Validate(string token)
        {
            throw new NotImplementedException();
        }
    }
    
}