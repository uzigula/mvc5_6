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
        public static string MostrarNombre(this IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return string.Empty;

            var claims = user.Identity as ClaimsIdentity;

            if (claims.EsNulo()) return string.Empty;

            var nombre = claims
                .Claims
                .SingleOrDefault(x => x.Type.Equals("Nombre"));
            return !nombre.EsNulo() ? nombre.Value : string.Empty;
        }

        public static string Usuario(this IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return string.Empty;

            var claims = user.Identity as ClaimsIdentity;

            if (claims.EsNulo()) return string.Empty;

            var nombre = claims
                .Claims
                .SingleOrDefault(x => x.Type.Equals("user"));
            return !nombre.EsNulo() ? nombre.Value : string.Empty;
        }

        public static string TraerRutaCliente(this IPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) return string.Empty;

            var claims = user.Identity as ClaimsIdentity;

            if (claims.EsNulo()) return string.Empty;

            var ruta = claims
                .Claims
                .SingleOrDefault(x => x.Type.Equals("ruta"));
            return !ruta.EsNulo() ? ruta.Value : string.Empty;
            
        }
    }
}