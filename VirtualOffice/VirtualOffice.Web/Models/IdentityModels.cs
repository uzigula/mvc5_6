using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using VirtualOffice.Servicios.Clientes;

namespace VirtualOffice.Web.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        // añadir mis campos personalizados

        public string Area { get; set; }
        public string Nombre { get; set; }
        public bool DebeCambiarPassword { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar reclamaciones de usuario personalizado aquí
            userIdentity.AddClaim(new Claim("Nombre", this.Nombre));
            //var clientes = new ServicioClientes();
            var ruta = this.UserName.Split('@')[0];//clientes.ObtenerRutaPerfil(this.UserName);
            if (!string.IsNullOrEmpty(ruta)) userIdentity.AddClaim(new Claim("ruta",ruta));
            return userIdentity;
        }


    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}