using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ArchivosRepository: BaseRepository<Archivos>, IArchivosRepository
    {
        public ArchivosRepository(AppDbContext context) : base(context){}
    }
}