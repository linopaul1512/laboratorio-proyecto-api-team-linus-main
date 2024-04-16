using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;

namespace Services.Validators
{
    public class ArchivosValidators : AbstractValidator<Archivos>
    {
        public ArchivosValidators()
        {
            RuleFor(x => x.IDArchivo)
                .NotNull()
                .Must(id => id.ToString().Length <= 35)
                .WithMessage("IDArchivo debe tener como máximo 35 dígitos.");
            
            RuleFor(x => x.Documento)
            .NotNull()
                .Must(id => id.ToString().Length <= 300)
                .WithMessage("Documento debe tener como máximo 300 dígitos.");
  

        }
    }
}