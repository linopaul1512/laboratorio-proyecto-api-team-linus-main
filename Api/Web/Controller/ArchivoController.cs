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
    public class ArchivoController : ControllerBase
    {
        
        private readonly IArchivosService _serviceArchivos;
        public ArchivoController(IArchivosService userArchivos)
        {
            _serviceArchivos = userArchivos;
        }

        

        /// <summary>
        /// Buscar todos los archivos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll(){

            var archivos = await _serviceArchivos.GetAll();

            return Ok(archivos);
        }

        /// <summary>
        /// Buscar archivo por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamos>> GetById(int id){
            var usuario = await _serviceArchivos.GetArchivoById(id);
            return Ok(usuario);
        }

       /// <summary>
       /// Crear archivo
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Archivos>> Post([FromBody] Archivos Objeto)
        {
            try
            {
                var createdObjeto =
                    await _serviceArchivos.CreateArchivo(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    
        
      
    }
}