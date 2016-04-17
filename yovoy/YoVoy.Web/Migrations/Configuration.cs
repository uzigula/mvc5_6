namespace YoVoy.Web.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using YoVoy.Web.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<YoVoy.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {

            AddRole("Operador",context);
            AddRole("SysAdmin",context);
            AddRole("Usuario",context);
            context.SaveChanges();
        }

        private void AddRole(string roleName, ApplicationDbContext context)
        {
            if (!context.Roles.Any(x=>x.Name==roleName))
                context.Roles.Add(new IdentityRole(roleName));
        }
    }
}
