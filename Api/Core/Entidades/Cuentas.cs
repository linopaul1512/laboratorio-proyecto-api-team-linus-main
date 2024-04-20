using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Cuentas
    {
        public int IDCuenta {get;set;}
        public  int CI {get; set;}
        public virtual Usuario? Usuario {get; set;}
        public double Saldo {get; set;}
    }
}