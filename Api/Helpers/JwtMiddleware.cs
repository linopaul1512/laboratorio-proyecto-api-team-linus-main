using Core.Entidades;
using Core.Interfaces.Servicios;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

// Middleware para validar y adjuntar el usuario al contexto de la solicitud HTTP mediante JWT.
namespace Web.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;

        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        // Método invocado por el middleware.
        public async Task Invoke(HttpContext context, IUserService userService)
        {
            // Obtiene el token de autorización del encabezado HTTP.
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            // Si se encuentra un token, se intenta adjuntar el usuario al contexto.
            if (token != null)
                await attachUserToContext(context, userService, token);

            // Continúa con el siguiente middleware en la cadena.
            await _next(context);
        }

        // Método para adjuntar el usuario al contexto.
        private async Task attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                // Validar el token JWT.
                var tokenHandler = new JwtSecurityTokenHandler();
                var skey = _configuration["Jwt:Key"];
                var key = Encoding.ASCII.GetBytes(skey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // Set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later).
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                // Obtener el ID del usuario del token JWT.
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // Adjuntar el usuario al contexto en caso de validación exitosa del JWT.
                // Llamada a la base de datos u otro servicio para obtener más información del usuario si es necesario.
                context.Items["ok"] = true;
            }
            catch
            {
                // No hacer nada si falla la validación del JWT.
                // El usuario no se adjunta al contexto, por lo que la solicitud no tendrá acceso a rutas seguras.
            }
        }
    }
}
