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
    public class Archivo_PrestamoController : ControllerBase
    {
        
        private readonly IArchivosPrestamosServices _service;
        public Archivo_PrestamoController(IArchivosPrestamosServices userArchivoPrestamo)
        {
            _service = userArchivoPrestamo;
        }

        

        /// <summary>
        /// Buscar todos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll(){

            var archivos = await _service.GetAll();

            return Ok(archivos);
        }

        /// <summary>
        /// Buscar dato por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Archivos_Prestamos>> GetById(int id){
            var inter = await _service.GetInterById(id);
            return Ok(inter);
        }

      /* /// <summary>
       /// Crear dato
       /// </summary>
       /// <returns></returns>
       
        [HttpPost]
        public async Task<ActionResult<Archivos_Prestamos>> Post([FromBody] Archivos_Prestamos Objeto)
        {
            try
            {
                var createdObjeto =
                    await _service.CreateInter(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }*/
        
    
        
      
    }
}