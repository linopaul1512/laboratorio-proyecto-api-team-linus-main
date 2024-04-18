using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces;
using Core.Interfaces.Repositorios;
using Core.Interfaces.Servicios;
using Services.Validators;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Core.Servicios;
using Services.validators;

namespace Services.Services
{
    public class TipoMovimientoService : ITipoMovimientoService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public TipoMovimientoService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<TipoMovimiento> UpdateTasa(int id, TipoMovimiento tipos)
        {
            TipoMovimientoValidators validaciones = new();
            var validationResult = await validaciones.ValidateAsync(tipos);
            if (validationResult.IsValid)
            {
                var many = await _unitOfWork.TipoMovimientoRepository.GetAllAsync();
                if (many.Any(x => x.IDTipo == id))
                {
                    await _unitOfWork.TipoMovimientoRepository.Update(tipos);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("Se produjo un aerror al modificar los datos");
            } else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return tipos;
        }

 


        public async Task<IEnumerable<TipoMovimiento>> GetAll()
        {
            return await _unitOfWork.TipoMovimientoRepository.GetAllAsync();
        }

        public async Task<TipoMovimiento> CreateTipo(TipoMovimiento tipo)
        {
            TipoMovimientoValidators validator = new();

            var validationResult = await validator.ValidateAsync(tipo);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.TipoMovimientoRepository.GetAllAsync();
                if (!muchos.Any(x => x.IDTipo == tipo.IDTipo))
                {
                    await _unitOfWork.TipoMovimientoRepository.AddAsync(tipo);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("El tipo ya se encuentra registrado");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return tipo;
        }
        public async Task<TipoMovimiento> GetTipoByName(string nombre)
        {
            var muchos = await _unitOfWork.TipoMovimientoRepository.GetAllAsync();
            var tipoMovimiento = muchos.FirstOrDefault(x => x.Nombre == nombre) ??
                throw new ArgumentException("Tipo de movimiento inexistente");
            return tipoMovimiento;
        }


    }
}