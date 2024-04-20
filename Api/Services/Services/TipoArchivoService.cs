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
    public class TipoArchivoService : ITipoArchivosService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public TipoArchivoService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        
 


        public async Task<IEnumerable<TipoArchivos>> GetAll()
        {
            return await _unitOfWork.TipoArchivosRepository.GetAllAsync();
        }

        public async Task<TipoArchivos> CreateTipo(TipoArchivos tipo)
        {
            TipoArchivosValidators validator = new();

            var validationResult = await validator.ValidateAsync(tipo);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.TipoArchivosRepository.GetAllAsync();
                if (!muchos.Any(x => x.IDTipoarch == tipo.IDTipoarch))
                {
                    await _unitOfWork.TipoArchivosRepository.AddAsync(tipo);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("El tipo ya se encuentra registrado");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return tipo;
        }
        public async Task<TipoArchivos> GetTipoArchivoByName(string nombre)
        {
            var muchos = await _unitOfWork.TipoArchivosRepository.GetAllAsync();
            var tipoArchivos = muchos.FirstOrDefault(x => x.Nombre == nombre) ??
                throw new ArgumentException("Tipo de movimiento inexistente");
            return tipoArchivos;
        }


    }
}