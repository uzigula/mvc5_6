using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dominio;

namespace DataLayer.DDDContext
{
    public class EFYovoyRepository : DbContext, IYoVoyRepository
    {
        private readonly AsistenteRepositorio _asistenteRepo;
        private readonly EventoRepositorio _eventoRepo;
        private readonly UsuarioRepositorio _usuarioRepo;

        public DbSet<Asistente> Asistentes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Usuario> Salas { get; set; }

        public EFYovoyRepository()
            : base("name=YoVoyDB")
        {
            _asistenteRepo = new AsistenteRepositorio(this);
            _eventoRepo = new EventoRepositorio(this);
            _usuarioRepo = new UsuarioRepositorio(this);
        }

        #region IUnitOfWork Implementation

        

        public void Commit()
        {
            this.SaveChanges();
        }

        #endregion

        public IGenericRepository<Asistente> AsistenteRepository
        {
            get { return _asistenteRepo; }
        }

        public IGenericRepository<Evento> EventoRepository
        {
            get { return _eventoRepo; }
        }

        public IGenericRepository<Usuario> UsuarioRepository
        {
            get { return _usuarioRepo; }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}