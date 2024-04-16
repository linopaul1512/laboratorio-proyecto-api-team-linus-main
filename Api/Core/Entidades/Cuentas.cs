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
        public  Usuario? CIUsuario {get; set;}
        public virtual Usuario? CI {get; set;}
        public int Saldo {get; set;}
    }
}