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
        public  int IDTipo {get; set;}
        public virtual TipoMovimiento? Tipo {get; set;}
        public  int  IDCuentaAcreditada {get; set;}
        public virtual Cuentas? CuentaAcreditada {get; set;}
        public  int  IDCuentaDebitada {get; set;} //FK, Cuenta a la que se le deposito(para movimientos de Deposito y Prestamo)
        public virtual Cuentas? CuentaDebitada {get; set;}
        public  DateTime  Fecha {get; set;}
        public  double  Monto {get; set;}
    }
}