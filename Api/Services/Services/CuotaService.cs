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
    public class CuotaService : ICuotasService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public CuotaService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<Cuotas> UpdateCuota(int id, Cuotas cuotas)
        {
            CuotasValidators validaciones = new();
            var validationResult = await validaciones.ValidateAsync(cuotas);
            if (validationResult.IsValid)
            {
                var many = await _unitOfWork.CuotasRepository.GetAllAsync();
                if (many.Any(x => x.IDCuota == id))
                {
                    await _unitOfWork.CuotasRepository.Update(cuotas);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("Se produjo un error al modificar los datos");
            } else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return cuotas;
        }

 
        public async Task<Cuotas> GetCuotaById(int id)
        {
            var muchos = await _unitOfWork.CuotasRepository.GetAllAsync();
            var cuotas = 
                muchos.FirstOrDefault(x => x.IDCuota == id) ?? 
                throw new ArgumentException("Cuota inexistente");
            return cuotas;
        }

        public async Task<IEnumerable<Cuotas>> GetAll()
        {
            return await _unitOfWork.CuotasRepository.GetAllAsync();
        }

        public async Task<Cuotas> CreateCuota(Cuotas cuotas)
        {
            CuotasValidators validator = new();

            var validationResult = await validator.ValidateAsync(cuotas);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.CuotasRepository.GetAllAsync();
                if (!muchos.Any(x => x.IDCuota == cuotas.IDCuota))
                {
                    await _unitOfWork.CuotasRepository.AddAsync(cuotas);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("La cuota ya se encuentra registrado");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return cuotas;
        }

       
    }
}