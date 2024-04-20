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
    public class TasaController : ControllerBase
    {
        
        private readonly ITasasService _serviceTasas;
        public TasaController(ITasasService userTasas)
        {
            _serviceTasas = userTasas;
        }
 
        

        /// <summary>
        /// Buscar todos las tasas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasas>>> GetAll(){

            var tasas = await _serviceTasas.GetAll();

            return Ok(tasas);
        }

        /// <summary>
        /// Buscar tasas por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasas>> GetTasaByPorcentaje(int id){
            var tasas = await _serviceTasas.GetTasaByPorcentaje(id);
            return Ok(tasas);
        }

       /// <summary>
       /// Crear tasa
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Tasas>> Post([FromBody] Tasas Objeto)
        {
            try
            {
                var createdObjeto =
                    await _serviceTasas.CreateTasa(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    
        
      
    }
}