using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Threading.Tasks; 
 
namespace Core.Entidades 
{ 
    public class Sesion 
    { 
        public int Id {get; set;} 
        public string? Token {get; set;} 
        public string? CedulaUsuario {get; set;} 
        public virtual Usuario? UsuarioActual {get; set;} 
    } 
}