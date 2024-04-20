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
    public class MovimientoService : IMovimientosService
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public MovimientoService(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        public async Task<Movimientos> UpdateMovimiento(int id, Movimientos movimientos)
        {
            MovimientosValidators validaciones = new();
            var validationResult = await validaciones.ValidateAsync(movimientos);
            if (validationResult.IsValid)
            {
                var many = await _unitOfWork.MovimientosRepository.GetAllAsync();
                if (many.Any(x => x.IDMovimiento == id))
                {
                    await _unitOfWork.MovimientosRepository.Update(movimientos);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("Se produjo un aerror al modificar los datos");
            } else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return movimientos                                                  ;
        }

 
        public async Task<Movimientos> GetMovimientoById(int id)
        {
            var muchos = await _unitOfWork.MovimientosRepository.GetAllAsync();
            var movimiento = 
                muchos.FirstOrDefault(x => x.IDMovimiento == id) ?? 
                throw new ArgumentException("Movimiento inexistente");
            return movimiento;
        }

        public async Task<IEnumerable<Movimientos>> GetAll()
        {
            return await _unitOfWork.MovimientosRepository.GetAllAsync();
        }

       /* public async Task<Movimientos> CreateMovimiento(Movimientos movimiento)
        {
            MovimientosValidators validator = new();

            var validationResult = await validator.ValidateAsync(movimiento);
            if (validationResult.IsValid)
            {
                var muchos = await _unitOfWork.MovimientosRepository.GetAllAsync();
                if (!muchos.Any(x => x.IDMovimiento == movimiento.IDMovimiento))
                {
                    await _unitOfWork.MovimientosRepository.AddAsync(movimiento);
                    await _unitOfWork.CommitAsync();
                } else throw new ArgumentException("El movimiento ya se encuentra registrado");
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return movimiento;
        }/*/

       
        public async Task<Movimientos> CreateMovimiento(Movimientos newMovimiento)
        {
            MovimientosValidators validator = new();

            var validationResult = await validator.ValidateAsync(newMovimiento);
            if (validationResult.IsValid)
            {
                // Validar que el tipo de movimiento sea "Depósito" o "Retiro"
                var tipoMovimiento = await _unitOfWork.MovimientosRepository.GetByNombreAsync(newMovimiento.IDTipo.ToString());


                if (tipoMovimiento == null)
                {
                    throw new ArgumentException($"Tipo de movimiento '{newMovimiento.Tipo}' no encontrado");
                }

                if (newMovimiento.IDTipo != tipoMovimiento.IDTipo)
                {
                    throw new ArgumentException($"El tipo de movimiento no es '{newMovimiento.Tipo}'");
                }


                if (tipoMovimiento.Tipo.ToString() == "Depósito")
                {
                    // Obtener la cuenta asociada al movimiento
                    var cuenta = await _unitOfWork.CuentasRepository.GetByIdAsync(newMovimiento.IDCuentaDebitada);

                    if (cuenta == null)
                    {
                        throw new ArgumentException("Cuenta no encontrada");
                    }

                    // Sumar el monto del movimiento al saldo de la cuenta
                    cuenta.Saldo += (int)newMovimiento.Monto;

                    // Actualizar el saldo de la cuenta en la base de datos
                    await _unitOfWork.CuentasRepository.Update(cuenta);
                    await _unitOfWork.CommitAsync();

                    // Registrar el movimiento
                    var muchos = await _unitOfWork.MovimientosRepository.GetAllAsync();
                    if (!muchos.Any(x => x.IDMovimiento == newMovimiento.IDMovimiento))
                    {
                        await _unitOfWork.MovimientosRepository.AddAsync(newMovimiento);
                        await _unitOfWork.CommitAsync();
                    }
                    else
                    {
                        throw new ArgumentException("El movimiento ya se encuentra registrado");
                    }
                }
                else if (tipoMovimiento.Tipo.ToString() == "Retiro")
                {
                    // Obtener la cuenta asociada al movimiento
                    var cuenta = await _unitOfWork.CuentasRepository.GetByIdAsync(newMovimiento.IDCuentaAcreditada);

                    if (cuenta == null)
                    {
                        throw new ArgumentException("Cuenta no encontrada");
                    }

                    // Validar que el saldo sea suficiente para el retiro
                    if (cuenta.Saldo < (int)newMovimiento.Monto)
                    {
                        throw new ArgumentException("Saldo insuficiente para realizar el retiro");
                    }

                    // Restar el monto del movimiento al saldo de la cuenta
                    cuenta.Saldo -= (int)newMovimiento.Monto;

                    // Actualizar el saldo de la cuenta en la base de datos
                    await _unitOfWork.CuentasRepository.Update(cuenta);
                    await _unitOfWork.CommitAsync();

                    // Registrar el movimiento
                    var muchos = await _unitOfWork.MovimientosRepository.GetAllAsync();
                    if (!muchos.Any(x => x.IDMovimiento == newMovimiento.IDMovimiento))
                    {
                        await _unitOfWork.MovimientosRepository.AddAsync(newMovimiento);
                        await _unitOfWork.CommitAsync();
                    }
                    else
                    {
                        throw new ArgumentException("El movimiento ya se encuentra registrado");
                    }
                }
                else if (tipoMovimiento.Tipo.ToString() == "Tranferencia")
                {
                   // Obtener las cuentas asociadas a la transferencia
                    var cuentaDebitada = await _unitOfWork.CuentasRepository.GetByIdAsync(newMovimiento.IDCuentaDebitada);
                    var cuentaAcreditada = await _unitOfWork.CuentasRepository.GetByIdAsync(newMovimiento.IDCuentaAcreditada);

                    if (cuentaDebitada == null || cuentaAcreditada == null)
                    {
                        throw new ArgumentException("Una de las cuentas involucradas en la transferencia no existe");
                    }

                    // Validar que la cuenta de acreditada tenga saldo suficiente para la transferencia
                    if (cuentaAcreditada.Saldo < (int)newMovimiento.Monto)
                    {
                        throw new ArgumentException("Usted no tiene saldo suficiente para la transferencia");
                    }
                    // Restar el monto de la transferencia a la cuenta de crédito
                    cuentaAcreditada.Saldo -= (int)newMovimiento.Monto;

                    // Sumar el monto de la transferencia de la cuenta de débito
                    cuentaDebitada.Saldo += (int)newMovimiento.Monto;

                    

                    // Actualizar los saldos de ambas cuentas en la base de datos
                    await _unitOfWork.CuentasRepository.Update(cuentaDebitada);
                    await _unitOfWork.CuentasRepository.Update(cuentaAcreditada);
                    await _unitOfWork.CommitAsync();

                    // Registrar el movimiento de transferencia
                    var muchos = await _unitOfWork.MovimientosRepository.GetAllAsync();
                    if (!muchos.Any(x => x.IDMovimiento == newMovimiento.IDMovimiento))
                    {
                        await _unitOfWork.MovimientosRepository.AddAsync(newMovimiento);
                        await _unitOfWork.CommitAsync();
                    }
                
                }
                else
                {
                    throw new ArgumentException($"Tipo de movimiento '{newMovimiento.Tipo}' no válido");
                }
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newMovimiento;
        }

        




       
    }
}