using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
/*using Core.Entidades;
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
            UsuariosValidacion validaciones = new();
            var validationResult = await validaciones.ValidateAsync(usuario);
            if (validationResult.IsValid)
            {
                var many = await _unitOfWork.ArchivosRepository.GetAllAsync();
                if (many.Any(x => x.IDArchivo == id))
                {
                    await _unitOfWork.UsuarioRepository.Update(usuario);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("No se pudo actualizar los datos");
            } else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return usuario;
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            var muchos = await _unitOfWork.UsuarioRepository.GetAllAsync();
            var usuario = 
                muchos.FirstOrDefault(x => x.CI == id) ?? 
                throw new ArgumentException("Usuario inexistente");
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _unitOfWork.UsuarioRepository.GetAllAsync();
        }

        public async Task<Usuario> CreateUsuario(Usuario usuario)
        {
            UsuariosValidacion validator = new();

            var validationResult = await validator.ValidateAsync(usuario);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.UsuarioRepository.GetAllAsync();
                if (!muchos.Any(x => x.CI == usuario.CI))
                {
                    await _unitOfWork.UsuarioRepository.AddAsync(usuario);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("la cédula de identidad ya se encuentra registrada");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return usuario;
        }
    }
}*/