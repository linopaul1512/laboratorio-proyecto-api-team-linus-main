using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entidades;
using Core.Interfaces.Servicios;
using Core.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SesionController : ControllerBase
    {
        private ISesionService _servicio;

        public SesionController(ISesionService SesionService){
           _servicio = SesionService;
        }

        /// <summary>
        /// Crear sesión
        /// </summary>
        /// <returns>Objeto de la nueva sesion realizada</returns>
        /// <remarks>
        /// 
        /// </remarks>
        [HttpPost("/create")]
        public async Task<ActionResult<Sesion>> Post([FromBody] Usuario usuario)
        {
            try
            {
                var sesionCreada =
                    await _servicio.Login(usuario.CI, usuario.Contraseña);

                return Ok(sesionCreada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        ///  Validar el token de la sesión
        /// </summary>
        /// <returns></returns>
        [HttpPost("/validate")]
        public async Task<ActionResult<bool>> Post([FromBody] string token)
        {
            try
            {
                var resultado = _servicio.Validate(token);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Cerrar sesiión
        /// </summary>
        /// <param name="sesion">El objeto de la sesion</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult<string>> Close([FromBody] Sesion sesion) {
            try
            {
                _servicio.Close_Sesion(sesion);
                return Ok("");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}