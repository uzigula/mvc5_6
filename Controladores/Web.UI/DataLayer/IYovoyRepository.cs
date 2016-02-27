using System;
using Dominio;

namespace DataLayer.DDDContext
{
    public interface IYoVoyRepository : IDisposable
    {
        IGenericRepository<Evento> EventoRepository { get; }
        IGenericRepository<Asistente> AsistenteRepository { get; }
        IGenericRepository<Usuario> UsuarioRepository { get; }
        void Commit();
    }
}