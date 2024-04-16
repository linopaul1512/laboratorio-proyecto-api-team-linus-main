using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Movimientos
    {
        public int IDMovimiento {get;set;}
        public  TipoMovimiento? IDTipo {get; set;}
        public virtual TipoMovimiento? Tipo {get; set;}
        public  string?  IDCuenta {get; set;}
        public  DateTime  Fecha {get; set;}
        public  double  Monto {get; set;}
    }
}