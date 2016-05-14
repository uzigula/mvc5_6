using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TiendaMusica.Data.EF.RepositoriosEntidades;
using TiendaMusica.Dominio;

namespace TiendaMusica.Data.Repositorio
{
    public class EFTiendaMusicaRepository : DbContext, ITiendaMusicaRepository
    {
        private readonly IGenericRepository<Album> _albums;

        public EFTiendaMusicaRepository()
            : base("name=ChinookDominio")
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            _albums = new AlbumRepository(this);
        }
        #region metodos para EF
        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artist> Artist { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLine { get; set; }
        public virtual DbSet<MediaType> MediaType { get; set; }
        public virtual DbSet<Playlist> Playlist { get; set; }
        public virtual DbSet<Track> Track { get; set; }
        #endregion
        #region ITiendaMusicaRepositorio
        public IGenericRepository<Album> Albums
        {
            get
            {
                return _albums;
            }
        }

        public IGenericRepository<Artist> Artistas
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<Customer> Clientes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<Employee> Empleados
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<Genre> Genero
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<Invoice> Facturas
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<InvoiceLine> DetalleFacturas
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<MediaType> TipoMedio
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<Playlist> ListaCanciones
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IGenericRepository<Track> Canciones
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion


        #region DbContext
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Artist>()
                .HasMany(e => e.Album)
                .WithRequired(e => e.Artist)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Invoice)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Customer)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.SupportRepId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employee1)
                .WithOptional(e => e.Employee2)
                .HasForeignKey(e => e.ReportsTo);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Total)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceLine)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceLine>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<MediaType>()
                .HasMany(e => e.Track)
                .WithRequired(e => e.MediaType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Playlist>()
                .HasMany(e => e.Track)
                .WithMany(e => e.Playlist)
                .Map(m => m.ToTable("PlaylistTrack").MapLeftKey("PlaylistId").MapRightKey("TrackId"));

            modelBuilder.Entity<Track>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Track>()
                .HasMany(e => e.InvoiceLine)
                .WithRequired(e => e.Track)
                .WillCascadeOnDelete(false);
        }

        #endregion
        #region IUnitOfWork Implementation



        public void Commit()
        {
            this.SaveChanges();
        }

        public IEnumerable<TResult> ConsultaAdHoc<TResult>(string query, object parameters)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}