namespace VirtualOffice.Web.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VirtualOffice.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<VirtualOffice.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VirtualOffice.Web.Models.ApplicationDbContext context)
        {
            var userManager =
                new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager =
                new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // Crear Roles

            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("Cliente"));
            roleManager.Create(new IdentityRole("Empleado"));

            // Crear Usuario (admin)
            var user = new ApplicationUser()
            {
                UserName = "admin@mailinator.com",
                Email = "admin@mailinator.com",
                Area = "Soporte",
                Nombre = "SysAdmin",
                DebeCambiarPassword = false

            };

            userManager.Create(user, "P@$$w0rd");
            userManager.AddToRole(user.Id, "Admin");

            // Crear Usuario (empleado)
            var empleado = new ApplicationUser()
            {
                UserName = "empleado@mailinator.com",
                Email = "empleado@mailinator.com",
                Area = "Ventas",
                Nombre = "Empleado de Prueba",
                DebeCambiarPassword = false
            };

            userManager.Create(empleado, "P@$$w0rd");
            userManager.AddToRole(empleado.Id, "Empleado");


            var cliente = new ApplicationUser()
            {
                UserName = "cliente@mailinator.com",
                Email = "cliente@mailinator.com",
                Nombre = "Cliente de Prueba",
                DebeCambiarPassword = false
            };

            userManager.Create(cliente, "P@$$w0rd");
            userManager.AddToRole(cliente.Id, "Cliente");
        }
    }
}
