using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Prestamos
    {   public int IDPrestamo {get;set;}
        public int CantCuotas {get;set;}
        public  int IDTasa {get; set;} //FK
        public virtual Tasas? Tasa {get; set;} //Informacion 0  
        public  int IDCuenta {get; set;}
        public virtual Cuentas? Cuenta {get; set;}
        public  DateTime  FechaDeOperacion {get; set;}
        public double Monto {get;set;}
        public string Estado {get;set;}

        
    }
}