using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class TipoMovimientoValidators : AbstractValidator<TipoMovimiento>
    {
        public TipoMovimientoValidators()
        {
            RuleFor(x => x.IDTipo)
                .NotNull()
                .Must(id => id.ToString().Length <= 35)
                .WithMessage("IDTipo debe tener como máximo 35 dígitos.");
        
            RuleFor(x => x.Nombre)
                .NotNull()
                .Must(id => id.ToString().Length <= 35)
                .WithMessage("Nombre debe tener como máximo 35 dígitos.");

        }
    }
}