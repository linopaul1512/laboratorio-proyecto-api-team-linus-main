using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class TasasValidators : AbstractValidator<Tasas>
    {
        public TasasValidators()
        {
            RuleFor(x => x.IDTasa)
            .NotNull()
            .Must(id => id.ToString().Length == 5)
            .WithMessage("IDTasa debe tener exactamente 5 dígitos.");
        
            RuleFor(x => x.Porcentaje)
                .NotNull()
                .Must(id => id.ToString().Length <= 35)
                .WithMessage("Porcentaje debe tener como máximo 35 dígitos.");
  

        }
    }
}