using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Microsoft.AspNet.Identity
{
    public static class IdentityExtensiones
    {
        // se esta extendiendo la Interfaz IPrincipal con un met. NombreUsuario
        public static string NombreUsuario(this IPrincipal usuarioSesion)
        {
            if (!usuarioSesion.Identity.IsAuthenticated) return string.Empty;
            return (usuarioSesion.Identity as ClaimsIdentity).Name;
        }

        public static IList<string> Roles(this IPrincipal usuarioSesion)
        {
            if (!usuarioSesion.Identity.IsAuthenticated) return new List<string>();

            var claims = usuarioSesion.Identity as ClaimsIdentity;

            return claims
                .Claims
                .Where(x => x.Type == ClaimTypes.Role)
                .Select(x => x.Value).ToList();
        }
    }
}