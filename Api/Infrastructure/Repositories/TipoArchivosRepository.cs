using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class TipoArchivosRepository: BaseRepository<TipoArchivos>, ITipoArchivosRepository
    {
        public TipoArchivosRepository(AppDbContext context) : base(context){}
    }
}