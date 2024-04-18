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
        public int CedulaUsuario {get; set;} //FK
        public virtual Usuario? UsuarioActual {get; set;} 
    } 
}