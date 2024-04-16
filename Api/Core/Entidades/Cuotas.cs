using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Cuotas
    {
        public int IDCuota {get;set;}
        public  Prestamos? IDPrestamo {get; set;}
        public virtual Prestamos? Prestamo {get; set;}
    }
}