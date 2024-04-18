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
    public class ArchivoService : IArchivosService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ArchivoService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<Archivos> UpdateArchivo(int id, Archivos archivos)
        {
            ArchivosValidators validaciones = new();
            var validationResult = await validaciones.ValidateAsync(archivos);
            if (validationResult.IsValid)
            {
                var many = await _unitOfWork.ArchivosRepository.GetAllAsync();
                if (many.Any(x => x.IDArchivo == id))
                {
                    await _unitOfWork.ArchivosRepository.Update(archivos);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("Se produjo un aerror al modificar los datos");
            } else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return archivos;
        }

 
        public async Task<Archivos> GetArchivoById(int id)
        {
            var muchos = await _unitOfWork.ArchivosRepository.GetAllAsync();
            var archivo = 
                muchos.FirstOrDefault(x => x.IDArchivo == id) ?? 
                throw new ArgumentException("Archivo inexistente");
            return archivo;
        }

        public async Task<IEnumerable<Archivos>> GetAll()
        {
            return await _unitOfWork.ArchivosRepository.GetAllAsync();
        }

        public async Task<Archivos> CreateArchivo(Archivos archivo)
        {
            ArchivosValidators validator = new();

            var validationResult = await validator.ValidateAsync(archivo);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.ArchivosRepository.GetAllAsync();
                if (!muchos.Any(x => x.IDArchivo == archivo.IDArchivo))
                {
                    await _unitOfWork.ArchivosRepository.AddAsync(archivo);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("El archivo ya se encuentra registrado");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return archivo;
        }

       
    }
}