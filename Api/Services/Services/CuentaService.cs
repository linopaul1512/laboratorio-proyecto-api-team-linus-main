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
    public class CuentaService : ICuentasService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CuentaService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<Cuentas> UpdateCuenta(int id, Cuentas cuenta)
        {
            CuentaValidators validaciones = new();
            var validationResult = await validaciones.ValidateAsync(cuenta);
            if (validationResult.IsValid)
            {
                var many = await _unitOfWork.CuentasRepository.GetAllAsync();
                if (many.Any(x => x.IDCuenta == id))
                {
                    await _unitOfWork.CuentasRepository.Update(cuenta);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("Se produjo un error al modificar los datos");
            } else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return cuenta;
        }

 
        public async Task<Cuentas> GetCuentaById(int id)
        {
            var muchos = await _unitOfWork.CuentasRepository.GetAllAsync();
            var cuenta = 
                muchos.FirstOrDefault(x => x.IDCuenta == id) ?? 
                throw new ArgumentException("Cuenta inexistente");
            return cuenta;
        }

        public async Task<IEnumerable<Cuentas>> GetAll()
        {
            return await _unitOfWork.CuentasRepository.GetAllAsync();
        }

        public async Task<Cuentas> CreateCuenta(Cuentas cuenta)
        {
            CuentaValidators validator = new();

            var validationResult = await validator.ValidateAsync(cuenta);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.CuentasRepository.GetAllAsync();
                if (!muchos.Any(x => x.IDCuenta == cuenta.IDCuenta))
                {
                    await _unitOfWork.CuentasRepository.AddAsync(cuenta);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("La cuenta ya se encuentra registrado");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return cuenta;
        }

       
    }
}