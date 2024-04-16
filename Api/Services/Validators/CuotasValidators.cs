using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class CuotasValidators : AbstractValidator<Cuotas>
    {
        public CuotasValidators()
        {
            RuleFor(x => x.IDCuota)
                .NotNull()
                .Must(id => id.ToString().Length <= 35)
                .WithMessage("IDCuota debe tener como máximo 35 dígitos.");
            
            RuleFor(x => x.IDPrestamo);


        }
    }
}