using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class CuentaValidators : AbstractValidator<Cuentas>
    {
        public CuentaValidators()
        {
            RuleFor(x => x.IDCuenta)
            .NotNull()
            .Must(id => id.ToString().Length == 12)
            .WithMessage("IDCuenta debe tener exactamente 12 dígitos.");
        
            
            RuleFor(x => x.Saldo);
        }
    }
}