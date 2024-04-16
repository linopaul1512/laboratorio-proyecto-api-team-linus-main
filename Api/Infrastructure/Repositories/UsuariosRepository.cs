using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class UsuariosRepository: BaseRepository<Usuario>, IUsuariosRepository
    {
        public UsuariosRepository(AppDbContext context) : base(context){}
    }
}