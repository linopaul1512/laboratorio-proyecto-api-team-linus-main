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
    public class CuotaController : ControllerBase
    {
        
        private readonly ICuotasService _serviceCuotas;
        public CuotaController(ICuotasService cuotaCuotas)
        {
            _serviceCuotas = cuotaCuotas;
        }
 
        

        /// <summary>
        /// Buscar todos los archivos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasas>>> GetAll(){

            var cuotas = await _serviceCuotas.GetAll();

            return Ok(cuotas);
        }

        /// <summary>
        /// Buscar cuota por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Cuotas>> GetCuotaById(int id){
            var tasas = await _serviceCuotas.GetCuotaById(id);
            return Ok(tasas);
        }

       /// <summary>
       /// Crear cuota
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Cuotas>> Post([FromBody] Cuotas Objeto)
        {
            try
            {
                var createdObjeto =
                    await _serviceCuotas.CreateCuota(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    
        
      
    }
}