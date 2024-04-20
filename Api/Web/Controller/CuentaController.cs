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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Claims;
using Core.Servicios;


namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : ControllerBase
    {
        
        private readonly ICuentasService _serviceCuenta;
        public CuentaController(ICuentasService serviceCuentas)
        {
            _serviceCuenta = serviceCuentas;
        }
 
        

        /// <summary>
        /// Buscar todos los cuentas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuentas>>> GetAll(){

            var cuentas = await _serviceCuenta.GetAll();

            return Ok(cuentas);
        }

        /// <summary>
        /// Buscar cuenta por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuentas>> GetCuotaById(int id){
            var cuentas = await _serviceCuenta.GetCuentaById(id);
            return Ok(cuentas);
        }

       /// <summary>
       /// Crear cuenta
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Cuentas>> Post([FromBody] Cuentas Objeto)
        {
            try
            {
                var createdObjeto =
                    await _serviceCuenta.CreateCuenta(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    
        
      
    }
}