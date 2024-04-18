using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class PrestamosValidators : AbstractValidator<Prestamos>
    {
        public PrestamosValidators()
        {
            RuleFor(x => x.IDPrestamo)
                .NotNull()
                .Must(id => id.ToString().Length <= 35)
                .WithMessage("IDPrestamo debe tener como máximo 35 dígitos.");
            
            RuleFor(x => x.CantCuotas);
            RuleFor(x => x.IDTasa);
            RuleFor(x => x.IDCuenta);
            RuleFor(x => x.FechaDeOperacion);
            RuleFor(x => x.Monto);
        }
    }
}
