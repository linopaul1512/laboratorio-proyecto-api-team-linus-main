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
    public class UsuarioController : ControllerBase
    {
        
       // Llama al método de servicio para realizar el inicio de sesión y obtener el token JWT.
        private readonly IUsuarioService _userService;
        public UsuarioController(IUsuarioService userService)
        {
            _userService = userService;
        }

        

        /// <summary>
        /// Buscar todos los usuarios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll(){

            var Usuario = await _userService.GetAll();

            return Ok(Usuario);
        }

        /// <summary>
        /// Buscar usuario por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(int id){
            // Llama al método de servicio para obtener un usuario por su ID.
            var Usuario = await _userService.GetUsuarioById(id);
            // Devuelver con el usuario encontrado.
            return Ok(Usuario);
        }

       /// <summary>
       /// Crear usuario
       /// </summary>
       /// <param name="Objeto"></param>
       /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Usuario>> Post([FromBody] Usuario Objeto)
        {
            try
            {
                var createdObjeto =
                    await _userService.CreateUsuario(Objeto);

                return Ok(createdObjeto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        /// <summary>
        /// Modificar usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Objeto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Put(int id, [FromBody] Usuario Objeto){
            try{
                Usuario updatedObjeto =
                    await _userService.UpdateUsuario(id, Objeto);
                
                return updatedObjeto;
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }

        }
        
      
    }
}