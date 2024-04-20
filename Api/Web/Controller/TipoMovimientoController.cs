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
    public class TipoMovimientoController : ControllerBase
    {
        
        private readonly ITipoMovimientoService _serviceTipoMovimiento;
        public TipoMovimientoController(ITipoMovimientoService serviceTasas)
        {
            _serviceTipoMovimiento = serviceTasas;
        }
 
        

        /// <summary>
        /// Buscar todos las tipo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoMovimiento>>> GetAll(){

            var tipos = await _serviceTipoMovimiento.GetAll();

            return Ok(tipos);
        }

        /// <summary>
        /// Buscar tipo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoMovimiento>> GetTipoByName(string tipo){
            var tipos = await _serviceTipoMovimiento.GetTipoByName(tipo);
            return Ok(tipos);
        }

       /// <summary>
       /// Crear tipo
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TipoMovimiento>> Post([FromBody] TipoMovimiento Objeto)
        {
            try
            {
                var createdObjeto =
                    await _serviceTipoMovimiento.CreateTipo(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    
        
      
    }
}