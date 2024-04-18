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
    public class PrestamoService : IPrestamosService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public PrestamoService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task<Prestamos> UpdatePrestamo(int id, Prestamos prestamo)
        {
            PrestamosValidators validaciones = new();
            var validationResult = await validaciones.ValidateAsync(prestamo);
            if (validationResult.IsValid)
            {
                var many = await _unitOfWork.PrestamosRepository.GetAllAsync();
                if (many.Any(x => x.IDPrestamo == id))
                {
                    await _unitOfWork.PrestamosRepository.Update(prestamo);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("Se produjo un aerror al modificar los datos");
            } else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return prestamo;
        }

 
        public async Task<Prestamos> GetPrestamoById(int id)
        {
            var muchos = await _unitOfWork.PrestamosRepository.GetAllAsync();
            var prestamo = 
                muchos.FirstOrDefault(x => x.IDPrestamo == id) ?? 
                throw new ArgumentException("Prestamo inexistente");
            return prestamo;
        }

        public async Task<IEnumerable<Prestamos>> GetAll()
        {
            return await _unitOfWork.PrestamosRepository.GetAllAsync();
        }

        public async Task<Prestamos> CreatePrestamo(Prestamos prestamos)
        {
            PrestamosValidators validator = new();

            var validationResult = await validator.ValidateAsync(prestamos);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.PrestamosRepository.GetAllAsync();
                if (!muchos.Any(x => x.IDPrestamo == prestamos.IDPrestamo))
                {
                    await _unitOfWork.PrestamosRepository.AddAsync(prestamos);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("La prestamo ya se encuentra registrado");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return prestamos;
        }

       
    }
}