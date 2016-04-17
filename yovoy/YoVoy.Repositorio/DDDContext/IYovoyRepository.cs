using System;
using YoVoy.Repositorio.Entidades;

namespace YoVoy.Repositorio.DDDContext
{
    public interface IYoVoyRepository : IDisposable
    {
        IGenericRepository<Evento> EventoRepository { get; }
        IGenericRepository<Asistente> AsistenteRepository { get; }
        IGenericRepository<Usuario> UsuarioRepository { get; }
        void Commit();
    }
}