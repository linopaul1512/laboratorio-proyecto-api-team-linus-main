using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Core.Entidades;


namespace Web.Helpers
{
    // AttributeUsage se utiliza para decorar controladores o acciones que requieren autorización.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        // OnAuthorization ejecuta antes de que se ejecute la acción del controlador para verificar la autorización.
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // Verificar si la variable "ok" está presente en el contexto HTTP y si su valor es nulo.
            var ok = (bool?)context.HttpContext.Items["ok"];
            if (ok == null)
            {
                //Mensaje personalizado en caso de que el token sea null e inválido
                context.Result = new JsonResult(new { message = "el token no es valido, Bank DavNo no aprueba esto" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}