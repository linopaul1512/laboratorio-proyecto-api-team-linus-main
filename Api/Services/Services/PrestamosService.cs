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
    public class PrestamosService : IPrestamosService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public PrestamosService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
 

 
        public async Task<Prestamos> GetPrestamoById(int id)
        {
            var muchos = await _unitOfWork.PrestamosRepository.GetAllAsync();
            var prestamo = 
                muchos.FirstOrDefault(x => x.IDPrestamo== id) ?? 
                throw new ArgumentException("Préstamo inexistente");
            return prestamo;
        }

        public async Task<IEnumerable<Prestamos>> GetAll()
        {
            return await _unitOfWork.PrestamosRepository.GetAllAsync();
        }

        public async Task<Prestamos> CreatePrestamo(Prestamos newPrestamo)
        {
            PrestamosValidators validator = new();

            var validationResult = await validator.ValidateAsync(newPrestamo);
            if (validationResult.IsValid)
            {
                // Verificar y agregar tasas de interés del 20% y 30% si no existen
                var tasaInteres20 = await _unitOfWork.TasasRepository.GetByPorcentajeAsync(0.20);
                if (tasaInteres20 == null)
                {
                    var nuevaTasa20 = new Tasas { Porcentaje = 0.20 };
                    await _unitOfWork.TasasRepository.AddAsync(nuevaTasa20);
                    await _unitOfWork.CommitAsync();
                    tasaInteres20 = nuevaTasa20; // Asignar la nueva tasa a la variable
                }

                var tasaInteres30 = await _unitOfWork.TasasRepository.GetByPorcentajeAsync(0.30);
                if (tasaInteres30 == null)
                {
                    var nuevaTasa30 = new Tasas { Porcentaje = 0.30 };
                    await _unitOfWork.TasasRepository.AddAsync(nuevaTasa30);
                    await _unitOfWork.CommitAsync();
                    tasaInteres30 = nuevaTasa30; // Asignar la nueva tasa a la variable
                }

                double interes = 0.0;
                // Obtener la tasa de interés correspondiente según el plazo del préstamo
                if (newPrestamo.CantCuotas >= 1 && newPrestamo.CantCuotas <= 12)
                {
                    interes = tasaInteres20.Porcentaje;  // 20%
                }
                else if (newPrestamo.CantCuotas >= 13 && newPrestamo.CantCuotas <= 24)
                {
                    interes = tasaInteres30.Porcentaje; // 30%
                }
                else
                {
                    throw new ArgumentException("Plazo de préstamo no válido");
                }

                // Calcular la cuota mensual
                double i = interes / 12; // Tasa de interés mensual
                double n = newPrestamo.CantCuotas; // Plazo del préstamo en meses
                double cuotaMensual = (newPrestamo.Monto * i) / (1 - Math.Pow(1 + i, -n));

                // Asignar la tasa de interés al préstamo
                newPrestamo.IDTasa = tasaInteres20.IDTasa; // Asignar el ID de la tasa

                // Obtener la cuenta asociada al préstamo
                var cuenta = await _unitOfWork.CuentasRepository.GetByIdAsync(newPrestamo.IDCuenta);

                if (cuenta == null)
                {
                    throw new ArgumentException("Cuenta no encontrada");
                }

                // Actualizar el estado de la cuenta en la base de datos
                cuenta.Saldo += newPrestamo.Monto; // Sumar el monto del préstamo al saldo de la cuenta
                await _unitOfWork.CuentasRepository.Update(cuenta);
                await _unitOfWork.CommitAsync();

                // Registrar el préstamo en la base de datos
                var muchos = await _unitOfWork.PrestamosRepository.GetAllAsync();
                if (!muchos.Any(x => x.IDPrestamo == newPrestamo.IDPrestamo))
                {
                    await _unitOfWork.PrestamosRepository.AddAsync(newPrestamo);
                    await _unitOfWork.CommitAsync();
                }
                else
                {
                    throw new ArgumentException("El préstamo ya se encuentra registrado");
                }
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newPrestamo;
        }

       
    }
}