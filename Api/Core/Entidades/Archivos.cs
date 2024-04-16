using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Archivos
    {
        public int IDArchivo {get;set;}
        public  Prestamos? IDPrestamo {get; set;}
        public virtual Prestamos? Prestamo {get; set;}
        public string? Documento {get;set;}
        

    }
}