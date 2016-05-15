using Insight.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaMusica.Data.Repositorio;
using TiendaMusica.Dominio;

namespace TiendaMusica.Data.InsightDB
{
    public class TiendaMusicaDB : ITiendaMusicaRepository
    {
        private IDbConnection db;
        private IGenericRepository<Album> _albums;

        public TiendaMusicaDB(string connectionStringName)
        {
            db = new SqlConnection(
                ConfigurationManager
                .ConnectionStrings[connectionStringName]
                .ConnectionString);
            _albums = new AlbumGenericRepository(db);
        }
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

        public IGenericRepository<Track> Canciones
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

        public IGenericRepository<InvoiceLine> DetalleFacturas
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

        public IGenericRepository<Invoice> Facturas
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

        public IGenericRepository<Playlist> ListaCanciones
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

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (db.State == ConnectionState.Open) db.Close();
            db.Dispose();
            _albums = null;
            db = null;
        }

        public IEnumerable<TResult> ConsultaAdHoc<TResult>(string query, object parameters)
        {
            return db.QuerySql<TResult>(query, parameters);
        }

        public IEnumerable<TResult> ConsultaPorStoredProc<TResult>(string storedProcName, object parameters)
        {
            return db.Query<TResult>(storedProcName, parameters);
        }
    }
}
