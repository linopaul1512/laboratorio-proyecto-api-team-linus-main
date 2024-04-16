using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Usuario
    {
        public int CI {get;set;}
        public  string?  Nombre {get; set;}
        public  string?  Apellido {get; set;}
        public  DateTime  FechaDenacimiento {get; set;}
        public  int Telefono {get; set;}
        public string? CorreoElectronico {get; set;}
        public string? Direccion {get; set;}   
        public  string?  Contraseña {get; set;}  
    }
}