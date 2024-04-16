using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class MovimientosValidators : AbstractValidator<Movimientos>
    {
        public MovimientosValidators()
        {
            RuleFor(x => x.IDMovimiento)
                .NotNull()
                .Must(id => id.ToString().Length <= 35)
                .WithMessage("IDMovimiento debe tener como máximo 35 dígitos.");
           
           
             

        }
    }
}