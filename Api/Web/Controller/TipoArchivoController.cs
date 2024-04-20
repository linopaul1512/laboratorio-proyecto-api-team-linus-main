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
    public class TipoArchivoController : ControllerBase
    {
        
        private readonly ITipoArchivosService _serviceTipoArchivo;
        public TipoArchivoController(ITipoArchivosService userTipoArchivo)
        {
            _serviceTipoArchivo = userTipoArchivo;
        }
 
        

        /// <summary>
        /// Buscar todos las tasas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoArchivos>>> GetAll(){

            var tipoArchivos = await _serviceTipoArchivo.GetAll();

            return Ok(tipoArchivos);
        }

        /// <summary>
        /// Buscar tipos por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoArchivos>> GetTipoArchivoByName(string nombre){
            var tasas = await _serviceTipoArchivo.GetTipoArchivoByName(nombre);
            return Ok(tasas);
        }

       /// <summary>
       /// Crear tipos
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TipoArchivos>> Post([FromBody] TipoArchivos Objeto)
        {
            try
            {
                var createdObjeto =
                    await _serviceTipoArchivo.CreateTipo(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    
        
      
    }
}