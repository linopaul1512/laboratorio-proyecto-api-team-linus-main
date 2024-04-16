using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TipoMovimientoRepository: BaseRepository<TipoMovimiento>, ITipoMovimientoRepository
    {
        public TipoMovimientoRepository(AppDbContext context) : base(context){}
    }
}