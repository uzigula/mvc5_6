using System;
using System.Collections.Generic;
using TiendaMusica.Dominio;

namespace TiendaMusica.Data.Repositorio
{
    public interface ITiendaMusicaRepository : IDisposable
    {
        IGenericRepository<Album> Albums { get; }
        IGenericRepository<Artist> Artistas { get; }
        IGenericRepository<Customer> Clientes { get; }
        IGenericRepository<Employee> Empleados { get; }
        IGenericRepository<Genre> Genero { get; }
        IGenericRepository<Invoice> Facturas { get; }
        IGenericRepository<InvoiceLine> DetalleFacturas { get; }

        IGenericRepository<MediaType> TipoMedio { get; }

        IGenericRepository<Playlist> ListaCanciones { get; }

        IGenericRepository<Track> Canciones { get; }


        void Commit();

        // consulta generica

        IEnumerable<TResult> ConsultaAdHoc<TResult>(string query, object parameters);
        //IEnumerable<TResult> ConsultaPorStoredProc<TResult>(string storedProcName, object parameters);
    }
}