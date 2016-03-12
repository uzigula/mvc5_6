namespace Seguridad.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    internal sealed class Configuration : DbMigrationsConfiguration<Seguridad.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Seguridad.Models.ApplicationDbContext context)
        {
            AddRole(context, "Admin");
            AddRole(context, "Vendedor");
        }

        private void AddRole(ApplicationDbContext context, string role)
        {
            if (!context.Roles.Any(x => x.Name == role))
                context.Roles.Add(new IdentityRole(role));
        }
    }
}
