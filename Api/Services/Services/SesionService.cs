/*using System;
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

namespace Services.Services
{
    public class SesionService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SesionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string Close_Sesion(Sesion sesion)
        {
            _unitOfWork.SesionesRepository.Remove(sesion);
            return "";
        }
        public byte[] key() {
            return Encoding.ASCII.GetBytes("2777ad7b90f3e3bd4f5080ec78bd16d0");
        }

        public async Task<Sesion> Login(int cedula, string contraseña)
        {
            var lista = await _unitOfWork.UsuariosRepository.GetAllAsync();
            if (lista.Any(x => x.CI == cedula && x.Contraseña == contraseña))
            {
                Usuario usuario = await _unitOfWork.UsuariosRepository.GetByIdAsync(cedula);
                if (usuario == null) return null;
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, (usuario.CI != "") ? 
                            usuario.CI : $"{usuario.Nombre} {usuario.Apellido}"),
                        new Claim("cedula", usuario.CI)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key()), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string tokenFinal = tokenHandler.WriteToken(token);
                Sesion sesion = new Sesion
                {
                    CedulaUsuario = usuario.CI,
                    Token = tokenFinal
                };
                await _unitOfWork.SesionesRepository.AddAsync(sesion);
                return sesion;
            } else return null;

        }

        public bool Validate(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
            if (validatedToken.ValidTo < DateTime.UtcNow.AddMinutes(15)) return true;
            return false;
        }

        private TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = true, 
                ValidateAudience = false, 
                ValidateIssuer = false, 
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("2777ad7b90f3e3bd4f5080ec78bd16d0"))
            };
        }
    }
}*/