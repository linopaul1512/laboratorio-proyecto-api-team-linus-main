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
        public int IDPrestamo {get; set;}
        public virtual Prestamos? Prestamo {get; set;}
        public int IDTipoarch {get; set;}
        public virtual TipoArchivos? TipoArchivo {get; set;}
        public string? Documento {get;set;}
        

    }
}