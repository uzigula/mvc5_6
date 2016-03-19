using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using VirtualOffice.Repositorios.Dominio;
using VirtualOffice.Repositorios.Dominio.Componentes;

namespace VirtualOffice.Repositorios.EF
{
    public class VOfficeDbContext : DbContext
    {
        public VOfficeDbContext()
            : base("name=VOffice")
        {
                
        }
        public VOfficeDbContext(string conexion) : base(conexion)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Direccion>().Property(p => p.Ciudad).HasMaxLength(50);
            modelBuilder.ComplexType<Direccion>().Property(p => p.Distrito).HasMaxLength(50);
            modelBuilder.ComplexType<Direccion>().Property(p => p.Provincia).HasMaxLength(50);
            modelBuilder.ComplexType<Direccion>().Property(p => p.Calle).HasMaxLength(100);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Sucursal> Sucursales { get; set; } 
    }
}
