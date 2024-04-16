using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CuentasRepository: BaseRepository<Cuentas>, ICuentasRepository
    {
        public CuentasRepository(AppDbContext context) : base(context){}
    }
}