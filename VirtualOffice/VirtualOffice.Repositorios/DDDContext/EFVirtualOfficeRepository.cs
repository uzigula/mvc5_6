using System.Data.Entity;
using VirtualOffice.Repositorios.Dominio;
using VirtualOffice.Repositorios.Dominio.Componentes;

namespace VirtualOffice.Repositorios.DDDContext
{
    public class EFVirtualOfficeRepository : DbContext, IVirtualOfficeRepository
    {
        private readonly ClienteRepositorio _clienteRepo;
        private readonly ReservaRepositorio _reservaRepo;
        private readonly SalaRepositorio _salaRepo;
        private readonly SucursalRepositorio _sucursalRepo;

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Direccion>().Property(p => p.Ciudad).HasMaxLength(50);
            modelBuilder.ComplexType<Direccion>().Property(p => p.Distrito).HasMaxLength(50);
            modelBuilder.ComplexType<Direccion>().Property(p => p.Provincia).HasMaxLength(50);
            modelBuilder.ComplexType<Direccion>().Property(p => p.Calle).HasMaxLength(100);
            base.OnModelCreating(modelBuilder);
        }
        public EFVirtualOfficeRepository()
            : base("name=VOffice")
        {
            _clienteRepo = new ClienteRepositorio(this);
            _reservaRepo = new ReservaRepositorio(this);
            _salaRepo = new SalaRepositorio(this);
            _sucursalRepo = new SucursalRepositorio(this);
        }

        #region IUnitOfWork Implementation

        

        public void Commit()
        {
            this.SaveChanges();
        }

        #endregion

        public IGenericRepository<Cliente> ClienteRepository
        {
            get { return _clienteRepo; }
        }

        public IGenericRepository<Reserva> ReservaRepository
        {
            get { return _reservaRepo; }
        }

        public IGenericRepository<Sala> SalasRepository
        {
            get { return _salaRepo; }
        }

        public IGenericRepository<Sucursal> SucursalRepository
        {
            get { return _sucursalRepo; }
        }
    }
}