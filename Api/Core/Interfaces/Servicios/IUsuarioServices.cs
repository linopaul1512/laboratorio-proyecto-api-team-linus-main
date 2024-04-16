using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;

namespace Core.Servicios
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarioById(int id);
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> CreateUsuario(Usuario newUsuario);
        Task<Usuario> UpdateUsuario(int usuarioToBeUpdatedId, Usuario newUsuarioValues);

     
    }
}