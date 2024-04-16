using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using FluentValidation;
using FluentValidation.Validators;

namespace Services.validators
{
    public class UsuariosValidacion : AbstractValidator<Usuario>
    {
        public UsuariosValidacion() {
            RuleFor(x => x.CI).NotEmpty();
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.Apellido).NotEmpty()
            .EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleFor(x => x.Telefono).NotEmpty();
            RuleFor(x => x.FechaDenacimiento).NotNull();
            RuleFor(x => x.Direccion).NotEmpty();
            RuleFor(x => x.Contraseña).NotEmpty();
            

              
            
        }
    }
}