using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Archivos_Prestamos
    {
        public int IDArchpres {get;set;} //PK intermedia
        public  int IDArchivo {get; set;} //FK
        public virtual Archivos? Archivo {get; set;} //Informacion 0

        public  int IDPrestamo {get; set;} //FK
        public virtual Prestamos? Prestamo {get; set;} //Informacion 0
       
    }
}