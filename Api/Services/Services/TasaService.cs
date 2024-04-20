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
    public class TasaService : ITasasService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public TasaService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<Tasas> UpdateTasa(int id, Tasas tasas)
        {
            TasasValidators validaciones = new();
            var validationResult = await validaciones.ValidateAsync(tasas);
            if (validationResult.IsValid)
            {
                var many = await _unitOfWork.TasasRepository.GetAllAsync();
                if (many.Any(x => x.IDTasa == id))
                {
                    await _unitOfWork.TasasRepository.Update(tasas);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("Se produjo un aerror al modificar los datos");
            } else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return tasas;
        }

 
        public async Task<Tasas> GetTasaById(int id)
        {
            var muchos = await _unitOfWork.TasasRepository.GetAllAsync();
            var tasas = 
                muchos.FirstOrDefault(x => x.IDTasa == id) ?? 
                throw new ArgumentException("Tasa inexistente");
            return tasas;
        }

        public async Task<Tasas> GetTasaByPorcentaje(int id)
        {
            var muchos = await _unitOfWork.TasasRepository.GetAllAsync();
            var tasas = 
                muchos.FirstOrDefault(x => x.Porcentaje == id) ?? 
                throw new ArgumentException("Porcentaje inexistente");
            return tasas;
        }

        public async Task<IEnumerable<Tasas>> GetAll()
        {
            return await _unitOfWork.TasasRepository.GetAllAsync();
        }

        public async Task<Tasas> CreateTasa(Tasas tasas)
        {
            TasasValidators validator = new();

            var validationResult = await validator.ValidateAsync(tasas);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.TasasRepository.GetAllAsync();
                if (!muchos.Any(x => x.IDTasa == tasas.IDTasa))
                {
                    await _unitOfWork.TasasRepository.AddAsync(tasas);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("La tasa ya se encuentra registrado");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return tasas;
        }

       
    }
}