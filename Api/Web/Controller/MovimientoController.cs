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
    public class MovimientoController : ControllerBase
    {
        
        private readonly IMovimientosService _serviceMovimiento;
        public MovimientoController(IMovimientosService serviceMovimiento)
        {
            _serviceMovimiento = serviceMovimiento;
        }
 
        

        /// <summary>
        /// Buscar todos los movimientos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movimientos>>> GetAll(){

            var movimientos = await _serviceMovimiento.GetAll();

            return Ok(movimientos);
        }

        /// <summary>
        /// Buscar movimiento por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movimientos>> GetCuotaById(int id){
            var movimientos = await _serviceMovimiento.GetMovimientoById(id);
            return Ok(movimientos);
        }

       /// <summary>
       /// Crear movimiento
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MovimientoController>> Post([FromBody] Movimientos Objeto)
        {
            try
            {
                var createdObjeto =
                    await _serviceMovimiento.CreateMovimiento(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    
        
      
    }
}